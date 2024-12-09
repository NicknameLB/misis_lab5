using Microsoft.VisualBasic;
using System;
using System.Text.RegularExpressions;

namespace misis_lab5
{
    class Program
    {
        static List<Student> students = new List<Student>();
        static int year = 19;
        static string AssignGroup(int y)
        {
            string year = y.ToString();
            Random random = new Random();
            string[] groups = { $"БИСТ-{year}", $"БИВТ-{year}", $"БПИ-{year}" };
            return groups[random.Next(groups.Length)];
        }

        static void Main()
        {
            int N = 10; // Количество абитуриентов, поступающих каждый год
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Год {i + 1}:");
                year++;
                PromoteStudents();
                AddFreshmen(N);
                RemoveGraduatedStudents();
                DisplayStudents();
                Console.WriteLine();
            }

            FindMatchingStudents();
        }

        static void AddFreshmen(int count)
        {
            Random random = new Random();
            string[] MlastName = {"Кадыров", "Ларионов", "Макаренков", "Романов", "Мухачев"};
            string[] MfirstName = {"Алексей", "Максим", "Андрей", "Олег", "Егор"};
            string[] Mpatronymic = {"Антонович", "Иванов", "Сергеевич", "Вячеславович", "Андреевич"};
            string[] FlastName = {"Смирнова", "Колесникова", "Ганат", "Панченко", "Парамонова"};
            string[] FfirstName = {"Настя", "Полина", "Валерия", "Александра", "Виктория"};
            string[] Fpatronymic = {"Викторовна", "Андреевна", "Иванова", "Анекдотовна", "Йоу"};
            for (int i = 0; i < count; i++)
            {
                string lastName = (i % 2 == 0) ? MlastName[random.Next(MlastName.Length)]: FlastName[random.Next(FlastName.Length)];
                string firstName = (i % 2 == 0) ? MfirstName[random.Next(MfirstName.Length)] : FfirstName[random.Next(FfirstName.Length)];
                string patronymic = (i % 2 == 0) ? Mpatronymic[random.Next(Mpatronymic.Length)] : Fpatronymic[random.Next(FfirstName.Length)];
                string gender = (i % 2 == 0) ? "М" : "Ж";
                int birthDate = random.Next(1983 + year, 1985 + year);
                string group = AssignGroup(year);
                Student newStudent = new Student(lastName, firstName, patronymic, gender, birthDate, 1, group);
                students.Add(newStudent);
            }
        }

        static void PromoteStudents()
        {
            foreach (var student in students)
            {
                if (student.Course < 4) // Если студент не на 4 курсе
                {
                    student.Course++;
                }
            }
        }

        static void RemoveGraduatedStudents()
        {
            students.RemoveAll(s => s.Course == 4); // Удаляем студентов на 4 курсе
        }

        static void DisplayStudents()
        {
            foreach (var student in students)
            {
                Console.WriteLine($"ФИО: {student.LastName} {student.FirstName} {student.Patronymic}, Пол: {student.Gender}, " +
                                  $"Дата рождения: {student.BirthDate}, Группа: {student.Group}, " +
                                  $"Курс: {student.Course}");
            }
        }

        static void FindMatchingStudents()
        {
            Console.WriteLine("Студенты с совпадающими фамилией и отчеством (разница в возрасте не более 4 лет):");
            List<Student> matchedStudents = new List<Student>();
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Gender == "М")
                {
                    for (int j = i + 1; j < students.Count; j++)
                    {
                        if (students[i].LastName == students[j].LastName && students[i].Patronymic == students[j].Patronymic &&
                            students[j].Gender == "М" &&  Math.Abs(students[i].BirthDate - students[j].BirthDate) < 4)
                        {
                            if (!matchedStudents.Contains(students[i]))
                                matchedStudents.Add(students[i]);
                            if (!matchedStudents.Contains(students[j]))
                                matchedStudents.Add(students[j]);
                        }
                    }
                }
            }

            // Выводим всех подходящих студентов
            foreach (var student in matchedStudents)
            {
                Console.WriteLine($"ФИО: {student.LastName} {student.FirstName} {student.Patronymic}, " +
                                  $"Дата рождения: {student.BirthDate}");
            }

            if (matchedStudents.Count == 0)
            {
                Console.WriteLine("Подходящих студентов не найдено.");
            }
        }
    }
}