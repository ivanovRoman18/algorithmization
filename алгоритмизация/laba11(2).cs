// Задача 2

// Студент
// 1 Класс - "оценки" (Поля: наименование учебного предмета, оценка)
// 2 Класс - "студет" (Поля: ФИО, массив(или список) из объектов класса "оценки")
// 1 Выборка(если база из студентов заполнена) - выдать всех студентов, у которых средний балл выше, чем 4.5.
// Выход

using System;

class Grade
{
    public string Subject { get; set; }
    public double Score { get; set; }

    public Grade(string subject, double score)
    {
        Subject = subject;
        Score = score;
    }
}

class Student
{
    public string FullName { get; set; }
    public Grade[] Grades { get; set; }

    public Student(string fullName, Grade[] grades)
    {
        FullName = fullName;
        Grades = grades;
    }

    public double CalculateAverageGrade()
    {
        if (Grades == null || Grades.Length == 0)
        {
            return 0; // Возвращаем 0, если оценок нет
        }

        return Grades.Average(g => g.Score);
    }
}

class Program
{
    static List<Student> studentDatabase = new List<Student>();

    static void Main(string[] args)
    {
        int choice = 0;
        while (choice != 2)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Добавить студента");
            Console.WriteLine("2. Выход");
            Console.Write("Выберите пункт: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Неверный ввод. Пожалуйста, введите число.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    DisplayStudentsAboveAverage();
                    Console.WriteLine("Программа завершена.");
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, выберите пункт от 1 до 2.");
                    break;
            }
        }
    }

    static void AddStudent()
    {
        Console.Write("Введите ФИО студента: ");
        string fullName = Console.ReadLine();

        Console.Write("Сколько оценок у студента? ");
        if (!int.TryParse(Console.ReadLine(), out int numGrades) || numGrades <= 0)
        {
            Console.WriteLine("Неверный ввод. Пожалуйста, введите положительное целое число.");
            return;
        }

        Grade[] grades = new Grade[numGrades];
        for (int i = 0; i < numGrades; i++)
        {
            Console.Write($"Введите предмет и оценку №{i + 1} (Предмет Оценка): ");
            string input = Console.ReadLine();

            //  Обработка ввода
            string[] parts = input.Split(' ');
            if (parts.Length != 2 || !double.TryParse(parts[1], out double score))
            {
                Console.WriteLine("Неверный ввод. Пожалуйста, введите предмет и оценку в формате 'Предмет Оценка'.");
                i--;  //Повтор ввода для текущего студента
                continue; //Перейти к следующей итерации цикла
            }
            grades[i] = new Grade(parts[0], score);
        }

        Student newStudent = new Student(fullName, grades);
        studentDatabase.Add(newStudent);
        Console.WriteLine($"Студент {fullName} добавлен.");
    }

    static void DisplayStudentsAboveAverage()
    {
        if (studentDatabase.Count == 0)
        {
            Console.WriteLine("База данных студентов пуста.");
            return;
        }
        Console.WriteLine("Студенты со средним баллом выше 4.5:");
        foreach (Student student in studentDatabase)
        {
            double averageGrade = student.CalculateAverageGrade();
            if (averageGrade > 4.5)
            {
                Console.WriteLine($"{student.FullName}: {averageGrade:F2}");
            }
        }
    }
}