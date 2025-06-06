// // задача1
// using System;
// using System.Linq;

// namespace PhoneDatabase
// {
//     public class PhoneRecord
//     {
//         public uint Number { get; }
//         public string Owner { get; }
//         public uint Year { get; }
//         public string Provider { get; }

//         public PhoneRecord(uint number, string owner, uint year, string provider)
//         {
//             Number = number;
//             Owner = owner;
//             Year = year;
//             Provider = provider;
//         }
//     }

//     public class PhoneDatabaseManager
//     {
//         private readonly PhoneRecord[] _records;

//         public PhoneDatabaseManager(PhoneRecord[] records)
//         {
//             _records = records;
//         }

//         public void FilterByProvider(string provider)
//         {
//             var filteredNumbers = _records
//                 .Where(r => r.Provider.Equals(provider, StringComparison.OrdinalIgnoreCase))
//                 .Select(r => r.Number);

//             Console.WriteLine($"\nНомера оператора {provider}:");
//             foreach (var number in filteredNumbers)
//             {
//                 Console.WriteLine(number);
//             }
//             Console.WriteLine();
//         }

//         public void FilterByYear(uint year)
//         {
//             var filteredNumbers = _records
//                 .Where(r => r.Year == year)
//                 .Select(r => r.Number);

//             Console.WriteLine($"\nНомера {year} года:");
//             foreach (var number in filteredNumbers)
//             {
//                 Console.WriteLine(number);
//             }
//             Console.WriteLine();
//         }

//         public void GroupByProvider()
//         {
//             var groupedRecords = _records
//                 .GroupBy(r => r.Provider);

//             Console.WriteLine("\nГруппировка по операторам:");
//             foreach (var group in groupedRecords)
//             {
//                 Console.WriteLine($"Оператор: {group.Key}");
//                 foreach (var record in group)
//                 {
//                     Console.WriteLine($"{record.Number}, {record.Owner}, {record.Year}");
//                 }
//                 Console.WriteLine();
//             }
//         }

//         public void GroupByYear()
//         {
//             var groupedRecords = _records
//                 .GroupBy(r => r.Year);

//             Console.WriteLine("\nГруппировка по годам:");
//             foreach (var group in groupedRecords)
//             {
//                 Console.WriteLine($"Год: {group.Key}");
//                 foreach (var record in group)
//                 {
//                     Console.WriteLine($"{record.Number}, {record.Owner}, {record.Provider}");
//                 }
//                 Console.WriteLine();
//             }
//         }
//     }

//     public class Program
//     {
//         public static void Main()
//         {
//             var database = new[]
//             {
//                 new PhoneRecord(123, "Ivan", 2000, "Tele1"),
//                 new PhoneRecord(9999, "Petr", 2010, "Tele1"),
//                 new PhoneRecord(789432985, "Alex", 2010, "NTS")
//             };

//             var manager = new PhoneDatabaseManager(database);

//             int choice;
//             do
//             {
//                 DisplayMenu();
//                 choice = GetUserChoice();

//                 switch (choice)
//                 {
//                     case 1:
//                         Console.Write("\nВведите оператора: ");
//                         manager.FilterByProvider(Console.ReadLine());
//                         break;
//                     case 2:
//                         Console.Write("\nВведите год: ");
//                         if (uint.TryParse(Console.ReadLine(), out var year))
//                             manager.FilterByYear(year);
//                         else
//                             Console.WriteLine("Некорректный год");
//                         break;
//                     case 3:
//                         manager.GroupByProvider();
//                         break;
//                     case 4:
//                         manager.GroupByYear();
//                         break;
//                     case 5:
//                         Console.WriteLine("Выход...");
//                         break;
//                     default:
//                         Console.WriteLine("Неверный выбор");
//                         break;
//                 }
//             } while (choice != 5);
//         }

//         private static void DisplayMenu()
//         {
//             Console.WriteLine("\nМеню:");
//             Console.WriteLine("1. Фильтр по оператору");
//             Console.WriteLine("2. Фильтр по году");
//             Console.WriteLine("3. Группировка по операторам");
//             Console.WriteLine("4. Группировка по годам");
//             Console.WriteLine("5. Выход");
//             Console.Write("Выберите действие: ");
//         }

