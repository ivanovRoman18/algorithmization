// // Задача 1
// // Класс с полями:
// // Номер телефона
// // Оператор
// // Необходимо создать базу данных телефонов
// // и определить с использованием словаря частоту появления каждого оператора (сколько телефонов у каждого оператора)
// // В main создать список из элементов с заданным количеством или пока не ввёдем пустоту
// // Ключ - оператор
// // Значение - подсчёт телефонов с заданным оператором
// // Выдаём оператор: количество повторений
// // Меню не нужно

// using System;
// using System.Collections.Generic;

// // Класс для представления номера телефона
// public class PhoneNumber
// {
//     public string Number { get; set; }
//     public string Operator { get; set; }

//     public PhoneNumber(string number, string @operator)
//     {
//         Number = number;
//         Operator = @operator;
//     }

//     public override string ToString()
//     {
//         return $"Номер: {Number}, Оператор: {Operator}";
//     }
// }

// public class PhoneDatabase
// {
//     public Dictionary<string, int> OperatorCounts { get; private set; }
//     public List<PhoneNumber> PhoneNumbers { get; private set; }

//     public PhoneDatabase()
//     {
//         OperatorCounts = new Dictionary<string, int>();
//         PhoneNumbers = new List<PhoneNumber>();
//     }

//     public void AddPhoneNumber(PhoneNumber phoneNumber)
//     {
//         PhoneNumbers.Add(phoneNumber);

//         if (OperatorCounts.ContainsKey(phoneNumber.Operator))
//         {
//             OperatorCounts[phoneNumber.Operator]++;
//         }
//         else
//         {
//             OperatorCounts[phoneNumber.Operator] = 1;
//         }
//     }

//     public void PrintOperatorStatistics()
//     {
//         Console.WriteLine("Статистика по операторам:");
//         foreach (var pair in OperatorCounts)
//         {
//             Console.WriteLine($"Оператор: {pair.Key}, Количество: {pair.Value}");
//         }
//     }
// }


// public class Program
// {
//     public static void Main(string[] args)
//     {
//         PhoneDatabase database = new PhoneDatabase();

//         Console.WriteLine("Введите номера телефонов и операторов (номер пробел оператор). Для завершения введите пустую строку.");

//         while (true)
//         {
//             string input = Console.ReadLine();

//             if (string.IsNullOrWhiteSpace(input))
//             {
//                 break;
//             }

//             string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

//             if (parts.Length != 2)
//             {
//                 Console.WriteLine("Неверный формат ввода. Пожалуйста, введите номер и оператора через пробел.");
//                 continue;
//             }

//             string number = parts[0];
//             string @operator = parts[1];

//             // Убрали try-catch, считаем, что ввод корректный.
//             PhoneNumber phoneNumber = new PhoneNumber(number, @operator);
//             database.AddPhoneNumber(phoneNumber);
//             Console.WriteLine("Телефон добавлен.");
//         }

//         database.PrintOperatorStatistics();
//     }
// }

// Задача 2
// Имеется класс с двумя переменными целого типа, в котором реализованы 4 метода:
// Сложение
// Вычитание
// Деление (порядок не важен, но проверка на ноль нужна)
// Умножение
// Необходимо с использованием делегата и группировки методов с исходными данными выполнить
// сначала операции в следующем порядке:
// 1. Сложение двух элементов
// 2. Вычитание из суммы второго элемента
// 3. Умножение результата на второй элемент
// Выполнить следующую группу операторов над исходными данными:
// 1. Умножение двух элементов
// 2. Вычитание из произведения первого элемента
// 3. Деление полученного результата на первый элемент
// Можно использовать два делегата
// Объект класса с заданными параметрами, к нему применяем первый делегат
// Ещё один объект с заданными параметрами, к нему применяем второй делегат
// Группировка элементов: делегат += метод

// using System;

// namespace ConsoleApplication2
// {
//     delegate void Eval(Equation eq, ref int result); // Изменили делегат

//     class Equation
//     {
//         public int a { get; set; }
//         public int b { get; set; }

//         public Equation(int a, int b)
//         {
//             this.a = a;
//             this.b = b;
//         }

//         public void Sum(ref int result) // Изменили сигнатуру методов
//         {
//             result = a + b;
//         }

//         public void Dif(ref int result) // Изменили сигнатуру методов
//         {
//             result = result - b;
//         }

//         public void Mult(ref int result) // Изменили сигнатуру методов
//         {
//             result = result * a;
//         }

//         public void Div(ref int result) // Изменили сигнатуру методов
//         {
//             if (a == 0)
//             {
//                 Console.WriteLine("Деление на ноль невозможно");
//                 throw new DivideByZeroException();
//             }
//             result = result / a;
//         }

//         public void MultNumbers(ref int result) // Изменили сигнатуру методов
//         {
//             result = a * b;
//         }

//         public void SubtractFromProduct(ref int result) // Изменили сигнатуру методов
//         {
//             result = result - a;
//         }

//         public void DivideByFirst(ref int result) // Изменили сигнатуру методов
//         {
//             if (a == 0)
//             {
//                 Console.WriteLine("Деление на ноль невозможно");
//                 throw new DivideByZeroException();
//             }
//             result = result / a;
//         }
//     }

//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Equation eq = new Equation(10, 5);

//             Eval op1 = null;
//             op1 += (Equation e, ref int result) => { e.Sum(ref result); };
//             op1 += (Equation e, ref int result) => { e.Dif(ref result); };
//             op1 += (Equation e, ref int result) => { e.Mult(ref result); };

//             int result1 = 0;
//             op1(eq, ref result1); // Передаем и Equation, и result по ссылке

//             Console.WriteLine(result1);

//             Equation eq2 = new Equation(10, 5);


//             Eval op2 = null;
//             op2 += (Equation e, ref int result) => { e.MultNumbers(ref result); };
//             op2 += (Equation e, ref int result) => { e.SubtractFromProduct(ref result); };
//             op2 += (Equation e, ref int result) => { e.DivideByFirst(ref result); };

//             int result2 = 0;
//             op2(eq2, ref result2); // Передаем и Equation, и result по ссылке

//             Console.WriteLine(result2);
//         }
//     }
// }