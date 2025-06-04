// Алгоритм 1
// 1. Список вершин
// 2. Выбираем любую и вычеркиваем из первого списка
// 3. Во втором списке выписываем вершину и все связанные с ней
// 4. Переходим к следующему элементу второго списка и повторяем действие 3
// 5. Если первый список не пуст, то создаём новый список и повторяет всё
// Если одна компонента (остался лишь второй список), то граф связанный.

// using System;
// using System.Collections.Generic;

// class Program
// {
//     static void Main()
//     {
//         // Матрица смежности (аналогичная вашей Python-матрице)
//         int[,] matrix = {
//             {0,0,0,1,0,0,0,0,0,0},
//             {0,0,0,0,0,1,0,0,1,0},
//             {0,0,0,0,0,0,0,0,0,1},
//             {1,0,0,0,0,0,0,0,0,0},
//             {0,0,0,0,0,0,1,1,0,0},
//             {0,1,0,0,0,0,0,0,1,0},
//             {0,0,0,0,1,0,0,1,0,0},
//             {0,0,0,0,1,0,1,0,0,0},
//             {0,1,0,0,0,1,0,0,0,0},
//             {0,0,1,0,0,0,0,0,0,0}
//         };

//         int n = matrix.GetLength(0);
//         List<int> vertices = new List<int>();
        
//         // Заполняем список вершин (1..n)
//         for (int i = 0; i < n; i++)
//         {
//             vertices.Add(i + 1);
//         }

//         List<List<int>> components = new List<List<int>>();

//         Console.Write("Все вершины: ");
//         Console.WriteLine(string.Join(", ", vertices));

//         while (vertices.Count != 0)
//         {
//             List<int> newComponent = new List<int>();
//             newComponent.Add(vertices[0]);
//             vertices.RemoveAt(0);

//             int number = 0;
//             while (number != newComponent.Count)
//             {
//                 int currentVertex = newComponent[number] - 1; // Переводим в 0-based индекс
                
//                 for (int i = 0; i < n; i++)
//                 {
//                     if (matrix[currentVertex, i] != 0 && !newComponent.Contains(i + 1) && vertices.Contains(i + 1))
//                     {
//                         newComponent.Add(i + 1);
//                         vertices.Remove(i + 1);
//                     }
//                 }
//                 number++;
//             }
//             components.Add(newComponent);
//         }

//         Console.WriteLine("\nКомпоненты связности:");
//         foreach (var component in components)
//         {
//             Console.WriteLine(string.Join(", ", component));
//         }

//         Console.WriteLine($"\nКоличество компонент связности: {components.Count}");
//     }
// }

// алгоритм 2
// 1. Выписываем номер на месте элемента
// 2. Следующий элемент проверяем на связанность со всеми предыдущими (если связан - ставим номер предыдущего,
// если нет - ставим номер этого элемента)
// 3. Если элемент более высокого порядка связан с несвязанными предыдущими, то ставим номер наименьшего связанного предыдущего
// и перезаписываем номера других связанных
// Если в списке осталось 2 или более разных номеров, то граф несвязанный.
// using System;
// using System.Collections.Generic;

// class Program
// {
//     static void Main()
//     {
//         // Исходная матрица смежности
//         int[,] matrix = {
//             {0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
//             {0, 0, 0, 0, 0, 1, 0, 0, 1, 0},
//             {0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
//             {1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
//             {0, 0, 0, 0, 0, 0, 1, 1, 0, 0},
//             {0, 1, 0, 0, 0, 0, 0, 0, 1, 0},
//             {0, 0, 0, 0, 1, 0, 0, 1, 0, 0},
//             {0, 0, 0, 0, 1, 0, 1, 0, 0, 0},
//             {0, 1, 0, 0, 0, 1, 0, 0, 0, 0},
//             {0, 0, 1, 0, 0, 0, 0, 0, 0, 0}
//         };

//         int n = matrix.GetLength(0);
//         int[] newList = new int[n];

//         // Инициализация списка вершин
//         for (int i = 0; i < n; i++)
//         {
//             newList[i] = i;
//         }

//         Console.Write("Исходный список вершин: ");
//         PrintArray(newList);

//         // Основной алгоритм
//         for (int i = 0; i < n; i++)
//         {
//             for (int j = 0; j < n; j++)
//             {
//                 if (matrix[i, j] != 0 && newList[j] > newList[i])
//                 {
//                     newList[j] = newList[i];
//                 }
//             }
//         }

//         Console.Write("Обновленный список: ");
//         PrintArray(newList);

//         // Подсчет уникальных компонент
//         HashSet<int> components = new HashSet<int>();
//         for (int i = 0; i < n; i++)
//         {
//             components.Add(newList[i]);
//         }

//         Console.WriteLine("Количество компонент связности: " + components.Count);
//     }

//     // Вспомогательный метод для вывода массива
//     static void PrintArray(int[] arr)
//     {
//         Console.Write("[");
//         for (int i = 0; i < arr.Length; i++)
//         {
//             Console.Write(arr[i]);
//             if (i < arr.Length - 1)
//             {
//                 Console.Write(", ");
//             }
//         }
//         Console.WriteLine("]");
//     }
// }