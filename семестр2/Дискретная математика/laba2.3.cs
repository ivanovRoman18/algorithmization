// Мосты
// Объединение алгоритмов первого и второго алгоритмов (с соответствующих занятий)
// Мост - ребро, при удалении котрого граф разбивается на 2 новых (появлются новые компоненты связности)
// Если имеется основное дерево, то достаточно пройти по тем рёбрам, которые вошли в основное дерево
// Если имеется несколько компонент связности, то они его разобьют
// Необходимо определить всё рёбра, которые являются мостами
// Если удаление влечёт несвязанность с графом, то соответственно данное ребро является мостом - оптимальный алгоритм
// using System;
// using System.Collections.Generic;

// public class Bridges
// {
//     public static void Main(string[] args)
//     {
//         int vertices = 6;
//         List<List<int>> adj = new List<List<int>>();
//         for (int i = 0; i < vertices; i++)
//         {
//             adj.Add(new List<int>());
//         }

//         // Пример графа
//         AddEdge(adj, 0, 1);
//         AddEdge(adj, 1, 2);
//         AddEdge(adj, 0, 2);
//         AddEdge(adj, 1, 3);
//         AddEdge(adj, 3, 4);
//         AddEdge(adj, 4, 5);
//         AddEdge(adj, 3, 5);

//         FindBridges(adj, vertices);
//     }

//     static void AddEdge(List<List<int>> adj, int u, int v)
//     {
//         adj[u].Add(v);
//         adj[v].Add(u);
//     }

//     static void FindBridges(List<List<int>> adj, int vertices)
//     {
//         Console.WriteLine("Мосты в графе:");

//         for (int u = 0; u < vertices; u++)
//         {
//             // Создаем копию списка смежности для перебора
//             List<int> originalNeighbors = new List<int>(adj[u]);

//             foreach (int v in originalNeighbors)
//             {
//                 if (u < v)
//                 {
//                     // Временно удаляем ребро из оригинального списка
//                     adj[u].Remove(v);
//                     adj[v].Remove(u);


//                     // Считаем компоненты связности
//                     int components = CountConnectedComponents(adj, vertices);

//                     // Восстанавливаем ребро
//                     AddEdge(adj, u, v);

//                     // Проверяем, является ли ребро мостом
//                     if (components > 1)
//                     {
//                         Console.WriteLine("(" + u + ", " + v + ")");
//                     }
//                 }
//             }
//         }
//     }

//     static int CountConnectedComponents(List<List<int>> adj, int vertices)
//     {
//         bool[] visited = new bool[vertices];
//         int components = 0;

//         for (int i = 0; i < vertices; i++)
//         {
//             if (!visited[i])
//             {
//                 DFS(adj, i, visited);
//                 components++;
//             }
//         }

//         return components;
//     }

//     static void DFS(List<List<int>> adj, int u, bool[] visited)
//     {
//         visited[u] = true;
//         foreach (int v in adj[u])
//         {
//             if (!visited[v])
//             {
//                 DFS(adj, v, visited);
//             }
//         }
//     }
// }