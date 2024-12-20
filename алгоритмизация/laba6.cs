// Работаем с двумерным массивов
// Массив размерностью m на n
// Количество строк и столбцов задаётся с клавиатуры. Сортировкой пользоваться нигде нельзя

// 1) необходимо определить пары номеров столбцов, состоящих из одинаковых элементов
// Если столбец 211 112 то это одинаковые
// 112 и 211, т.к. количественный и качественный состав одинаковые 
// Сумма равна, произведение равно, количество нулей

// 2) необходимо отсортировать строки по убыванию количества нулевых элементов в строках
// На первое место встанет строка с наим. Количество нулевых элементов, а на последнем с нами меньшим количеством нулевых элементов

// Стандартными методами сортировки пользоваться нельзя

// 3) необходимо в массиве поменять местами максимальный и минимальный элементы массива (максимум и минимум  только 1). Всё тоже самое, что и ранее, но в двумерном массиве




// using System;
// class Laba6
// {
//   static void Main() 
//   {
//     int m = Convert.ToInt32(Console.ReadLine());
//     int n = Convert.ToInt32(Console.ReadLine());
//     int[,] massiv = new int[m, n];
    
    
//     for (int i = 0; i < m; i++) 
//     {
//       for (int j = 0; j < n; j++)
//       {
//         massiv[i, j] = Convert.ToInt32(Console.ReadLine());
//       }
//     }
    
    
//     for (int column1 = 0; column1 < n - 1; column1++) 
//         {
//             for (int column2 = column1 + 1; column2 < n; column2++) 
//             {
//                 int sum1 = 0, sum2 = 0;
//                 int prod1 = 1, prod2 = 1;
//                 int zero_counter_1 = 0, zero_counter_2 = 0;

//                 for (int row = 0; row < m; row++) 
//                 {
//                     int perevemuty_massiv_1 = massiv[row, column1];
//                     int perevemuty_massiv_2 = massiv[row, column2];

//                     sum1 += perevemuty_massiv_1;
//                     sum2 += perevemuty_massiv_2;


//                     if (perevemuty_massiv_1 != 0)
//                     {
//                         prod1 *= perevemuty_massiv_1;
//                     }
//                     if (perevemuty_massiv_2 != 0)
//                     {
//                         prod2 *= perevemuty_massiv_2;
//                     }


//                     if (perevemuty_massiv_1 == 0) 
//                     {
//                         zero_counter_1 += 1;
//                     }
//                     if (perevemuty_massiv_2 == 0)
//                     {
//                         zero_counter_2 += 1;
//                     }
                    

//                 }


//                 if ((sum1 == sum2) && (prod1 == prod2) && (zero_counter_1 == zero_counter_2)) 
//                 {
//                     Console.WriteLine($"Совпадают столбцы: {column1 + 1} и {column2 + 1}");
//                 }
//             }   
//         }
//     }
// }



// using System;
// class Laba6
// {
//     static void Main() 
//     {
//         int m = Convert.ToInt32(Console.ReadLine());
//         int n = Convert.ToInt32(Console.ReadLine());
//         int[,] massiv = new int[m, n];
    
//         int mmax = 0, mmin = n + 1;
//         for (int i = 0; i < m; i++) 
//         {
//             for (int j = 0; j < n; j++)
//             {
//                 massiv[i, j] = Convert.ToInt32(Console.ReadLine());
                
                
//                 if (massiv[i, j] > mmax)
//                 {
//                     mmax = massiv[i, j];
//                 }
//                 if (massiv[i, j] < mmin)
//                 {
//                     mmin = massiv[i, j];
//                 }
//             }
//         }
        
        
//         int[] massiv_zero = new int[m];
//         for (int i = 0; i < m; i++)
//         {
//             int counter = 0;
//             for (int j = 0; j < n; j++)
//             {
//                 if (massiv[i, j] == 0)
//                 {
//                     counter += 1;
//                 }
//             }
//             massiv_zero[i] = counter;
//         }
        
//         for (int i = 0; i < m - 1; i++)
//         {
//             for (int j = i + 1; j < m; j++)
//             {
//                 if (massiv_zero[i] < massiv_zero[j])
//                 {
//                     for (int k = 0; k < n; k++)
//                     {
//                         int vrenemennyi_massiv = massiv[i, k];
//                         massiv[i, k] = massiv[j, k];
//                         massiv[j, k] = vrenemennyi_massiv;
//                     }
//                     int vrenemennyi_massiv_zero = massiv_zero[i];
//                     massiv_zero[i] = massiv_zero[j];
//                     massiv_zero[j] = vrenemennyi_massiv_zero;
//                 }
//             }
//         }

        
        
//         for (int i = 0; i < m; i++)
//         {
//             for (int j = 0; j < n; j++)
//             {
//                 Console.Write($"{massiv[i, j]} \t");
//             }
//                 Console.WriteLine();
//         }
//     }
// }


// using System;

// namespace Project{
//     class Laba6{
//         public static void Main(string[] args){
//             Console.WriteLine("Введите количество строк:");
//             int n = Convert.ToInt32(Console.ReadLine());
//             Console.WriteLine("Введите количество столбцов:");
//             int m = Convert.ToInt32(Console.ReadLine());

//             int[,] nums = new int[n,m];
            
//             Console.WriteLine("исходный массив:");
//             for (int i= 0; i<n; i++){
//                 for (int j=0; j<m;j++){
//                     nums[i,j] = Convert.ToInt32(Console.ReadLine());
//                     Console.Write(nums[i,j] + " ");
//                 }
//                 Console.WriteLine();
//             }

//             int temp;
//             for (int i = 0; i<n;i++){
//                 int minvalue = 11111111;
//                 int maxvalue = -11111111;
                
//                 int maxstolb = -111111;
//                 int minstolb = 1111111;

//                 for (int j=0;j<n;j++){
//                     if (nums[i,j]<minvalue){
//                         minvalue = nums[i,j];
//                         minstolb = j;
//                     }
//                     if (nums[i,j]>maxvalue){
//                         maxvalue = nums[i,j];
//                         maxstolb = j;

//                     }

//                 }
//                 temp = nums[i,minstolb];
//                 nums[i,minstolb]= nums[i,maxstolb];
//                 nums[i,maxstolb]= temp;

//             }
        
//             System.Console.WriteLine(" массив с поменняным макс и мин значением в каждой строке");
//             for (int i =0; i<n; i++){
//                 for (int j=0; j<m; j++){
//                     Console.Write(nums[i,j] + " ");
//                 }
//                 System.Console.WriteLine();
//             }

//             int[] array = new int[n];
//             for (int i = 0;i<n;i++){

//             }
//         }
//     }
// }
