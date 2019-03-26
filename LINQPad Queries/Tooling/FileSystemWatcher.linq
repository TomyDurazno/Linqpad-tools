<Query Kind="Program" />

void Main()
{
	string path = MyUtils.DesktopPath;
	var watcher = new FileSystemWatcher();
	watcher.Path = path;
	watcher.NotifyFilter = NotifyFilters.LastWrite;
	watcher.Filter = "*ticks.txt*";
	watcher.Changed += new FileSystemEventHandler(OnChanged);
	watcher.EnableRaisingEvents = true;
}

private void OnChanged(object source, FileSystemEventArgs e)
{
	MyUtils.ReadTxt(e.FullPath).Last().Call(s => Console.WriteLine(s));
}