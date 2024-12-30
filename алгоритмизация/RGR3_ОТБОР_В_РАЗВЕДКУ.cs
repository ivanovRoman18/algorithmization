// using System;
// // отбор в разведку.
// public class ReconGroups
// {
//     public static void Main(string[] args)
//     {
//          int n = int.Parse(Console.ReadLine());
//          int count = 0;
//          int[] sizes = new int[100000];
//          int head = 0;
//          int tail = 0;
//          sizes[tail++] = n;


//         while (head < tail)
//         {
//             int currentSize = sizes[head++];

//             if(currentSize <= 0)
//                 continue;

//             if (currentSize == 3)
//             {
//                 count++;
//             }
//             else if (currentSize > 3)
//             {
//                 int evenCount = (currentSize + 1) / 2;
//                 int oddCount = currentSize / 2;
//                  sizes[tail++] = evenCount;
//                  sizes[tail++] = oddCount;
//             }
//         }
//         Console.WriteLine(count);
//     }
// }