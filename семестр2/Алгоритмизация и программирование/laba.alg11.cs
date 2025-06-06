// using System;
// using System.Collections.Generic;
// using System.Linq;
// // задача1
// namespace InventoryManagement
// {
//     public class Product
//     {
//         public uint Id { get; }
//         public string Name { get; }
//         public TimeSpan ExpirationPeriod { get; }

//         public Product(uint id, string name, TimeSpan expirationPeriod)
//         {
//             Id = id;
//             Name = name;
//             ExpirationPeriod = expirationPeriod;
//         }
//     }

//     public class Vendor
//     {
//         public uint Id { get; }
//         public string Name { get; }

//         public Vendor(uint id, string name)
//         {
//             Id = id;
//             Name = name;
//         }
//     }

//     public class InventoryTransaction
//     {
//         public uint ProductId { get; }
//         public uint VendorId { get; }
//         public bool IsOutgoing { get; }
//         public uint Quantity { get; }
//         public uint UnitPrice { get; }
//         public DateTime TransactionDate { get; }

//         public InventoryTransaction(uint productId, uint vendorId, uint quantity, uint price, DateTime date)
//         {
//             ProductId = productId;
//             VendorId = vendorId;
//             IsOutgoing = false;
//             Quantity = quantity;
//             UnitPrice = price;
//             TransactionDate = date;
//         }

//         public InventoryTransaction(uint productId, uint quantity, uint price, DateTime date)
//         {
//             ProductId = productId;
//             IsOutgoing = true;
//             Quantity = quantity;
//             UnitPrice = price;
//             TransactionDate = date;
//         }

//         public InventoryTransaction(uint productId, uint quantity, DateTime date)
//         {
//             ProductId = productId;
//             IsOutgoing = true;
//             Quantity = quantity;
//             UnitPrice = 0;
//             TransactionDate = date;
//         }
//     }

//     public class Store
//     {
//         public List<Product> Products { get; }
//         public List<Vendor> Vendors { get; }
//         public List<InventoryTransaction> Transactions { get; }

//         public Store(List<Product> products, List<Vendor> vendors, List<InventoryTransaction> transactions)
//         {
//             Products = products;
//             Vendors = vendors;
//             Transactions = transactions;
//         }

//         public void DisplayCurrentInventory()
//         {
//             var inventory = Products.Select(product => new
//             {
//                 Product = product,
//                 Stock = Transactions
//                     .Where(t => t.ProductId == product.Id)
//                     .Sum(t => t.IsOutgoing ? -t.Quantity : t.Quantity)
//             });

//             Console.WriteLine("\nТекущие остатки товаров:");
//             foreach (var item in inventory)
//             {
//                 Console.WriteLine($"{item.Product.Name} (ID: {item.Product.Id}): {item.Stock} шт.");
//             }
//             Console.WriteLine();
//         }

//         public void DisplayExpiredProductsByDate()
//         {
//             var expiredProducts = Transactions
//                 .Where(t => t.IsOutgoing && t.UnitPrice == 0)
//                 .GroupBy(t => t.TransactionDate);

//             Console.WriteLine("\nСписанные товары по датам:");
//             foreach (var group in expiredProducts)
//             {
//                 Console.WriteLine($"Дата: {group.Key:d}");
//                 foreach (var transaction in group)
//                 {
//                     Console.WriteLine($"Товар ID: {transaction.ProductId}, Количество: {transaction.Quantity} шт.");
//                 }
//                 Console.WriteLine();
//             }
//         }

//         public void DisplayRevenueForPeriod(DateTime startDate, DateTime endDate)
//         {
//             var revenue = Products.Select(product => new
//             {
//                 Product = product,
//                 Revenue = Transactions
//                     .Where(t => t.ProductId == product.Id && 
//                                t.IsOutgoing && 
//                                t.UnitPrice > 0 &&
//                                t.TransactionDate >= startDate && 
//                                t.TransactionDate <= endDate)
//                     .Sum(t => t.Quantity * t.UnitPrice)
//             });

//             Console.WriteLine($"\nВыручка от продаж с {startDate:d} по {endDate:d}:");
//             foreach (var item in revenue)
//             {
//                 Console.WriteLine($"{item.Product.Name} (ID: {item.Product.Id}): {item.Revenue} руб.");
//             }
//             Console.WriteLine();
//         }
//     }

//     public class Program
//     {
//         public static void Main()
//         {
//             var products = new List<Product>
//             {
//                 new Product(2131, "Сосиски", TimeSpan.FromDays(31)),
//                 new Product(2243, "Курица", TimeSpan.FromDays(15)),
//                 new Product(6765, "Телефоны", TimeSpan.FromDays(365 * 5)),
//                 new Product(6981, "Телевизоры", TimeSpan.FromDays(365 * 3))
//             };