//         private static int GetUserChoice()
//         {
//             int choice;
//             while (!int.TryParse(Console.ReadLine(), out choice))
//             {
//                 Console.Write("Ошибка ввода. Введите число: ");
//             }
//             return choice;
//         }
//     }
// }

// задача 2
// using System;
// using System.Linq;

// namespace InventoryManagementSystem
// {
//     public class Product
//     {
//         public uint Id { get; }
//         public string Name { get; }

//         public Product(uint id, string name)
//         {
//             Id = id;
//             Name = name;
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

//     public class Transaction
//     {
//         public uint ProductId { get; }
//         public uint VendorId { get; }
//         public bool IsSale { get; }
//         public uint Quantity { get; }
//         public uint UnitPrice { get; }
//         public string Date { get; }

//         public Transaction(uint productId, uint vendorId, uint quantity, uint price, string date)
//         {
//             ProductId = productId;
//             VendorId = vendorId;
//             IsSale = false;
//             Quantity = quantity;
//             UnitPrice = price;
//             Date = date;
//         }

//         public Transaction(uint productId, uint quantity, uint price, string date)
//         {
//             ProductId = productId;
//             VendorId = 0;
//             IsSale = true;
//             Quantity = quantity;
//             UnitPrice = price;
//             Date = date;
//         }
//     }

//     public class InventoryManager
//     {
//         private readonly Product[] _products;
//         private readonly Vendor[] _vendors;
//         private readonly Transaction[] _transactions;

//         public InventoryManager(Product[] products, Vendor[] vendors, Transaction[] transactions)
//         {
//             _products = products;
//             _vendors = vendors;
//             _transactions = transactions;
//         }

//         public void DisplayStockLevels()
//         {
//             var stockLevels = _products.Select(product => new
//             {
//                 Product = product,
//                 Stock = _transactions
//                     .Where(t => t.ProductId == product.Id)
//                     .Sum(t => t.IsSale ? -t.Quantity : t.Quantity)
//             });

//             Console.WriteLine("\nТекущие остатки:");
//             foreach (var item in stockLevels)
//             {
//                 Console.WriteLine($"{item.Product.Name} (ID: {item.Product.Id}): {item.Stock} шт.");
//             }
//             Console.WriteLine();
//         }

//         public void DisplayPurchasesByVendor()
//         {
//             var purchases = _vendors.Select(vendor => new
//             {
//                 Vendor = vendor,
//                 Transactions = _transactions
//                     .Where(t => !t.IsSale && t.VendorId == vendor.Id)
//                     .GroupBy(t => t.VendorId)
//             });

//             Console.WriteLine("\nПоставки по поставщикам:");
//             foreach (var vendorData in purchases)
//             {
//                 Console.WriteLine($"Поставщик: {vendorData.Vendor.Name} (ID: {vendorData.Vendor.Id})");
//                 foreach (var transactionGroup in vendorData.Transactions)
//                 {
//                     foreach (var transaction in transactionGroup)
//                     {
//                         Console.WriteLine($"Товар: {transaction.ProductId}, Количество: {transaction.Quantity}, Цена: {transaction.UnitPrice}, Дата: {transaction.Date}");
//                     }
//                 }
//                 Console.WriteLine();
//             }
//         }

//         public void DisplaySalesByDate()
//         {
//             var salesByDate = _transactions
//                 .Where(t => t.IsSale)
//                 .GroupBy(t => t.Date);

//             Console.WriteLine("\nПродажи по датам:");
//             foreach (var dateGroup in salesByDate)
//             {
//                 Console.WriteLine($"Дата: {dateGroup.Key}");
//                 foreach (var transaction in dateGroup)
//                 {
//                     Console.WriteLine($"Товар: {transaction.ProductId}, Количество: {transaction.Quantity}, Цена: {transaction.UnitPrice}");
//                 }
//                 Console.WriteLine();
//             }
//         }

