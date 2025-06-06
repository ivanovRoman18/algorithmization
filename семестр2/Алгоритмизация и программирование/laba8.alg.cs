// // задача 1
// using System;
// using System.Collections.Generic;

// namespace DynamicContainer
// {
//     class ExpandableList<ItemType>
//     {
//         private ItemType[] data;
//         private int itemCount;

//         public ExpandableList()
//         {
//             data = new ItemType[1];
//             itemCount = 0;
//         }

//         public void Append(ItemType newItem)
//         {
//             if (itemCount == data.Length)
//             {
//                 ResizeArray();
//             }
//             data[itemCount] = newItem;
//             itemCount++;
//         }

//         private void ResizeArray()
//         {
//             ItemType[] tempArray = new ItemType[data.Length * 2];
//             Array.Copy(data, tempArray, data.Length);
//             data = tempArray;
//         }

//         public void RemoveAt(int index)
//         {
//             if (index < 0 || index >= itemCount)
//             {
//                 Console.WriteLine("Индекс за пределами допустимого диапазона.");
//                 throw new IndexOutOfRangeException();
//             }

//             for (int i = index; i < itemCount - 1; i++)
//             {
//                 data[i] = data[i + 1];
//             }

//             itemCount--;
//             data[itemCount] = default(ItemType);  // Optional: Null out the last element
//         }

//         public ItemType Retrieve(int index)
//         {
//             if (index < 0 || index >= itemCount)
//             {
//                 Console.WriteLine("Индекс за пределами допустимого диапазона.");
//                 throw new IndexOutOfRangeException();
//             }
//             return data[index];
//         }

//         public int Count
//         {
//             get { return itemCount; }
//         }
//     }

//     class Executor
//     {
//         static void Main(string[] args)
//         {
//             ExpandableList<int> numbers = new ExpandableList<int>();
//             numbers.Append(1);
//             numbers.RemoveAt(0);
//             numbers.Append(2);
//             Console.WriteLine(numbers.Retrieve(0) + "\n");
//             numbers.RemoveAt(0);

//             for (int i = 0; i < 5; i++)
//             {
//                 numbers.Append(i * 2);
//                 Console.WriteLine(numbers.Retrieve(i));
//             }
//             Console.WriteLine("\n" + numbers.Retrieve(3) + "\n");
//             numbers.RemoveAt(3);
//             Console.WriteLine(numbers.Retrieve(3));
//         }
//     }
// }
// задача2
// using System;
// using System.Collections.Generic;

// namespace GenericMath
// {
//     class Calculator<T>
//     {
//         public T Add(T x, T y)
//         {
//             return (dynamic)x + (dynamic)y;
//         }

//         public T Subtract(T x, T y)
//         {
//             return (dynamic)x - (dynamic)y;
//         }

//         public T Multiply(T x, T y)
//         {
//             return (dynamic)x * (dynamic)y;
//         }

//         public T Divide(T x, T y)
//         {
//             try
//             {
//                 if (EqualityComparer<T>.Default.Equals(y, default(T)))
//                 {
//                     Console.WriteLine("Деление на ноль!");
//                     throw new DivideByZeroException();
//                 }
//                 return (dynamic)x / (dynamic)y;
//             }
//             catch (DivideByZeroException)
//             {
//                 return default(T); // Или любое другое значение по умолчанию
//             }
//         }
//     }

//     class EntryPoint
//     {
//         static void Main(string[] args)
//         {
//             Calculator<int> intOps = new Calculator<int>();
//             Console.WriteLine(intOps.Add(10, 2));
//             Console.WriteLine(intOps.Subtract(10, 2));
//             Console.WriteLine(intOps.Multiply(10, 2));
//             Console.WriteLine(intOps.Divide(10, 2) + "\n");

//             Calculator<double> doubleOps = new Calculator<double>();
//             Console.WriteLine(doubleOps.Add(7.5, 2.5));
//             Console.WriteLine(doubleOps.Subtract(7.5, 2.5));
//             Console.WriteLine(doubleOps.Multiply(7.5, 2.5));
//             Console.WriteLine(doubleOps.Divide(7.5, 2.5) + "\n");

//             // Теперь деление на ноль не вызывает исключение глобально
//             Console.WriteLine(doubleOps.Divide(7.5, 0));
//         }
//     }
// }