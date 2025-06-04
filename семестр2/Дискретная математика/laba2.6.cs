// // флойд
// using System;

// public class FloydWarshall
// {
//     const int Infinity = int.MaxValue; 

//     public static int[,] FindShortestPaths(int[,] graph)
//     {
//         int numVertices = graph.GetLength(0);
//         int[,] distances = new int[numVertices, numVertices];

//         // Инициализация матрицы расстояний
//         for (int i = 0; i < numVertices; i++)
//         {
//             for (int j = 0; j < numVertices; j++)
//             {
//                 distances[i, j] = graph[i, j]; // Исходные веса ребер
//             }
//         }

//         // Основной алгоритм
//         for (int k = 0; k < numVertices; k++) // Промежуточная вершина
//         {
//             for (int i = 0; i < numVertices; i++) // Начальная вершина
//             {
//                 for (int j = 0; j < numVertices; j++) // Конечная вершина
//                 {
//                     // Если путь через вершину k короче, чем текущий путь
//                     if (distances[i, k] != Infinity &&
//                         distances[k, j] != Infinity &&
//                         distances[i, k] + distances[k, j] < distances[i, j])
//                     {
//                         distances[i, j] = distances[i, k] + distances[k, j];
//                     }
//                 }
//             }
//         }

//         return distances;
//     }

//     public static void Main(string[] args)
//     {
//         // Пример графа в виде матрицы смежности
//         int[,] graph = {
//             {0, 10, 18, 8,   Infinity, Infinity},
//             {10, 0, 16, 9,   21,   Infinity},
//             {Infinity, 16, 0, Infinity, Infinity, 15},
//             {7,   9,   Infinity, 0,   Infinity, 12},
//             {Infinity, Infinity, Infinity, Infinity, 0,   23},
//             {Infinity, Infinity, 15, Infinity, 23, 0}
//         };

//         // Находим кратчайшие пути
//         int[,] shortestPaths = FindShortestPaths(graph);

//         // Выводим результаты
//         Console.WriteLine("Матрица кратчайших путей:");
//         for (int i = 0; i < shortestPaths.GetLength(0); i++)
//         {
//             for (int j = 0; j < shortestPaths.GetLength(1); j++)
//             {
//                 if (shortestPaths[i, j] == Infinity)
//                 {
//                     Console.Write("inf\t");
//                 }
//                 else
//                 {
//                     Console.Write(shortestPaths[i, j] + "\t");
//                 }
//             }
//             Console.WriteLine();
//         }
//     }
// }