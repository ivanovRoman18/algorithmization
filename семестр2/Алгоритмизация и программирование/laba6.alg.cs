// Класс машины с полями:
// Марка
// ФИО владельца
// Год выпуска
// bool Поле "помыта машина или нет"
// Класса гараж с полями:
// Список всех машин (список объектов класса "машина")
// Класс мойка:
// Метод помыть машину
// С использованием делегата необходимо каждую машину в гараже помыть, если она не помыта
// Можно выводить "машина помыта", "машина уже чистая"

// using System;
// using System.Collections.Generic;

// namespace ConsoleApplication1
// {
//     delegate void CarWash(Car car);

//     class Car
//     {
//         public string Brand { get; set; }
//         public string Name { get; set; }
//         public int Year { get; set; }
//         public bool Clean { get; set; }

//         public Car(string brand, string name, int year, bool clean)
//         {
//             Brand = brand;
//             Name = name;
//             Year = year;
//             Clean = clean;
//         }
//     }

//     class Garage
//     {
//         public List<Car> Cars { get; set; }

//         public Garage(List<Car> cars)
//         {
//             Cars = cars;
//         }
//     }

//     class Washer
//     {
//         public static void Wash(Car car)
//         {
//             if (car.Clean)
//                 Console.WriteLine("Машина марки " + car.Brand + " " + car.Year + " года выпуска уже чистая");
//             else
//             {
//                 car.Clean = true;
//                 Console.WriteLine("Машина марки " + car.Brand + " " + car.Year + " года выпуска помыта");
//             }
//         }
//     }

//     class Program
//     {
//         static void Main(string[] args)
//         {
//             List<Car> car_lst = new List<Car>();
//             while (true)
//             {
//                 Console.Write("Марка автомобиля: ");
//                 string brand = Console.ReadLine();
//                 if (string.IsNullOrWhiteSpace(brand)) // Проверяем на пустую строку
//                     break;
//                 Console.Write("ФИО владельца: ");
//                 string name = Console.ReadLine();
//                 if (string.IsNullOrWhiteSpace(name))
//                     break;

//                 Console.Write("Год выпуска: ");
//                 string tempYear = Console.ReadLine();
//                 if (string.IsNullOrWhiteSpace(tempYear))
//                     break;

//                 if (!int.TryParse(tempYear, out int year)) // Проверка на корректность ввода года
//                 {
//                     Console.WriteLine("Некорректный ввод года. Пожалуйста, введите число.");
//                     continue; // Переходим к следующей итерации цикла
//                 }

//                 Console.Write("Чистота машины (да или нет): ");
//                 string tempClean = Console.ReadLine();
//                 if (string.IsNullOrWhiteSpace(tempClean))
//                     break;

//                 bool clean = tempClean.Trim().ToLower() == "да"; // Преобразуем ввод в bool (упрощено)

//                 Car car = new Car(brand, name, year, clean);
//                 car_lst.Add(car);
//                 Console.WriteLine();
//             }

//             Garage garage = new Garage(car_lst);
//             CarWash wash = Washer.Wash;

//             foreach (Car car in garage.Cars)
//             {
//                 wash(car);
//             }
//         }
//     }
// }