//             var vendors = new List<Vendor>
//             {
//                 new Vendor(21, "Ферма"),
//                 new Vendor(68, "Завод электроники")
//             };

//             var transactions = new List<InventoryTransaction>
//             {
//                 new InventoryTransaction(products[0].Id, vendors[0].Id, 15, 100, DateTime.Parse("30.11.1999")),
//                 new InventoryTransaction(products[0].Id, 8, 160, DateTime.Parse("15.12.1999")),
//                 new InventoryTransaction(products[0].Id, vendors[0].Id, 15, 100, DateTime.Parse("16.12.1999")),
//                 new InventoryTransaction(products[0].Id, 7, DateTime.Parse("30.12.1999")), // 15-8=7
//                 new InventoryTransaction(products[1].Id, vendors[0].Id, 11, 200, DateTime.Parse("02.01.2000")),
//                 new InventoryTransaction(products[1].Id, 11, 350, DateTime.Parse("05.01.2000")),
//                 new InventoryTransaction(products[2].Id, vendors[1].Id, 5, 5000, DateTime.Parse("15.01.2000")),
//                 new InventoryTransaction(products[2].Id, 2, 7500, DateTime.Parse("17.01.2000")),
//                 new InventoryTransaction(products[3].Id, vendors[1].Id, 2, 30000, DateTime.Parse("15.01.2000")),
//                 new InventoryTransaction(products[3].Id, 1, 52000, DateTime.Parse("17.01.2000"))
//             };

//             var store = new Store(products, vendors, transactions);

//             int choice;
//             do
//             {
//                 DisplayMenu();
//                 choice = GetUserChoice();

//                 switch (choice)
//                 {
//                     case 1:
//                         store.DisplayCurrentInventory();
//                         break;
//                     case 2:
//                         store.DisplayExpiredProductsByDate();
//                         break;
//                     case 3:
//                         Console.WriteLine("Введите интервал времени:");
//                         Console.Write("От (дд.мм.гггг): ");
//                         var startDate = DateTime.Parse(Console.ReadLine());
//                         Console.Write("До (дд.мм.гггг): ");
//                         var endDate = DateTime.Parse(Console.ReadLine());
//                         store.DisplayRevenueForPeriod(startDate, endDate);
//                         break;
//                     case 4:
//                         Console.WriteLine("Выход из программы...");
//                         break;
//                     default:
//                         Console.WriteLine("Неверный выбор. Попробуйте снова.");
//                         break;
//                 }
//             } while (choice != 4);
//         }

//         private static void DisplayMenu()
//         {
//             Console.WriteLine("\nСистема управления складом:");
//             Console.WriteLine("1. Показать текущие остатки");
//             Console.WriteLine("2. Показать списанные товары");
//             Console.WriteLine("3. Рассчитать выручку за период");
//             Console.WriteLine("4. Выход");
//             Console.Write("Выберите действие: ");
//         }

//         private static int GetUserChoice()
//         {
//             int choice;
//             while (!int.TryParse(Console.ReadLine(), out choice))
//             {
//                 Console.Write("Ошибка ввода. Введите число от 1 до 4: ");
//             }
//             return choice;
//         }
//     }
// }


// задача 2
// using System;
// using System.Collections.Generic;

// namespace PalindromeFinder
// {
//     class NumberProcessor
//     {
//         // Функция для проверки, является ли число палиндромом
//         static bool IsPalindrome(int number)
//         {
//             if (number <= 0) return false; //Палиндром должен быть положительным.

//             int originalNumber = number;
//             int reversedNumber = 0;

//             while (number > 0)
//             {
//                 int digit = number % 10;
//                 reversedNumber = reversedNumber * 10 + digit;
//                 number /= 10;
//             }

//             return originalNumber == reversedNumber;
//         }

//         static void Main(string[] args)
//         {
//             Console.Write("Укажите количество чисел для ввода: ");
//             if (!int.TryParse(Console.ReadLine(), out int arraySize) || arraySize <= 0)
//             {
//                 Console.WriteLine("Некорректный ввод размера массива.  Пожалуйста, введите положительное целое число.");
//                 return;
//             }

//             int[] numbers = new int[arraySize]; // Используем обычный массив.

//             for (int i = 0; i < arraySize; i++)
//             {
//                 Console.Write($"Введите число #{i + 1}: ");
//                 if (!int.TryParse(Console.ReadLine(), out numbers[i]))
//                 {
//                     Console.WriteLine("Некорректный ввод числа. Пожалуйста, введите целое число.");
//                     i--; // Повторяем ввод для текущей позиции.
//                 }
//             }

//             Console.WriteLine("\nПалиндромы в массиве:");

//             foreach (int number in numbers)
//             {
//                 if (IsPalindrome(number))
//                 {
//                     Console.WriteLine($"Число {number} - палиндром.");
//                 }
//             }
//         }
//     }
// }