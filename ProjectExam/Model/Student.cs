using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace ProjectExam.Model
{
    
    class Student : Person, IComparable<Student>
    {
        public static readonly string xmlFile = @"C:\Users\henri\OneDrive\Semester5\C#\App\Exam\ProjectExam\ProjectExam\Student.xml";
        public static readonly string txtFile = @"C:\Users\henri\OneDrive\Semester5\C#\App\Exam\ProjectExam\ProjectExam\Student.txt";

        public int StudentId { get; set; }


        public Student(string firstName, string lastName, int phoneNumber) : base(firstName, lastName, phoneNumber)
        {

        }

        public Student(int studentId, string firstName, string lastName, int phoneNumber) : base(firstName, lastName, phoneNumber)
        {
            StudentId = studentId;
        }


        public int CompareTo(Student? other)
        {
            if (other == null) throw new Exception("Student er null");
            return StudentId - other.StudentId;
        }

        public static ObservableCollection<Student> GetList()
        {
            ObservableCollection<Student> students = new ObservableCollection<Student>();
            string[] text = File.ReadAllLines(txtFile);
            foreach (string s in text)
            {
                string[] student = s.Split(';');
                students.Add(new Student(Convert.ToInt32(student[0]), student[1], student[2], Convert.ToInt32(student[3])));
            }

            return students;
        }

        public static void SaveList(ObservableCollection<Student> students)
        {
            //Kan bruke FileStream og kan caste outputFile til IDisosable og kjøre metoden dispose
            using (StreamWriter outputFile = new StreamWriter(txtFile))
            {
                foreach (Student s in students)
                {
                    outputFile.WriteLine(s.StudentId + ";" + s.FirstName + ";" + s.LastName + ";" + s.PhoneNumber);
                }
                outputFile.Dispose();
            }
        }

        public static void SaveListXML(ObservableCollection<Student> students)
        {
            XDocument doc = new XDocument();
            doc.Add(new XElement("Students", GetList().Select(student => new XElement("Student",
                new XAttribute("StudentId", student.StudentId),
                new XAttribute("FirstName", student.FirstName),
                new XAttribute("LastName", student.LastName),
                new XAttribute("PhoneNumber", student.PhoneNumber)
                ))));
            doc.Save(xmlFile);
        }

        public static ObservableCollection<Student> GetListXML()
        {
            ObservableCollection<Student> students = new ObservableCollection<Student>();
            XElement getFile = XElement.Load(xmlFile);
            foreach (XElement student in getFile.Elements())
            {
                students.Add(new Student(
                    int.Parse(student.Attribute("StudentId").Value),
                    student.Attribute("FirstName").Value,
                    student.Attribute("LastName").Value,
                    int.Parse(student.Attribute("PhoneNumber").Value)
                    ));
            }
            return students;
        }
    }
}
