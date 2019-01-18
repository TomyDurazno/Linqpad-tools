<Query Kind="Program" />

void Main()
{
	//isTeenAger.Dump();
	var f = isTeenAgerExpr.Compile();
	f(Student.Dummy).Dump();
}

public class Student 
{
    public int StudentID { get; set; }
    public string StudentName { get; set; }
    public int Age { get; set; }
	
	public static Student Dummy 
	{
		get
		{
			return new Student(101, "Josefo", 31);
		}
	}
	
	public Student(int id, string name, int age)
	{
		StudentID = id;
		StudentName = name;
		Age = age;
	}
	
}

Func<Student, bool> isTeenAger = s => s.Age > 12 && s.Age < 20;

Expression<Func<Student, bool>> isTeenAgerExpr = s => s.Age > 12 && s.Age < 20;
