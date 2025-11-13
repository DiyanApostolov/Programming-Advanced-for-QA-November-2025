int n = int.Parse(Console.ReadLine());

List<Student> students = new List<Student>();

for (int i = 0; i < n; i++)
{
    // четем входни данни с информация за студента
    string[] stidentInfo = Console.ReadLine().Split(" ");

    string firstName = stidentInfo[0];
    string lastName = stidentInfo[1];
    double grade = double.Parse(stidentInfo[2]);

    // вдигаме си инстанция на класа/типа Student
    Student currentStudent = new Student(firstName, lastName, grade);

    // добавяме текущия студет в списъка
    students.Add(currentStudent);
}

// сортираме колекцията със студенти в низходящ ред спрямо оценката на студента
List<Student> sortedStudents = students.OrderByDescending(s => s.Grade).ToList();

foreach (Student student in sortedStudents)
{
    Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:F2}");
}

class Student
{
    public Student (string firstName, string lastName, double grade)
    {
        FirstName = firstName;
        LastName = lastName;
        Grade = grade;
    }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public double Grade { get; set; }
}


