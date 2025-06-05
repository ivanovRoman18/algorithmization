// using System;
// using System.Collections.Generic;

// // Класс-родитель: Фигура
// public class Figure
// {
//     public string Name { get; set; }

//     public Figure(string name)
//     {
//         Name = name;
//     }
// }

// // Интерфейс: ICalculations
// public interface ICalculations
// {
//     double CalculateArea();
//     double CalculatePerimeter();
// }

// // Класс: Окружность
// public class Circle : Figure, ICalculations
// {
//     public double Radius { get; set; }

//     public Circle(double radius) : base("Окружность")
//     {
//         Radius = radius;
//     }

//     public double CalculateArea()
//     {
//         return Math.PI * Radius * Radius;
//     }

//     public double CalculatePerimeter()
//     {
//         return 2 * Math.PI * Radius;
//     }

//     public override string ToString()
//     {
//         return $"Фигура: {Name}, Радиус: {Radius}";
//     }
// }

// // Класс: Квадрат
// public class Square : Figure, ICalculations
// {
//     public double SideLength { get; set; }

//     public Square(double sideLength) : base("Квадрат")
//     {
//         SideLength = sideLength;
//     }

//     public double CalculateArea()
//     {
//         return SideLength * SideLength;
//     }

//     public double CalculatePerimeter()
//     {
//         return 4 * SideLength;
//     }

//     public override string ToString()
//     {
//         return $"Фигура: {Name}, Сторона: {SideLength}";
//     }
// }

// // Класс: Равносторонний треугольник
// public class EquilateralTriangle : Figure, ICalculations
// {
//     public double SideLength { get; set; }

//     public EquilateralTriangle(double sideLength) : base("Равносторонний треугольник")
//     {
//         SideLength = sideLength;
//     }

//     public double CalculateArea()
//     {
//         return (Math.Sqrt(3) / 4) * SideLength * SideLength;
//     }

//     public double CalculatePerimeter()
//     {
//         return 3 * SideLength;
//     }

//     public override string ToString()
//     {
//         return $"Фигура: {Name}, Сторона: {SideLength}";
//     }
// }

// public class Program
// {
//     public static void Main(string[] args)
//     {
//         List<Figure> figures = new List<Figure>();

//         while (true)
//         {
//             Console.WriteLine("\n1. Создать 3 фигуры");
//             Console.WriteLine("2. Вывести результаты");
//             Console.WriteLine("3. Выход");
//             Console.Write("Выберите опцию: ");

//             string choice = Console.ReadLine();

//             switch (choice)
//             {
//                 case "1":
//                     // Создание 3 объектов
//                     if (figures.Count == 0) // Проверка, чтобы создавать объекты только один раз
//                     {
//                         // Окружность
//                         Console.Write("Введите радиус окружности: ");
//                         if (double.TryParse(Console.ReadLine(), out double circleRadius))
//                         {
//                             figures.Add(new Circle(circleRadius));
//                         }
//                         else
//                         {
//                             Console.WriteLine("Некорректный ввод радиуса окружности.");
//                         }


//                         // Квадрат
//                         Console.Write("Введите длину стороны квадрата: ");
//                         if (double.TryParse(Console.ReadLine(), out double squareSide))
//                         {
//                             figures.Add(new Square(squareSide));
//                         }
//                         else
//                         {
//                             Console.WriteLine("Некорректный ввод длины стороны квадрата.");
//                         }

//                         // Равносторонний треугольник
//                         Console.Write("Введите длину стороны равностороннего треугольника: ");
//                         if (double.TryParse(Console.ReadLine(), out double triangleSide))
//                         {
//                             figures.Add(new EquilateralTriangle(triangleSide));
//                         }
//                         else
//                         {
//                             Console.WriteLine("Некорректный ввод длины стороны треугольника.");
//                         }

//                         Console.WriteLine("Фигуры созданы.");
//                     }
//                     else
//                     {
//                         Console.WriteLine("Фигуры уже созданы. Выберите '2' для просмотра.");
//                     }
//                     break;

//                 case "2":
//                     // Выдача результатов
//                     if (figures.Count > 0)
//                     {
//                         foreach (Figure figure in figures)
//                         {
//                             if (figure is ICalculations calculations)
//                             {
//                                 Console.WriteLine(figure);
//                                 Console.WriteLine($"  Площадь: {calculations.CalculateArea()}");
//                                 Console.WriteLine($"  Периметр: {calculations.CalculatePerimeter()}");
//                                 Console.WriteLine("---");
//                             }
//                         }
//                     }
//                     else
//                     {
//                         Console.WriteLine("Сначала создайте фигуры (опция 1).");
//                     }
//                     break;

//                 case "3":
//                     // Выход
//                     Console.WriteLine("Выход из программы.");
//                     return;

//                 default:
//                     Console.WriteLine("Неверный выбор.");
//                     break;
//             }
//         }
//     }
// }