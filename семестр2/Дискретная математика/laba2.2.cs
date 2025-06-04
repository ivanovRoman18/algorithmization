// // Алгоритм Прима (алгоритм ближайшего соседа)
// // Выбираем случайную вершину и соединяем с соседней вершиной с наименьшим (наибольшим) весом ребра
// // Выводится сумма весов (минимальный или максимальный)

// using System;

// class Program
// {
//     static void Main()
//     {
//         // Пример графа в виде матрицы смежности
//         int[,] graph = {
//             {0, 2, 0, 6, 0},
//             {2, 0, 3, 8, 5},
//             {0, 3, 0, 0, 7},
//             {6, 8, 0, 0, 9},
//             {0, 5, 7, 9, 0}
//         };

//         int vertices = graph.GetLength(0);
//         int minTotalWeight = 0;
//         int maxTotalWeight = 0;

//         // Вызываем алгоритм Прима для минимального остовного дерева
//         minTotalWeight = PrimMST(graph, vertices, false);
//         Console.WriteLine("Минимальное остовное дерево имеет вес: " + minTotalWeight);

//         // Вызываем алгоритм Прима для максимального остовного дерева
//         maxTotalWeight = PrimMST(graph, vertices, true);
//         Console.WriteLine("Максимальное остовное дерево имеет вес: " + maxTotalWeight);
//     }

//     static int PrimMST(int[,] graph, int vertices, bool isMax)
//     {
//         // Массив для хранения родительских вершин
//         int[] parent = new int[vertices];
        
//         // Массив для хранения весов
//         int[] key = new int[vertices];
        
//         // Массив для отметки включенных вершин
//         bool[] mstSet = new bool[vertices];

//         // Инициализация
//         for (int i = 0; i < vertices; i++)
//         {
//             key[i] = isMax ? int.MinValue : int.MaxValue;
//             mstSet[i] = false;
//         }

//         // Начинаем с первой вершины
//         key[0] = 0;
//         parent[0] = -1; // У первой вершины нет родителя

//         for (int count = 0; count < vertices - 1; count++)
//         {
//             // Выбираем вершину с минимальным или максимальным ключом
//             int u = isMax ? MaxKey(key, mstSet, vertices) : MinKey(key, mstSet, vertices);

//             // Включаем выбранную вершину в MST
//             mstSet[u] = true;

//             // Обновляем ключи соседних вершин
//             for (int v = 0; v < vertices; v++)
//             {
//                 if (graph[u, v] != 0 && !mstSet[v])
//                 {
//                     if (isMax)
//                     {
//                         if (graph[u, v] > key[v])
//                         {
//                             parent[v] = u;
//                             key[v] = graph[u, v];
//                         }
//                     }
//                     else
//                     {
//                         if (graph[u, v] < key[v])
//                         {
//                             parent[v] = u;
//                             key[v] = graph[u, v];
//                         }
//                     }
//                 }
//             }
//         }

//         // Вычисляем общий вес
//         int totalWeight = 0;
//         for (int i = 1; i < vertices; i++)
//         {
//             totalWeight += graph[i, parent[i]];
//         }

//         return totalWeight;
//     }

//     // Вспомогательная функция для поиска вершины с минимальным ключом
//     static int MinKey(int[] key, bool[] mstSet, int vertices)
//     {
//         int min = int.MaxValue;
//         int minIndex = -1;

//         for (int v = 0; v < vertices; v++)
//         {
//             if (!mstSet[v] && key[v] < min)
//             {
//                 min = key[v];
//                 minIndex = v;
//             }
//         }

//         return minIndex;
//     }

//     // Вспомогательная функция для поиска вершины с максимальным ключом
//     static int MaxKey(int[] key, bool[] mstSet, int vertices)
//     {
//         int max = int.MinValue;
//         int maxIndex = -1;

//         for (int v = 0; v < vertices; v++)
//         {
//             if (!mstSet[v] && key[v] > max)
//             {
//                 max = key[v];
//                 maxIndex = v;
//             }
//         }

//         return maxIndex;
//     }
// }



// Алгоритм Краскала (Крускала)
// Сортируем рёбра по возрастанию



// using System;
// using System.Collections.Generic;

// class KruskalAlgorithm
// {
//     class Edge
//     {
//         public int Source;
//         public int Destination;
//         public int Weight;
//     }

//     class Subset
//     {
//         public int Parent;
//         public int Rank;
//     }

//     static int Find(Subset[] subsets, int i)
//     {
//         if (subsets[i].Parent != i)
//             subsets[i].Parent = Find(subsets, subsets[i].Parent);

//         return subsets[i].Parent;
//     }

//     static void Union(Subset[] subsets, int x, int y)
//     {
//         int xroot = Find(subsets, x);
//         int yroot = Find(subsets, y);

//         if (subsets[xroot].Rank < subsets[yroot].Rank)
//             subsets[xroot].Parent = yroot;
//         else if (subsets[xroot].Rank > subsets[yroot].Rank)
//             subsets[yroot].Parent = xroot;
//         else
//         {
//             subsets[yroot].Parent = xroot;
//             subsets[xroot].Rank++;
//         }
//     }

//     static void KruskalMST(List<Edge> edges, int vertices)
//     {
//         edges.Sort((a, b) => a.Weight.CompareTo(b.Weight));

//         Subset[] subsets = new Subset[vertices];
//         for (int v = 0; v < vertices; v++)  // Было for (int i = 0; i < vertices; i++)
//         {
//             subsets[v] = new Subset { Parent = v, Rank = 0 };
//         }

//         List<Edge> result = new List<Edge>();
//         int e = 0;
//         int i = 0;

//         while (e < vertices - 1)
//         {
//             Edge nextEdge = edges[i++];
//             int x = Find(subsets, nextEdge.Source);
//             int y = Find(subsets, nextEdge.Destination);

//             if (x != y)
//             {
//                 result.Add(nextEdge);
//                 Union(subsets, x, y);
//                 e++;
//             }
//         }

//         Console.WriteLine("Минимальное остовное дерево (Kruskal):");
//         foreach (Edge edge in result)
//         {
//             Console.WriteLine($"{edge.Source} -- {edge.Destination} (вес: {edge.Weight})");
//         }
//     }

//     static void Main()
//     {
//         int vertices = 4;
//         List<Edge> edges = new List<Edge>
//         {
//             new Edge { Source = 0, Destination = 1, Weight = 10 },
//             new Edge { Source = 0, Destination = 2, Weight = 6 },
//             new Edge { Source = 0, Destination = 3, Weight = 5 },
//             new Edge { Source = 1, Destination = 3, Weight = 15 },
//             new Edge { Source = 2, Destination = 3, Weight = 4 }
//         };

//         KruskalMST(edges, vertices);
//     }
// }