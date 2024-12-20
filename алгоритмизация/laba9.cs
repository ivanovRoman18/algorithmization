// 1) На вход подаётся строка, состоящая из заглавных букв латинского алфавита

// Необходимо определить максимальную длину подстроки, состоящую из последовательности элемента xyz (в том порядка, как она перечислила). При этом допускается неполная комбинация xyz (xy, x), но только в конце!!!

// Допускается строка x, тогда длина 1
// xy - длина 2
// Элементы идут слитно


// 2) Дана строка состоящая из латинских букв.
//  Необходимо определить символ, который реже всего встречается в образце а*b, где * - искомый символ (символ должен присутствовать хотя бы 1). Если таких символов несколько - выдать все
// А и B могут быть большими и маленькими

// Коллекции мы не знаем

// using System;

// namespace Project{
//     class Laba9{
//         static void Main(){
//             Console.WriteLine("введите строку");
//             string text = Console.ReadLine();
//             int count = 0;
//             int countcur =0;
//             for (int i=0; i<text.Length-2; i++){
//                 if (text.Substring(i, 3) == "XYZ"){
//                     countcur+=3;
//                     if (countcur>count){
//                         count=countcur;
//                     }
//                     i+=2;
//                 }
//                 else{
//                     countcur=0;
//                 }
//             }
//             if (text[text.Length-1]=='Y' & text[text.Length-2]=='X')
//                 count+=2;
//             if (text[text.Length-1]=='X'){
//                 count++;
//             }
//         System.Console.WriteLine(count);
//         }
//     }
// }


// using System;
// using System.Threading.Tasks.Dataflow;
// namespace Project{
//     class Laba9{
//         static void Main(){
//             int[] kol = new int[123];
//             Console.WriteLine("введите строку");
//             string text = Console.ReadLine();
//             for (int i =0; i<text.Length; i++){
//                 if(text[i]=='a' || text[i]=='A'){
//                     while(text[i]!='b' & text[i]!='B'){
//                         if(text[i]!='a' & text[i]!='A' ){ 
//                             kol[(int)text[i]]+=1;                            
//                         }
//                         i++;
//                     }
//                     if (text[i]=='b' || text[i]=='B'){
//                         i--;
//                     }
//                 }
//             }
//             int minim = 110;
//             int index=0;
//             foreach(int el in kol){
//                 if (el!=0){
//                     if (el<minim){
//                         minim = el; 
//                         index = Array.IndexOf(kol, el);
//                     }
//                 }
//             }
//             System.Console.WriteLine((char)index);

//         }
//     }
// }





