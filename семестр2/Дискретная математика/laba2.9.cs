// задача коммивояжёра, алгоритмом Литтла
// using System;
// using System.Collections.Generic;
// using System.Linq;

// public class TravelingSalesman
// {
//     const double Infinity = double.PositiveInfinity;

//     public static (List<(int, int)>, double) SolveTSP(double[,] matrix)
//     {
//         int numCities = matrix.GetLength(0);
//         List<int> rows = Enumerable.Range(1, numCities).ToList(); // Номера городов
//         List<int> cols = Enumerable.Range(1, numCities).ToList();
//         List<(int, int)> edges = new List<(int, int)>();
//         double totalCost = 0;

//         double[,] currentMatrix = (double[,])matrix.Clone();  // Копируем исходную матрицу

//         for (int n = 0; n < numCities - 1; n++)
//         {
//             int length = currentMatrix.GetLength(0);

//             // Редукция строк
//             for (int i = 0; i < length; i++)
//             {
//                 double minVal = double.MaxValue;
//                 for (int j = 0; j < length; j++)
//                 {
//                     minVal = Math.Min(minVal, currentMatrix[i, j]);
//                 }

//                 if (minVal != Infinity && minVal != 0)
//                 {
//                     totalCost += minVal;
//                     for (int j = 0; j < length; j++)
//                     {
//                         currentMatrix[i, j] -= minVal;
//                     }
//                 }
//             }

//             // Редукция столбцов
//             for (int j = 0; j < length; j++)
//             {
//                 double minVal = double.MaxValue;
//                 for (int i = 0; i < length; i++)
//                 {
//                     minVal = Math.Min(minVal, currentMatrix[i, j]);
//                 }

//                 if (minVal != Infinity && minVal != 0)
//                 {
//                     totalCost += minVal;
//                     for (int i = 0; i < length; i++)
//                     {
//                         currentMatrix[i, j] -= minVal;
//                     }
//                 }
//             }

//             // Вычисление штрафов и выбор ребра
//             double maxPenalty = -1;
//             int bestRow = -1, bestCol = -1;
//             double[] rowMinValues = new double[length];
//             double[] colMinValues = new double[length];

//             // Находим минимальные значения в строках и столбцах для вычисления штрафов
//             for (int i = 0; i < length; i++)
//             {
//                 rowMinValues[i] = Infinity;
//                 colMinValues[i] = Infinity;

//                 for (int j = 0; j < length; j++)
//                 {
//                     if (currentMatrix[i, j] == 0) continue;
//                     rowMinValues[i] = Math.Min(rowMinValues[i], currentMatrix[i, j]);
//                 }
//                 for (int j = 0; j < length; j++)
//                 {
//                     if (currentMatrix[j, i] == 0) continue;
//                     colMinValues[i] = Math.Min(colMinValues[i], currentMatrix[j, i]);
//                 }

//             }
//             for (int i = 0; i < length; i++)
//             {
//                 for (int j = 0; j < length; j++)
//                 {
//                     if (currentMatrix[i, j] == 0)
//                     {
//                         double penalty = rowMinValues[i] + colMinValues[j];
//                         if (penalty > maxPenalty)
//                         {
//                             maxPenalty = penalty;
//                             bestRow = i;
//                             bestCol = j;
//                         }
//                     }
//                 }
//             }
//             // Запрещаем использование выбранного ребра
//             currentMatrix[bestRow, bestCol] = Infinity;

//             // Добавляем выбранное ребро
//             edges.Add((rows[bestRow], cols[bestCol]));

//             // Удаляем строку и столбец
//             rows.RemoveAt(bestRow);
//             cols.RemoveAt(bestCol);

//             // Создаем новую матрицу без выбранной строки и столбца
//             double[,] newMatrix = new double[length - 1, length - 1];
//             int newRowIndex = 0, newColIndex = 0;
//             for (int i = 0; i < length; i++)
//             {
//                 if (i == bestRow) continue;
//                 newColIndex = 0;
//                 for (int j = 0; j < length; j++)
//                 {
//                     if (j == bestCol) continue;
//                     newMatrix[newRowIndex, newColIndex] = currentMatrix[i, j];
//                     newColIndex++;
//                 }
//                 newRowIndex++;
//             }
//             currentMatrix = newMatrix;
//         }

//         // Добавляем последнее ребро
//         edges.Add((rows[0], cols[0]));

//         return (edges, totalCost);
//     }

//     public static void Main(string[] args)
//     {
//         double[,] matrix = {
//             {Infinity, 7, 16, 21, 2, 17},
//             {13, Infinity, 21, 15, 43, 23},
//             {25, 3, Infinity, 31, 17, 9},
//             {13, 10, 27, Infinity, 33, 12},
//             {9, 2, 19, 14, Infinity, 51},
//             {42, 17, 5, 9, 23, Infinity}
//         };

//         (List<(int, int)> path, double cost) = SolveTSP(matrix);

//         Console.WriteLine("Оптимальный путь:");
//         foreach (var edge in path)
//         {
//             Console.Write($"({edge.Item1}, {edge.Item2}) ");
//         }
//         Console.WriteLine();
//         Console.WriteLine("Минимальная стоимость: " + cost);
//     }
// }
