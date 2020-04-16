<Query Kind="Program" />

void Main()
{
	var start = new DateTime(2020, 3, 16);	
	var today = DateTime.Now;
	
	/*
	3 Salidas:
	
	Una al chino
	Una al Jumbo
	Otra a la Verduleria + Granja
	*/
	
	var chino = new DateTime(2020, 3, 23);
	var jumbo = new DateTime(2020, 3, 27);	
	var verdu_granja = new DateTime(2020, 3, 28);
	
	DateTimeSpan.CompareDates(start, today).Dump();
}
