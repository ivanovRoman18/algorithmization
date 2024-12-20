// // Работа со строками
// // на вход подаётся строка, состоящая из слов, между которыми, от одного и более пробелов

// // Строка только с латинскими буквами, английский алфавит, большая и маленькая буква - одинаковый символ

// // Можно использовать любые методы для строк, сплит тоже

// // 1)Необходимо отформатировать строку таким образом, чтобы между словами было по одному пробел.
// // В начале и конце лишних пробелов нет, только между словами

// // 2) необходимо определить количество слов, которых на чётных местах стоят гласные буквы.
// // Рассматриваем место с точки зрения пользователя, слово из 5 символов, то первая буква, вторая буква и т.д. с 1 счёт
// // Гласные могут находиться на нечетных местах тоже, но все четные должны быть гласными

// // 3) определить количество слов, длинна которых нечетная, а первый и последний символ совпадают

// // 4)Выдать все слова, в которых присутствует хотя бы один символ "а"


// using System;
// using System.Formats.Asn1;
// using System.Runtime.ConstrainedExecution;

// namespace Project{
//     class Laba8{
//         static void Main(){
//             string text = Console.ReadLine();
//             int count = 0;
//             int count1 =0;
//             string[] words = text.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
//             text = String.Join(" ", words);
//             foreach (string el in words){
//                 if (el.ToLower().Contains('а')){
//                     System.Console.WriteLine(el);
//                 }

//                 if (el.Length%2!=0){
//                     if (el[0]==el[el.Length-1]){
//                         count1++;
//                     }
//                 }
//                 bool q = true;
//                     for (int i = 1; i < el.Length; i += 2){
//                         if ("аеёиоуыэюя".Contains(el[i]))
//                             q = true;
                        
//                         else
//                             q  = false;
                        
//                     }
//                     if (q==true)
//                     count++;
                
//             }
//         Console.WriteLine("строка без  лишних пробелов");
//         System.Console.WriteLine(text);
//         Console.WriteLine("количество слов где на чётных местах гласные");
//         System.Console.WriteLine(count);
//         Console.WriteLine("количество слов  длинна которых нечетная, а первый и последний символ совпадают");
//         System.Console.WriteLine(count1);
//         }
//     }
// }

