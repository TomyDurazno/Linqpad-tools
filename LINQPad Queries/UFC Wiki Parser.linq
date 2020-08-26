<Query Kind="Program">
  <NuGetReference>AngleSharp</NuGetReference>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>AngleSharp</Namespace>
  <Namespace>AngleSharp.Dom</Namespace>
</Query>

async Task Main()
{
	var q = "Dustin_Poirier";
	
	var showTable = true;	
	var buildImages = true;

	#region Implementation
	
		var config = Configuration.Default.WithDefaultLoader();

		var address = $"{WikiUrlWithWiki}/{q}";
	
		var retriever = new WikiImageRetreiever();
	
		var document = await BrowsingContext.New(config).OpenAsync(address);

		IHtmlCollection<IElement> GetRows()
		{
			var wikitables = document.QuerySelectorAll(".wikitable");
			
			var count = wikitables.Count();
			var elem = 1;			
			
			switch (count)
			{
				case 6: //Nick Diaz
					elem = 2;
					break;
				case 10: //Conor McGregor
					elem = 6;
					break;
				case 4: //Amanda Nunes / all fighters
					elem = 1;
					break;
				case 5: //Dustin Poirier
					elem = 3;
					break;
				case 7:
					elem = 2;
					break;
				default:
					break;				
			}
			
			
			var element = wikitables.ElementAt(elem);
			
			return element.QuerySelectorAll("tbody tr");
		}
	
		var rows = GetRows();
		
		var head = rows.First();
		
		var body = rows.Skip(1);
		
		var table = body.Select(b => b.QuerySelectorAll("td").Select(d => d).Pipe(d => new UFCRecordTable(d))).ToList();
	
		var image = Util.Image(retriever.Get(document).IMGUrl);
	
	#endregion 
	
	image.Dump(q);

	if(buildImages)
		foreach (var element in table)
			await element.BuildLinks(retriever);

	if (showTable)
		table.Dump();

	var byResultAndMethod = false && buildImages;

	#region By Result and Method

	if (byResultAndMethod)
	{
		foreach (var results in table.GroupBy(t => t.Result).OrderBy(g => g.Key))
		{
			new { }.Dump($"{ results.Key } - { results.Count() }");

			var byMethod = results.Select(d => d)
								  .GroupBy(g => g.Method)
								  .Select(g => new { Method = g.Key, Opponents = g.Select(g1 => g1.Opponent) });

			foreach (var element in byMethod)
			{
				element.Opponents.Dump(element.Method);
			}
		}
	}
	
	#endregion
}
	
#region Constants
	
public static string WikiUrl => "https://en.wikipedia.org";
public static string WikiUrlWithWiki => "https://en.wikipedia.org/wiki";
	
#endregion
	
#region Models
	
public enum FightResult
{
	Win,
	Loss,
	Draw,
	NC
}

public class MMAFighter
{
	public string Name { get; set; }
	public object Image { get; set; }
	public Hyperlinq Link { get; set; }
}

public class MMAEvent 
{
	public string Name { get; set; }
	public bool IsPPV => new Regex("UFC ([0-9])([0-9])([0-9])").IsMatch(Name);
	public object Image { get; set; }
	public Hyperlinq Link { get; set; }
}

public class UFCRecordTable
{
	public FightResult Result { get; private set; }
	public string Record { get; private set; }
	public MMAFighter Opponent { get; private set; }
	public string Method { get; private set; }
	public MMAEvent Event { get; private set; }
	public string Date { get; private set; }
	public string Round { get; private set; }
	public TimeSpan? Time { get; private set; }
	public string Location { get; private set; }
	public string Notes { get; private set; }
		
	IEnumerable<IElement> elements { get; set; }
		
	public UFCRecordTable(IEnumerable<IElement> elems)
	{
		elements = elems;
			
		Result = elements.ElementAt(0).Pipe(e => Enum.TryParse<FightResult>(e.InnerHtml, out var res) ? res : default);
		Record = elements.ElementAt(1).InnerHtml;
		
		//Opponent
		
		var opponentNode = elements.ElementAt(2);
		
		var oppUrl = opponentNode.QuerySelector("a")?.Attributes.FirstOrDefault(a => a.Name == "href")?.Value;
		
		Opponent = new MMAFighter()
		{ 
			Name =  opponentNode.Text(),
			Link = 	oppUrl != default ? new Hyperlinq(new Uri($"{WikiUrl}{oppUrl}").ToString()) : null
		};
		
		//Method
		Method = elements.ElementAt(3).InnerHtml;
		
		//Event
		var eventNode = elements.ElementAt(4);
		
		var url = eventNode.QuerySelector("a")?.Attributes.FirstOrDefault(a => a.Name == "href")?.Value;
		
		Event = new MMAEvent()
		{
			Name = eventNode.Text(),
			Link = url != default ? new Hyperlinq(new Uri($"{WikiUrl}{url}").ToString()) : null
		};
		
		//Date
		Date = elements.ElementAtOrDefault(5)?.Text().Pipe(t => DateTime.TryParse(t, out var date) ? date.ToShortDateString() : string.Empty);
		
		//Round
		Round = elements.ElementAtOrDefault(6).InnerHtml;
		
		//Time (of last round finish)
		Time = elements.ElementAtOrDefault(7)?.Text().Pipe(t => TimeSpan.TryParse(t, out var time) ? time : default);
		
		//Location
		Location = elements.ElementAtOrDefault(8)?.Text();
		
		//Notes
		Notes = elements.ElementAtOrDefault(9)?.Text();
	}
		
	public async Task BuildLinks(IImgRetriever retriever)
	{								
		if(Opponent?.Link != default)
		{
			var result = await retriever.GoGet(Opponent.Link.ToString(), true);		
			Opponent.Image = Util.Image(result.IMGUrl);
		}
		
		if(Event?.Link != default)
		{
			var res = await retriever.GoGet(Event?.Link.ToString(), true);
			Event.Image = Util.Image(res.IMGUrl);
		}
	}
}
	
public interface IImgRetriever
{
	Task<ImgRetrieverResult> GoGet(string q, bool fullUrl = false);

	ImgRetrieverResult Get(IDocument document);
}
	
public class ImgRetrieverResult
{
	public string URL { get; set; }

	public string[] ImagesURLs { get; set; }

	public string IMGUrl => $"https:{ImagesURLs.Skip(1).First()}";
	
	public string Q { get; set; }
}
	
public class WikiImageRetreiever : IImgRetriever
{
	public async Task<ImgRetrieverResult> GoGet(string q, bool fullUrl = false)
	{
		var config = Configuration.Default.WithDefaultLoader();
		var address = fullUrl ? q : $"{WikiUrl}{q}";

		var document = await BrowsingContext.New(config).OpenAsync(address);
	
		var content = document.QuerySelectorAll("img").Select(i => i.Attributes["src"].Value).ToArray();
	
		return new ImgRetrieverResult()
		{
			ImagesURLs = content,
			URL = address,
			Q = q
		};
	}
	
	public ImgRetrieverResult Get(IDocument document)
	{
		var content = document.QuerySelectorAll("img").Select(i => i.Attributes["src"].Value).ToArray();
	
		return new ImgRetrieverResult()
		{
			ImagesURLs = content,
			URL = "",
			Q = ""
		};
	}
}
	
#endregion


