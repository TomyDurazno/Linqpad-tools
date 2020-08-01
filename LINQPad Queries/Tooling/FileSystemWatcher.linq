<Query Kind="Program" />

void Main()
{
	string path = MyUtils.DesktopPath;
	var watcher = new FileSystemWatcher();
	watcher.Path = path;
	watcher.NotifyFilter = NotifyFilters.LastWrite;
	watcher.Filter = "*ticks.txt*";
	watcher.Changed += new FileSystemEventHandler((object s, FileSystemEventArgs e) => MyUtils.ReadTxt(e.FullPath).Last().Pipe(s => { Console.WriteLine(s); return s;}));
	watcher.EnableRaisingEvents = true;
}

