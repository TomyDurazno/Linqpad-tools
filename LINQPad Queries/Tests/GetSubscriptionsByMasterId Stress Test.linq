<Query Kind="Program">
  <Connection>
    <ID>6a1a859a-089b-4548-816e-e8ad582504e1</ID>
    <Persist>true</Persist>
    <Server>10.1.3.126</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>mg2dev</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAA8u/5BabASE6xsdWYqViIMgAAAAACAAAAAAADZgAAwAAAABAAAABHjoCam/qibw28gRPYMgfDAAAAAASAAACgAAAAEAAAALRH1EEDSDOsxXPyFEIsI48IAAAAy32AZyDg04cUAAAAtCAaFYs31SlY1Ht72swHP7tRuzs=</Password>
    <IncludeSystemObjects>true</IncludeSystemObjects>
    <Database>subsvc_trib_NYDailyNews_test</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

async Task Main()
{	
	//Number of masterIds to retrieve from DB
	int numberOfMasterIds = 180;
	
	//Number of requests for each masterId
	int numberOfRequestsForMasterId = 1;
	
	//request.xml path
	var reqPath = @"C:\Users\tcordara\Desktop\Tasks\39704 - Tribune - OfferService - Analyze how to improve performance in GetSubscriptionsByMasterId\request.xml";

	//Web service URL
	var url = "http://localhost:1146/SubscriberService.asmx"; //"https://test-tribune-chicago-offers-np.solicitor-concierge.com/SubscriberService.asmx"; 

	//MasterIds
	var masterIds = SsRegistrations.OrderByDescending(sr => sr.DateRegistered)
								   .Select(sr => sr.CustomerRegistrationId)
								   .Take(numberOfMasterIds)
								   .ToList();
	
	//Switch to change to old and new version
	//NOTE: In branch, there is no OLD implementation, the NEW one is called like the OLD one
	//So, all calls to 'New' will be logged as 'Old' - KEEP IT IN MIND!
	bool version = false;
	
	//Number of multiples bombards to perform
	int numberOfMultiples = 3;
	
	//Time to be incrementally added to each multiple (in seconds)
	int timeBetweenMultiples = 1;
	
	#region Implementation	

	if(numberOfMultiples == 1)
	{
		await PerformBombard(masterIds, url, reqPath, version, numberOfRequestsForMasterId);
	}
	else if(numberOfMultiples > 1)
	{
		var AddTime = MyUtils.MakeFunc((int num) =>
		{
			var start = num;

			return MyUtils.MakeFunc(() =>
			{
				var span = TimeSpan.FromSeconds(start);
				start += num;
				return span;
			});
		
		})(timeBetweenMultiples); 

		await Task.WhenAll(Enumerable.Range(0, numberOfMultiples).Select(e => MyUtils.WaitSome(AddTime(), PerformBombard(masterIds, url, reqPath, version, numberOfRequestsForMasterId))));
	}
	else
	{
		throw new Exception("timeBetweenMultiples can not be lower than one");	
	}
	
	#endregion
}

#region Methods

public async Task PerformBombard(List<string> masterIds, string url, string reqPath, bool newVersion, int numberOfRequestsForMasterId)
{
	var watch = new Stopwatch();
	watch.Start();	

	var requestBase = MyUtils.ReadTxt(reqPath).Project(string.Concat);

	var requests = masterIds.Select(mi => requestBase.Replace("{{MasterId}}", mi))
							.Select(r => r.Replace("{{Version}}", newVersion ? "2" : string.Empty));

	var results = await Task.WhenAll(requests.Select(r => MyUtils.ExecuteManyXmlRequests(numberOfRequestsForMasterId, r, url)));

	var resultToTxt = new List<string>() { "Start All: " };

	foreach (var result in results)
	{
		var rs = result.Select(x => x.InnerXml)
					   .Select(ParseXmlResponse);

		resultToTxt.AddRange(AddEmpty(rs));
	}

	watch.Stop();

	resultToTxt.Add("/*****Results*****/");
	
	var lines = new List<string>()
	{
		string.Empty,
		string.Format("Total Elapsed Time: {0}", watch.Elapsed),
		string.Format("MasterIds found: {0}", masterIds.Count()),
		string.Format("Requests for each MasterId: {0}", numberOfRequestsForMasterId),
		string.Format("Total number of requests: {0}", masterIds.Count() * numberOfRequestsForMasterId)
	};

	resultToTxt.AddRange(lines);
	
	var requestDirPath = MyUtils.DesktopPath + @"/requests";
	
	if(!Directory.Exists(requestDirPath))
	{
		Directory.CreateDirectory(requestDirPath);
	}

	MyUtils.WriteTxt(resultToTxt, string.Concat(requestDirPath, string.Format("/requestsResults_{0}_{1}.txt", MyUtils.RandomName(5), newVersion ? "new" : "old")));

	string.Format("Success! version: {0}", newVersion ? "new" : "old").Dump();
}

public string ParseXmlResponse(string xmlResponse)
{
	return string.Format("Elapsed: {0}, RequestId: {1} - Subscriptions: {2}", GetBetween(xmlResponse, "<Elapsed>", "</Elapsed>"), GetBetween(xmlResponse, "<RequestId>", "</RequestId>"), GetBetween(xmlResponse, "<Subscriptions>", "</Subscriptions>").Project(s => string.IsNullOrEmpty(s) ? "0" : s));
}

public string GetBetween(string strSource, string strStart, string strEnd)
{
	int Start, End;
	if (strSource.Contains(strStart) && strSource.Contains(strEnd))
	{
		Start = strSource.IndexOf(strStart, 0) + strStart.Length;
		End = strSource.IndexOf(strEnd, Start);
		return strSource.Substring(Start, End - Start);
	}
	else
	{
		return "";
	}
}

public static IEnumerable<string> AddEmpty(IEnumerable<string> lines)
{	
	foreach (var line in lines)
	{
		yield return string.Empty;
		yield return line;
	}
}

#endregion