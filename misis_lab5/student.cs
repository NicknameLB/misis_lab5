using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace misis_lab5
{
    class Student
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string Gender { get; set; }
        public int BirthDate { get; set; }
        public string Group { get; set; }
        public int Course { get; set; }
        public Dictionary<string, int> ExamScores { get; set; }

        public Student(string lastName, string firstName, string patronymic, string gender, int birthDate, int course, string group)
        {
            LastName = lastName;
            FirstName = firstName;
            Patronymic = patronymic;
            Gender = gender;
            BirthDate = birthDate;
            Course = course;
            ExamScores = new Dictionary<string, int>();
            Group = group;
        }
    }
}
