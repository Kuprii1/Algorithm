namespace KP3_TA;

class Program
{
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>()
        {
            new Student("Goloshumov", "IP-23"),
            new Student("Chernikova", "IM-22"),
            new Student("Fedko", "IK-23"),
            new Student("Veremchyk", "IP-11"),
            new Student("Kuprii", "IK-23"),
            new Student("Vlasuk", "IM-22"),
            new Student("Podgornyi", "IP-23"),
            new Student("Golovatuk", "IP-11"),
            new Student("Pashkova", "IK-23")
        };

        TeacherHelper algorithm = new TeacherHelper(students);
        algorithm.FillStack();
        Student? student = algorithm.PopNext();

        while (student != null)
        {
            Console.Write($"Work {student.Name}, group: {student.GroupCode}: Enter mark for him:");
            int mark = int.Parse(Console.ReadLine()!);
            student.GiveMark(mark);

            student = algorithm.PopNext();
        }
        Console.ReadLine();
    }
}
