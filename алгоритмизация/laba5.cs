// Одномерный массив
// Количество элементов вводим с клавиатуры
// Обычный массив. Это не коллекция, не использовать функции относящиеся к коллекции.
// Будут 2 блока с разными циклами, когда вводим и когда проверяем

// 1) определить количество элементов, оканчивающихся на 3
// 3
// -13
// -17
// -3
// Ответ 2

// 2) определить являются ли элементы массива равномерновозрастающей последовательностью
// 123 равномерно
// 12345 равномерно
// 1237 не равномерно

// 3) поменять местами максимальный и минимальный элементы массива (минимум и максимум только один, нет в массива двух повторяющиеся максимальных и минимальных)


// using System;


// namespace project{
//     class Laba5{
//         static void Main(){
//             System.Console.WriteLine("введите размер массива");
//             int n = Convert.ToInt32(Console.ReadLine());
//             int count = 0;
//             int[] num = new int[n];
//             System.Console.WriteLine("вводите элементы массива");
//             for(int i=0; i<n; i++){
                
//                 num[i] = Convert.ToInt32(Console.ReadLine());
//                 if (num[i] %10 ==3){
//                     count+=1;
//                 }
//             }
//             int razn = num[1]-num[0];
//             bool ishappy = true;
//             if (razn>0){
//                 for (int i =1;i<n ;i++){
//                     if((num[i]-num[i-1]) == razn){
//                         ishappy = true;
//                     }
//                     else{
//                         ishappy = false;
//                     }
//                 }
//             }
//             if(ishappy){
//                 System.Console.WriteLine("равномерновозрастаюшая последовательность");
//             }
//             else
//                 System.Console.WriteLine("не является равномерновозрастаюшая последовательность");
            
            
//             Console.WriteLine(count);
//             int c = Array.IndexOf(num, num.Max());
//             int q = Array.IndexOf(num, num.Min());
//             int w = num.Max();
//             num[c] = num[q];
//             num[q] = w;
//             Console.Write("массив с поменянным макс и мин ");
//             Console.WriteLine(string.Join(", ", num));
//         }
//     }
// }


