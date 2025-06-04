// Алгоритм Дейкстры
// Минимальный от заданной до заданной / от заданной до всех
// И на ориентированном и неориентированном
// Не должно быть чередования весов (либо все положительные, либо все отрицательные)
// Нет петель (диагональ матрицы - бесконечности)
// Как минимальный, так и максимальный (отрицательные веса) путь
// Это жадный алгоритм
// Рассматривает все пути
// (Минимум по столбцам и строкам)
// Если в одной строке несколько минимальных значений, то следует выбрать первое попавшееся,
// потому что к остальным, при необходимости, алгоритм всё равно приведёт
// По умолчанию в начале выполнения программы в конечной матрице везде выставлены бесконечности
// На вход подаётся матрица, значение вершины входа и вершины выхода
// На выходе длина минимального веса

// using System;
// using System.Collections.Generic;
// using System.Linq;

// public class DijkstraSimple
// {
//     const int Infinity = int.MaxValue; // Константа для представления бесконечности

//     public static int[] FindShortestPaths(int[,] graph, int startNode)
//     {
//         int numVertices = graph.GetLength(0);
//         int[] distances = new int[numVertices];
//         bool[] visited = new bool[numVertices];

//         // Инициализация: все расстояния - бесконечность, все вершины - непосещенные
//         for (int i = 0; i < numVertices; i++)
//         {
//             distances[i] = Infinity; // Инициализируем бесконечностью
//             visited[i] = false;
//         }
//         distances[startNode] = 0; // Расстояние до начальной вершины - 0

//         // Основной цикл алгоритма
//         for (int count = 0; count < numVertices - 1; count++)
//         {
//             // Ищем вершину с минимальным расстоянием из еще не посещенных
//             int minDistance = Infinity;
//             int currentNode = -1; // -1 означает, что вершина не найдена
//             for (int i = 0; i < numVertices; i++)
//             {
//                 if (!visited[i] && distances[i] <= minDistance)
//                 {
//                     minDistance = distances[i];
//                     currentNode = i;
//                 }
//             }

//             // Если не нашли вершину, значит все достижимые уже посещены
//             if (currentNode == -1)
//             {
//                 break;
//             }

//             // Помечаем текущую вершину как посещенную
//             visited[currentNode] = true;

//             // Обновляем расстояния до соседних вершин
//             for (int neighbor = 0; neighbor < numVertices; neighbor++)
//             {
//                 if (graph[currentNode, neighbor] != Infinity) // Если есть ребро
//                 {
//                     int weight = graph[currentNode, neighbor];
//                     if (distances[currentNode] != Infinity &&  // Проверяем, что расстояние не бесконечно
//                         distances[currentNode] + weight < distances[neighbor])
//                     {
//                         distances[neighbor] = distances[currentNode] + weight;
//                     }
//                 }
//             }
//         }

//         return distances;
//     }

//     public static void Main(string[] args)
//     {
        
//         int[,] graph = {
//             {Infinity, 5, 2, Infinity, Infinity}, // A
//             {5, Infinity, Infinity, 1, Infinity}, // B
//             {2, Infinity, Infinity, 4, Infinity}, // C
//             {Infinity, 1, 4, Infinity, 3}, // D
//             {Infinity, Infinity, Infinity, 3, Infinity}  // E
//         };

//         // Начальная вершина (0 соответствует A, 1 - B, и т.д.)
//         int startNode = 0;

//         // Находим кратчайшие пути
//         int[] shortestPaths = FindShortestPaths(graph, startNode);

//         // Выводим результаты
//         Console.WriteLine($"Кратчайшие пути от вершины {Convert.ToChar('A' + startNode)}:");
//         for (int i = 0; i < shortestPaths.Length; i++)
//         {
//             Console.WriteLine($"До вершины {Convert.ToChar('A' + i)}: {shortestPaths[i]}");
//         }
//     }
// }
