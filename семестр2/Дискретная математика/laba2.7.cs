// // волновой алгоритм
// using System;
// using System.Collections.Generic;

// public class WaveAlgorithm
// {
//     public static void Main(string[] args)
//     {
//         // Лабиринт: 0 - проход, "x" - стена
//         char[][] matrix = {
//             new char[] { '0', '0', '0', 'x', 'x' },
//             new char[] { '0', 'x', '0', '0', '0' },
//             new char[] { '0', 'x', '0', 'x', '0' },
//             new char[] { '0', '0', '0', 'x', '0' },
//             new char[] { '0', '0', '0', 'x', '0' }
//         };

//         // Стартовая и конечная точки (строка, столбец)
//         int[] start = { 3, 1 };
//         int[] end = { 3, 4 };

//         // Расширяем матрицу, добавляя границы
//         matrix = PadMatrix(matrix);

//         // Учитываем сдвиг координат из-за добавленных границ
//         for (int i = 0; i < 2; i++)
//         {
//             start[i] += 1;
//             end[i] += 1;
//         }

//         Console.WriteLine($"Конечная точка (с учетом границ): ({end[0]}, {end[1]})");

//         // Направления движения (dx, dy)
//         (int, int)[] directions = { (0, 1), (0, -1), (1, 0), (-1, 0) };

        
//         Queue<(int, int)> q = new Queue<(int, int)>();
//         int x = start[0];
//         int y = start[1];
//         q.Enqueue((x, y));

//         // Устанавливаем начальное расстояние от старта = 1
//         matrix[x][y] = '1';

//         // Основной цикл BFS
//         while (q.Count > 0)  // Используем Count для проверки пустоты очереди
//         {
//             (x, y) = q.Dequeue();  // Извлекаем координаты текущей клетки
//             Console.WriteLine($"Обрабатываем клетку: ({x}, {y})"); // для отладки

//             // Перебираем направления движения
//             foreach (var (dx, dy) in directions)
//             {
//                 int nx = x + dx;
//                 int ny = y + dy;

//                 // Проверяем, можно ли перейти в соседнюю клетку
//                 if (matrix[nx][ny] == '-' || matrix[nx][ny] == 'x' || (char.IsDigit(matrix[nx][ny]) && Convert.ToInt32(matrix[nx][ny].ToString()) > 0))
//                 {
//                     continue; // Клетка непроходима
//                 }

//                 // Если клетка проходима, обновляем ее значение (расстояние от старта)
//                 matrix[nx][ny] = (char)(Convert.ToInt32(matrix[x][y].ToString()) + 1); // преобразуем char в int, прибавляем 1, преобразуем обратно

//                 // Добавляем соседнюю клетку в очередь
//                 q.Enqueue((nx, ny));

//                 // Проверяем, достигли ли мы конечной точки
//                 if (nx == end[0] && ny == end[1])
//                 {
//                     break; // Прерываем внутренний цикл
//                 }
//             }

//             // Проверяем, достигли ли мы конечной точки (после перебора направлений)
//             if (x == end[0] && y == end[1])
//             {
//                 break; // Прерываем внешний цикл
//             }
//         }

//         // Вывод результатов
//         if (matrix[end[0]][end[1]] != '-' && matrix[end[0]][end[1]] != 'x' && char.IsDigit(matrix[end[0]][end[1]]))  //  Проверяем, что путь был найден
//         {
//             Console.WriteLine($"Количество шагов: {Convert.ToInt32(matrix[end[0]][end[1]].ToString()) - 1}"); // Вычитаем 1, т.к. начали с '1'
//             for (int i = 0; i < matrix.Length; i++)
//             {
//                 Console.WriteLine(string.Join(" ", matrix[i]));
//             }
//         }
//         else
//         {
//             Console.WriteLine("Невозможно дойти до точки выхода");
//         }
//     }

//     // Функция для добавления границ к матрице
//     static char[][] PadMatrix(char[][] matrix)
//     {
//         int rows = matrix.Length;
//         int cols = matrix[0].Length;

//         // Создаем новую матрицу с увеличенными размерами
//         char[][] paddedMatrix = new char[rows + 2][];
//         for (int i = 0; i < rows + 2; i++)
//         {
//             paddedMatrix[i] = new char[cols + 2];
//         }

//         // Заполняем границы
//         for (int i = 0; i < rows + 2; i++)
//         {
//             paddedMatrix[i][0] = '-'; // Левая граница
//             paddedMatrix[i][cols + 1] = '-'; // Правая граница
//         }
//         for (int j = 0; j < cols + 2; j++)
//         {
//             paddedMatrix[0][j] = '-'; // Верхняя граница
//             paddedMatrix[rows + 1][j] = '-'; // Нижняя граница
//         }
//         for (int i = 0; i < rows; i++)
//         {
//             for (int j = 0; j < cols; j++)
//             {
//                 paddedMatrix[i + 1][j + 1] = matrix[i][j];
//             }
//         }

//         return paddedMatrix;
//     }
// }