//         public void DisplayRevenue()
//         {
//             var revenueByProduct = _products.Select(product => new
//             {
//                 Product = product,
//                 Revenue = _transactions
//                     .Where(t => t.ProductId == product.Id && t.IsSale)
//                     .Sum(t => t.Quantity * t.UnitPrice)
//             });

//             Console.WriteLine("\nВыручка по товарам:");
//             foreach (var item in revenueByProduct)
//             {
//                 Console.WriteLine($"{item.Product.Name} (ID: {item.Product.Id}): {item.Revenue} руб.");
//             }
//             Console.WriteLine();
//         }

//         public void DisplayTopVendor()
//         {
//             var topVendor = _vendors
//                 .Select(vendor => new
//                 {
//                     Vendor = vendor,
//                     TotalQuantity = _transactions
//                         .Where(t => !t.IsSale && t.VendorId == vendor.Id)
//                         .Sum(t => t.Quantity)
//                 })
//                 .OrderByDescending(v => v.TotalQuantity)
//                 .FirstOrDefault();

//             Console.WriteLine("\nТоп поставщик:");
//             Console.WriteLine($"{topVendor.Vendor.Name} (ID: {topVendor.Vendor.Id}) поставил {topVendor.TotalQuantity} единиц товара");
//             Console.WriteLine();
//         }
//     }

//     public class Program
//     {
//         public static void Main()
//         {
//             var products = new[]
//             {
//                 new Product(2131, "Сосиски"),
//                 new Product(2243, "Курица"),
//                 new Product(6765, "Телефоны"),
//                 new Product(6981, "Телевизоры")
//             };

//             var vendors = new[]
//             {
//                 new Vendor(21, "Ферма"),
//                 new Vendor(68, "Завод электроники")
//             };

//             var transactions = new[]
//             {
//                 new Transaction(products[0].Id, vendors[0].Id, 15, 100, "01.01.2000"),
//                 new Transaction(products[0].Id, 8, 160, "02.01.2000"),
//                 new Transaction(products[1].Id, vendors[0].Id, 11, 200, "02.01.2000"),
//                 new Transaction(products[1].Id, 11, 350, "05.01.2000"),
//                 new Transaction(products[2].Id, vendors[1].Id, 5, 5000, "15.01.2000"),
//                 new Transaction(products[2].Id, 2, 7500, "17.01.2000"),
//                 new Transaction(products[3].Id, vendors[1].Id, 2, 30000, "15.01.2000"),
//                 new Transaction(products[3].Id, 1, 52000, "17.01.2000")
//             };

//             var manager = new InventoryManager(products, vendors, transactions);

//             int choice;
//             do
//             {
//                 DisplayMenu();
//                 choice = GetUserChoice();

//                 switch (choice)
//                 {
//                     case 1:
//                         manager.DisplayStockLevels();
//                         break;
//                     case 2:
//                         manager.DisplayPurchasesByVendor();
//                         break;
//                     case 3:
//                         manager.DisplaySalesByDate();
//                         break;
//                     case 4:
//                         manager.DisplayRevenue();
//                         break;
//                     case 5:
//                         manager.DisplayTopVendor();
//                         break;
//                     case 6:
//                         Console.WriteLine("Выход из программы...");
//                         break;
//                     default:
//                         Console.WriteLine("Неверный выбор. Попробуйте снова.");
//                         break;
//                 }
//             } while (choice != 6);
//         }

//         private static void DisplayMenu()
//         {
//             Console.WriteLine("\nМеню управления складом:");
//             Console.WriteLine("1. Показать остатки товаров");
//             Console.WriteLine("2. Показать поставки по поставщикам");
//             Console.WriteLine("3. Показать продажи по датам");
//             Console.WriteLine("4. Показать выручку");
//             Console.WriteLine("5. Показать топ поставщика");
//             Console.WriteLine("6. Выход");
//             Console.Write("Выберите действие: ");
//         }

//         private static int GetUserChoice()
//         {
//             int choice;
//             while (!int.TryParse(Console.ReadLine(), out choice))
//             {
//                 Console.Write("Ошибка ввода. Введите число от 1 до 6: ");
//             }
//             return choice;
//         }
//     }
// }