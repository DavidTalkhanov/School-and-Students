using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    public enum Education
    {
        младшая,
        средняя,
        старшая
    }
    public class Student
    {
        private static Random random = new Random();
        private static char fio = 'A';
        public static Random rnd;
        public string FIO { get; set; }
        public int Grade { get; set; }
        public double Perfomance { get; set; }
        public Education Stage { get; set; }
        public Student()
        {
            Grade = random.Next(1, 11);
            FIO = Convert.ToChar(fio).ToString();
            Perfomance = Math.Round(random.NextDouble() * 5, 1);
            if (fio < 'Z')
                fio++;
            else
                fio = 'A';
            EducationStage();
        }
        public Student(string fio, int grade, double perfomance)
        {
            FIO = fio;
            Grade = grade;
            Perfomance = perfomance;
            EducationStage();
        }
        public void Pass()
        {
            Grade = Grade + 1;
            EducationStage();
        }
        public override string ToString()
        {
            return $"{FIO}, {Stage} школа, {Grade} класс, {Perfomance} балла";
        }
        private void EducationStage()
        {
            if (Grade >= 1 && Grade <= 4)
            {
                Stage = Education.младшая;
            }
            else if (Grade >= 5 && Grade <= 8)
            {
                Stage = Education.средняя;
            }
            else
            {
                Stage = Education.старшая;
            }
        }
    }
    public class School
    {
        public string Name { get; set; }
        List<Student> Students = new List<Student>();
        public School(string name)
        {
            Name = name;
        }
        public void Add(Student student)
        {
            Students.Add(student);
        }
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Students.Count; i++)
            {
                result += $"{i + 1}. {Students[i]}\n";
            }
            return result;
        }
        public void Sort(int i)
        {
            Students = Students.OrderBy(s => s.Grade).OrderBy(s => s.FIO[0]).ToList();
        }

        public void Sort()
        {
            Students = Students.OrderBy(s => s.FIO[0]).ToList();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student studA = new Student();
            Student studB = new Student();
            Student studBagaev = new Student("Багаев Аслан", 4, 4);
            Student studAbaev = new Student("Абаев Георгий", 7, 3.4);
            Student studAtaev = new Student("Атаев Сослан", 5, 3);

            School school = new School("ФизМат");
            school.Add(studB);
            school.Add(studBagaev);
            school.Add(studAbaev);
            school.Add(studA);
            school.Add(studAtaev);
            Console.WriteLine(school);

            school.Sort();

            Console.WriteLine(school);
        }
    }
}
