// Алгоритм Форда-Беллмана (алгоритм нахождения минимального пути)
// От заданной вершины до всех остальных
// На каждом шаге-итерации пытаемся дойти до каждой вершины, используя разное количество дуг, выбирая минимульную
// Работает с отрицательным весами
// Если в графе есть цикл отрицательного веса, то алгоритм его выявляет
// Работает и для ориентированного, и для неориентированного графа
// 1. Строим матрицу весов
// Строка - откуда идём, столбец - куда идём
// Точка остановки - если следующая лямбда равна предыдущей
// Иначе считаем все лямбды (кол-во лямбд = количество вершин - 1)
// Возврат: с последней вершины идём до изначально выбранной
// Если построить n-ую лямбду, то можно найти контур отрицательных вершин
// На входе весовая матрица
// Номер начальной вершины запрашиваем у пользователя
// На выходе последняя лямбда
// using System;

// public class BellmanFord
// {
//     const int Infinity = int.MaxValue;

//     public static int[] FindShortestPaths(int[,] graph, int startVertex)
//     {
//         int numVertices = graph.GetLength(0);
//         int[] distances = new int[numVertices];

//         // Инициализация расстояний
//         for (int i = 0; i < numVertices; i++)
//         {
//             distances[i] = Infinity;
//         }
//         distances[startVertex] = 0;

//         // Основной алгоритм
//         for (int k = 1; k < numVertices; k++) // Итерации (количество ребер)
//         {
//             for (int u = 0; u < numVertices; u++) // Для каждой вершины
//             {
//                 for (int v = 0; v < numVertices; v++) // Для каждого соседа
//                 {
//                     if (graph[u, v] != Infinity && distances[u] != Infinity && distances[u] + graph[u, v] < distances[v])
//                     {
//                         distances[v] = distances[u] + graph[u, v];
//                     }
//                 }
//             }
//         }

//         // Проверка на циклы отрицательного веса
//         for (int u = 0; u < numVertices; u++)
//         {
//             for (int v = 0; v < numVertices; v++)
//             {
//                 if (graph[u, v] != Infinity && distances[u] != Infinity && distances[u] + graph[u, v] < distances[v])
//                 {
//                     Console.WriteLine("Обнаружен цикл отрицательного веса.");
//                     return null; // Или выбросить исключение, в зависимости от требований
//                 }
//             }
//         }

//         return distances;
//     }

//     public static void Main(string[] args)
//     {
//         // Пример графа в виде матрицы смежности
//         // Используем Infinity для представления отсутствия ребра
//         int[,] graph = {
//             {0,   4,   Infinity, Infinity, Infinity, Infinity, Infinity, 8},
//             {4,   0,   8, Infinity, Infinity, Infinity, Infinity, 11},
//             {Infinity, 8, 0, 7,   Infinity, 4,   Infinity, 2},
//             {Infinity, Infinity, 7, 0,   9,   14,  Infinity, Infinity},
//             {Infinity, Infinity, Infinity, 9,   0,   10,  Infinity, Infinity},
//             {Infinity, Infinity, 4, 14,  10,  0,   2,   Infinity},
//             {Infinity, Infinity, Infinity, Infinity, Infinity, 2,   0,   1},
//             {8,   11,  2, Infinity, Infinity, Infinity, 1,   0}
//         };

//         // Запрашиваем у пользователя начальную вершину
//         Console.WriteLine("Введите номер начальной вершины (0-" + (graph.GetLength(0) - 1) + "):");
//         int startVertex = int.Parse(Console.ReadLine());

//         // Находим кратчайшие пути
//         int[] shortestPaths = FindShortestPaths(graph, startVertex);

//         // Выводим результаты
//         if (shortestPaths != null)
//         {
//             Console.WriteLine($"Кратчайшие пути от вершины {startVertex}:");
//             for (int i = 0; i < shortestPaths.Length; i++)
//             {
//                 Console.WriteLine($"До вершины {i}: {shortestPaths[i]}");
//             }
//         }
//         else
//         {
//             Console.WriteLine("Невозможно найти кратчайшие пути из-за наличия цикла отрицательного веса.");
//         }
//     }
// }