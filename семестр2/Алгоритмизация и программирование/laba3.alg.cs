// Задача 1
// На вход подаётся последовательность, состоящая из чисел, знаков математических и трёх видов скобок (, [, {.
// Определить правильно ли расставлены скобки в заданной последовательности с использованием элемента стэк.
// Ничего кроме скобок не интересует - считываем скобки.
// Если скобка открывающаяся - помещаем в стэк, если закрывающаяся - берём верхушку и проверяем, парные ли они.
// Перед этим проверяем не пусти ли стэк.
// Стэк в конце должен быть пуст.
// Классическая задача на работу со стэком.
// Результат: вывести верно или нет.

// using System;
// using System.Collections.Generic;

// public class BracketValidator
// {
//     public static bool IsValid(string input)
//     {
//         Stack<char> stack = new Stack<char>();

//         foreach (char c in input)
//         {
//             switch (c)
//             {
//                 case '(':
//                 case '[':
//                 case '{':
//                     stack.Push(c);
//                     break;

//                 case ')':
//                     if (stack.Count == 0 || stack.Pop() != '(')
//                     {
//                         return false;
//                     }
//                     break;

//                 case ']':
//                     if (stack.Count == 0 || stack.Pop() != '[')
//                     {
//                         return false;
//                     }
//                     break;

//                 case '}':
//                     if (stack.Count == 0 || stack.Pop() != '{')
//                     {
//                         return false;
//                     }
//                     break;
//             }
//         }

//         return stack.Count == 0; // Stack should be empty at the end
//     }

//     public static void Main(string[] args)
//     {
//         Console.WriteLine("Введите последовательность скобок:");
//         string input = Console.ReadLine();

//         if (IsValid(input))
//         {
//             Console.WriteLine("Верно");
//         }
//         else
//         {
//             Console.WriteLine("Неверно");
//         }
//     }
// }


// задача 2
// using System;
// using System.Collections.Generic;

// public class PostfixEvaluator
// {
//     public static int Evaluate(string expression)
//     {
//         Stack<int> stack = new Stack<int>();
//         string[] tokens = expression.Split(' ');

//         foreach (string token in tokens)
//         {
//             if (int.TryParse(token, out int number))
//             {
//                 stack.Push(number);
//             }
//             else if (IsOperator(token))
//             {
//                 if (stack.Count < 2)
//                 {
//                     throw new InvalidOperationException("Неверная польская запись: недостаточно операндов.");
//                 }

//                 int operand2 = stack.Pop();
//                 int operand1 = stack.Pop();

//                 int result = PerformOperation(operand1, operand2, token);
//                 stack.Push(result);
//             }
//             else
//             {
//                 throw new ArgumentException($"Неверный токен: {token}");
//             }
//         }

//         if (stack.Count == 0)
//         {
//             throw new InvalidOperationException("Неверная польская запись: нет результата.");
//         }

//         if (stack.Count > 1)
//         {
//             throw new InvalidOperationException("Неверная польская запись: слишком много операндов.");
//         }

//         return stack.Pop();
//     }

//     private static bool IsOperator(string token)
//     {
//         return token == "+" || token == "-" || token == "*" || token == "/";
//     }

//     private static int PerformOperation(int operand1, int operand2, string @operator)
//     {
//         switch (@operator)
//         {
//             case "+":
//                 return operand1 + operand2;
//             case "-":
//                 return operand1 - operand2;
//             case "*":
//                 return operand1 * operand2;
//             case "/":
//                 if (operand2 == 0)
//                 {
//                     throw new DivideByZeroException("Деление на ноль.");
//                 }
//                 return operand1 / operand2;
//             default:
//                 throw new ArgumentException($"Неподдерживаемый оператор: {@operator}");
//         }
//     }

//     public static void Main(string[] args)
//     {
//         Console.WriteLine("Введите выражение в польской записи:");
//         string expression = Console.ReadLine();

//         try
//         {
//             int result = Evaluate(expression);
//             Console.WriteLine($"Результат: {result}");
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine($"Ошибка: {ex.Message}");
//         }
//     }
// }