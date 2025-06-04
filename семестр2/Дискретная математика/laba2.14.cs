// Форд фалкерсон
// using System;
// using System.Collections.Generic;
// using System.Linq;

// public class FordFulkerson
// {
//     public static int FindMaxFlow(int[,] capacity, int source, int sink)
//     {
//         int numVertices = capacity.GetLength(0);
//         int[,] residualCapacity = (int[,])capacity.Clone(); // Создаем остаточную сеть
//         int maxFlow = 0;

//         while (true)
//         {
//             List<int> path = FindAugmentingPath(residualCapacity, source, sink);

//             if (path.Count == 0) // Если путь не найден, завершаем
//             {
//                 break;
//             }

//             // Находим минимальную остаточную пропускную способность вдоль пути
//             int bottleneckCapacity = int.MaxValue;
//             for (int i = 0; i < path.Count - 1; i++)
//             {
//                 int u = path[i];
//                 int v = path[i + 1];
//                 bottleneckCapacity = Math.Min(bottleneckCapacity, residualCapacity[u, v]);
//             }

//             // Увеличиваем поток по пути
//             for (int i = 0; i < path.Count - 1; i++)
//             {
//                 int u = path[i];
//                 int v = path[i + 1];
//                 residualCapacity[u, v] -= bottleneckCapacity; // Уменьшаем пропускную способность прямого ребра
//                 residualCapacity[v, u] += bottleneckCapacity; // Увеличиваем пропускную способность обратного ребра
//             }

//             maxFlow += bottleneckCapacity;
//         }

//         return maxFlow;
//     }

//     private static List<int> FindAugmentingPath(int[,] residualCapacity, int source, int sink)
//     {
//         int numVertices = residualCapacity.GetLength(0);
//         List<int> path = new List<int>();
//         bool[] visited = new bool[numVertices];
//         int[] parent = new int[numVertices]; // Для восстановления пути

//         for (int i = 0; i < numVertices; i++)
//         {
//             parent[i] = -1;
//         }

//         Stack<int> stack = new Stack<int>();
//         stack.Push(source);
//         visited[source] = true;

//         while (stack.Count > 0)
//         {
//             int u = stack.Pop();

//             if (u == sink)
//             {
//                 break; // Путь найден
//             }

//             for (int v = 0; v < numVertices; v++)
//             {
//                 if (!visited[v] && residualCapacity[u, v] > 0)
//                 {
//                     visited[v] = true;
//                     parent[v] = u;
//                     stack.Push(v);
//                 }
//             }
//         }

//         // Восстанавливаем путь из parent
//         if (parent[sink] == -1)
//         {
//             return path; // Путь не найден
//         }

//         int current = sink;
//         while (current != -1)
//         {
//             path.Add(current);
//             current = parent[current];
//         }
//         path.Reverse(); //  Разворачиваем путь, чтобы получить путь от source к sink
//         return path;
//     }


//     public static void Main(string[] args)
//     {
//         // Пример графа (матрица пропускных способностей)
//         int[,] capacity = {
//             {0, 19, 29, 0, 0, 0},
//             {0, 0, 0, 0, 9, 14},
//             {0, 0, 0, 31, 15, 0},
//             {0, 14, 0, 0, 0, 10},
//             {0, 0, 0, 34, 0, 15},
//             {0, 0, 0, 0, 0, 0}
//         };
//         int source = 0;  // Источник
//         int sink = 5;    // Сток

//         int maxFlow = FindMaxFlow(capacity, source, sink);

//         Console.WriteLine("Максимальный поток: " + maxFlow);
//     }
// }