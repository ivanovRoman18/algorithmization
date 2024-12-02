// // задачи дана последовательно из n элементов 1- определитьь минимальый размер поподследовательности состоящий из 1,
// // 2-определить максимальный размер подпоследовательности, состоящий из одинаковых чётных элементов
// // 3-необходимо определить максимальную сумму подпоследовательности состящей из чётных элементов (целые числа)

// using System;
// using System.Runtime.Intrinsics.Arm;

// namespace project{
//     class Laba3{
//         static void Main(){
//             int n = Convert.ToInt32(Console.ReadLine());
//             int minimcurrent1 = 0;
//             int minimcurrent2 = 999999999;
//             int mini= 0;
//             for( int i = 0; i<n; i++){
//                 int el = Convert.ToInt32(Console.ReadLine());
//                 if(el ==1){
//                     minimcurrent1+=1;
//                     mini = Math.Min(minimcurrent1,minimcurrent2);
//                 }
//                 else{
//                     minimcurrent2 = minimcurrent1;
//                     minimcurrent1 = 0;
//                 }
            
//             }
//             Console.WriteLine("ответ на первый вопрос {0}", mini);
//         }
//     }
// }

// using System;

// namespace project{
//     class Laba3{
//         static void Main(){
//             int n = Convert.ToInt32(Console.ReadLine());
//             int maxim = 0;
//             int current = 1;
//             int el1 = Convert.ToInt32(Console.ReadLine());
//             for (int i=1;i<n;i++){               
//                 int el2 = Convert.ToInt32(Console.ReadLine());
//                 if (el1%2==0 && el2%2==0 && el1==el2){
//                     current++;
//                     maxim = Math.Max(maxim,current);
                    
//                 }
//                 else{
//                     current = 1;
//                 }
//                 el1 = el2;

            
//             }
//             Console.WriteLine(maxim);
//         }
//     }
// }



using System;

namespace project{
    class Laba3{
        static void Main(){
            int n = Convert.ToInt32(Console.ReadLine());
            int maxim = 0;
            int current = 0;
            int el1 = Convert.ToInt32(Console.ReadLine());
            if (el1%2==0){
                    current = el1;
                    maxim = Math.Max(maxim,current);
            
            for (int i=1;i<n;i++){               
                int el2 = Convert.ToInt32(Console.ReadLine());
                if (el2%2==0){
                    current+=el2;
                    maxim = Math.Max(maxim,current);
                }
                else{
                    current = 0;
                }
                
                }
            }
            Console.WriteLine(maxim);
        }
    }
}