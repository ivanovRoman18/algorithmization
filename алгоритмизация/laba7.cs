// Зубчатый массив. Каждый элемент может иметь свою размерность

// Необходимо создать массив, состоящий из n одномерных массивов разной длины, заполнение каждого одномерного массива выполнить с помощью функции. 

// В каждом одномерном массиве (в каждой строке массива) определить максимальный и минимальный элемент.

// Функцией макс и минимум пользоваться нельзя, пользоваться ручками

// Если один элемент, то он и минимум и максимум

// Три строки
// 3 элеметна 123
// 2 элеметна 22
// 5 элементов 1 -2 -2 -3 -4

// using System;
// using System.Globalization;
// using System.Net.NetworkInformation;
// using System.Runtime.InteropServices;
// using System.Security.Cryptography.X509Certificates;

// namespace Project{
//     class Laba7{
//         static void Main(){
//             System.Console.WriteLine("введите количество одномерных массивов");
//             int n = Convert.ToInt32(Console.ReadLine());
//             int[][] myArray = new int[n][];
//             Console.WriteLine(myArray.Length);

//             for (int i =0; i<n;i++){
//                 int q =i+1;
//                 System.Console.WriteLine($"Введите количество элементов в {q} строчке");
//                 int p = Convert.ToInt32(Console.ReadLine());
//                 myArray[i] = new int[p];
//                 for (int j =0; j<p;j++ ){
//                     // заполнение массива через функцию 
//                     myArray[i][j] =  Print(); 
                
//                 }
//                 int maxvalue = -1111111;
//                 int minvalue = 11111111;
//                 foreach(int el in myArray[i]){
//                     if (el>maxvalue){
//                         maxvalue = el;
//                     }
//                     if (el <minvalue){
//                         minvalue = el;
//                     }
//                 }
//                 System.Console.Write($"минимальное и максимальное значение в {q} стрчоке : ");
//                 System.Console.Write(maxvalue);
//                 System.Console.WriteLine(" "+ minvalue);
                
//             }
            
            
//             for (int i =0; i<n;i++){
//                 for (int j=0; j<myArray[i].Length;j++){
//                     Console.Write(myArray[i][j] + " ");

//                 }
//                 Console.WriteLine();
//             }
            
//         }

        
//         public static int Print(){
//             Random random = new Random();
//             return random.Next(100);
//             }
//     }

// }


