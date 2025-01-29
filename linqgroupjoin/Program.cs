


namespace SchoolDatabase
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int ClassId { get; set; }
    }

    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Öğrenci ve Sınıf listelerini oluştur
            List<Student> students = new List<Student>
            {
                new Student { StudentId = 1, StudentName = "Ali", ClassId = 1 },
                new Student { StudentId = 2, StudentName = "Ayşe", ClassId = 2 },
                new Student { StudentId = 3, StudentName = "Mehmet", ClassId = 1 },
                new Student { StudentId = 4, StudentName = "Fatma", ClassId = 3 },
                new Student { StudentId = 5, StudentName = "Ahmet", ClassId = 2 }
            };

            List<Class> classes = new List<Class>
            {
                new Class { ClassId = 1, ClassName = "Matematik" },
                new Class { ClassId = 2, ClassName = "Türkçe" },
                new Class { ClassId = 3, ClassName = "Kimya" }
            };

            // LINQ ile Group Join işlemi
            var result = from cls in classes
                         join student in students
                         on cls.ClassId equals student.ClassId into studentGroup
                         select new
                         {
                             ClassName = cls.ClassName,
                             Students = studentGroup
                         };

            // Sonuçları ekrana yazdır
            foreach (var group in result)
            {
                Console.WriteLine($"Sınıf: {group.ClassName}");
                foreach (var student in group.Students)
                {
                    Console.WriteLine($"  Öğrenci: {student.StudentName}");
                }
            }

            // Konsolun hemen kapanmaması için bir tuşa basılmasını bekle
            Console.ReadKey();
        }
    }
}