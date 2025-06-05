// Обобщённые коллекции
// Дан список элементов (лист) целого типа
// Необходимо
// 1) Определить с помощью каких элементов составлен список
// (Работаем Хешсетом HashSet)
// 2) Какой элемент чаще всего присутствует в списке (если таких несколько, то выдать все)
// (Использовать словарь Dictionary)


// using System;
// using System.Collections.Generic;
// using System.Linq;

// public class CollectionAnalyzer
// {
//     public static void AnalyzeList(List<int> list)
//     {
//         // 1) Определить уникальные элементы с помощью HashSet
//         HashSet<int> uniqueElements = new HashSet<int>(list);
//         Console.WriteLine("Уникальные элементы в списке:");
//         foreach (int element in uniqueElements)
//         {
//             Console.Write(element + " ");
//         }
//         Console.WriteLine();

//         // 2) Определить наиболее часто встречающиеся элементы с помощью Dictionary
//         Dictionary<int, int> elementCounts = new Dictionary<int, int>();
//         foreach (int element in list)
//         {
//             if (elementCounts.ContainsKey(element))
//             {
//                 elementCounts[element]++;
//             }
//             else
//             {
//                 elementCounts[element] = 1;
//             }
//         }

//         // Находим максимальное количество повторений
//         int maxCount = 0;
//         foreach (var pair in elementCounts)
//         {
//             if (pair.Value > maxCount)
//             {
//                 maxCount = pair.Value;
//             }
//         }

//         // Собираем элементы, которые встречаются максимальное количество раз
//         List<int> mostFrequentElements = new List<int>();
//         foreach (var pair in elementCounts)
//         {
//             if (pair.Value == maxCount)
//             {
//                 mostFrequentElements.Add(pair.Key);
//             }
//         }

//         Console.WriteLine("Наиболее часто встречающиеся элементы:");
//         foreach (int element in mostFrequentElements)
//         {
//             Console.Write(element + " ");
//         }
//         Console.WriteLine();
//     }

//     public static void Main(string[] args)
//     {
//         List<int> numbers = new List<int>();
//         Console.WriteLine("Введите элементы списка (целые числа), разделенные пробелами:");
//         string input = Console.ReadLine();

//         // Разделяем введенную строку на отдельные числа
//         string[] numberStrings = input.Split(' ');

//         // Преобразуем строки в числа и добавляем в список
//         foreach (string numberString in numberStrings)
//         {
//             if (int.TryParse(numberString, out int number))
//             {
//                 numbers.Add(number);
//             }
//         }

//         Console.WriteLine("Исходный список: " + string.Join(", ", numbers));
//         AnalyzeList(numbers);
//     }
// }