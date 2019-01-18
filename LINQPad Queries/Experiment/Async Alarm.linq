<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	await MyUtils.SetTimeOutAsync(10000, new TimeSpan(11, 00, 00), () => MyUtils.OpenFileFromDesktop("X-Dream_-_Eleven_Atmos_Remix-Vubey.mp3"));
}