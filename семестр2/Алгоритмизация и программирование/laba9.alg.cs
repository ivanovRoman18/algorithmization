
// задача1

// using System;
// using System.Collections.Generic;

// namespace LibrarySystem
// {
//     public struct BookInfo
//     {
//         public string Author { get; }
//         public string Title { get; }
//         public int ReleaseYear { get; }
//         public string Publisher { get; }

//         public BookInfo(string author, string title, int year, string publisher)
//         {
//             Author = author;
//             Title = title;
//             ReleaseYear = year;
//             Publisher = publisher;
//         }
//     }

//     public struct BorrowRecord
//     {
//         public string BorrowDate { get; }
//         public string ReturnDate { get; }

//         public BorrowRecord(string borrowDate, string returnDate)
//         {
//             BorrowDate = borrowDate;
//             ReturnDate = returnDate;
//         }

//         public bool IsBorrowed => !string.IsNullOrEmpty(BorrowDate) && string.IsNullOrEmpty(ReturnDate);
//         public bool WasNeverBorrowed => string.IsNullOrEmpty(BorrowDate);
//     }

//     public class LibraryEntry
//     {
//         public BookInfo Book { get; }
//         public List<BorrowRecord> BorrowHistory { get; }

//         public LibraryEntry(BookInfo book, List<BorrowRecord> borrowHistory)
//         {
//             Book = book;
//             BorrowHistory = borrowHistory;
//         }

//         public bool WasNeverBorrowed() => BorrowHistory.Count == 1 && BorrowHistory[0].WasNeverBorrowed;
//         public bool IsCurrentlyBorrowed() => BorrowHistory.Count > 0 && BorrowHistory[^1].IsBorrowed;
//     }

//     public class Program
//     {
//         private static List<LibraryEntry> _libraryDatabase = new List<LibraryEntry>();

//         public static void Main()
//         {
//             int choice;
//             do
//             {
//                 DisplayMenu();
//                 choice = GetUserChoice();

//                 switch (choice)
//                 {
//                     case 1:
//                         AddNewBooks();
//                         break;
//                     case 2:
//                         DisplayNeverBorrowedBooks();
//                         break;
//                     case 3:
//                         DisplayCurrentlyBorrowedBooks();
//                         break;
//                     case 4:
//                         Console.WriteLine("Выход из программы.");
//                         break;
//                     default:
//                         Console.WriteLine("Неверный выбор. Попробуйте снова.");
//                         break;
//                 }
//             } while (choice != 4);
//         }

//         private static void DisplayMenu()
//         {
//             Console.WriteLine("\nМеню:");
//             Console.WriteLine("1. Добавить книги");
//             Console.WriteLine("2. Показать книги, которые никогда не выдавались");
//             Console.WriteLine("3. Показать книги, которые сейчас на руках");
//             Console.WriteLine("4. Выход");
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

//         private static void AddNewBooks()
//         {
//             Console.WriteLine("\nДобавление книг (для выхода введите '0' в поле автора)");

//             while (true)
//             {
//                 Console.Write("Автор: ");
//                 string author = Console.ReadLine();
//                 if (author == "0") break;

//                 Console.Write("Название: ");
//                 string title = Console.ReadLine();

//                 Console.Write("Год издания: ");
//                 int year = int.Parse(Console.ReadLine());

//                 Console.Write("Издательство: ");
//                 string publisher = Console.ReadLine();

//                 var book = new BookInfo(author, title, year, publisher);
//                 var borrowHistory = GetBorrowHistory();

//                 _libraryDatabase.Add(new LibraryEntry(book, borrowHistory));
//             }
//         }

//         private static List<BorrowRecord> GetBorrowHistory()
//         {
//             var history = new List<BorrowRecord>();

//             Console.WriteLine("\nВведите данные о выдаче книги (оставьте пустым, если не выдавалась):");

//             while (true)
//             {
//                 Console.Write("Дата выдачи: ");
//                 string borrowDate = Console.ReadLine();

//                 string returnDate = "";
//                 if (!string.IsNullOrEmpty(borrowDate))
//                 {
//                     Console.Write("Дата возврата: ");
//                     returnDate = Console.ReadLine();
//                 }

//                 history.Add(new BorrowRecord(borrowDate, returnDate));

//                 if (string.IsNullOrEmpty(borrowDate) || !string.IsNullOrEmpty(returnDate))
//                     break;
//             }

//             return history;
//         }

//         private static void DisplayNeverBorrowedBooks()
//         {
//             if (_libraryDatabase.Count == 0)
//             {
//                 Console.WriteLine("\nБаза данных пуста.");
//                 return;
//             }

//             Console.WriteLine("\nКниги, которые никогда не выдавались:");

//             bool found = false;
//             foreach (var entry in _libraryDatabase)
//             {
//                 if (entry.WasNeverBorrowed())
//                 {
//                     DisplayBookInfo(entry.Book);
//                     found = true;
//                 }
//             }

//             if (!found) Console.WriteLine("Таких книг нет.");
//         }

//         private static void DisplayCurrentlyBorrowedBooks()
//         {
//             if (_libraryDatabase.Count == 0)
//             {
//                 Console.WriteLine("\nБаза данных пуста.");
//                 return;
//             }

//             Console.WriteLine("\nКниги, которые не возвращены:");

//             bool found = false;
//             foreach (var entry in _libraryDatabase)
//             {
//                 if (entry.IsCurrentlyBorrowed())
//                 {
//                     DisplayBookInfo(entry.Book);
//                     Console.WriteLine($"Дата выдачи: {entry.BorrowHistory[^1].BorrowDate}\n");
//                     found = true;
//                 }
//             }

//             if (!found) Console.WriteLine("Таких книг нет.");
//         }

//         private static void DisplayBookInfo(BookInfo book)
//         {
//             Console.WriteLine($"Автор: {book.Author}");
//             Console.WriteLine($"Название: {book.Title}");
//             Console.WriteLine($"Год издания: {book.ReleaseYear}");
//             Console.WriteLine($"Издательство: {book.Publisher}");
//         }
//     }
// }





// задача 2



// ﻿using System;

// namespace Laba9stroki
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             string input_name = "Input.txt";
//             string file_input = @"C:\Users\ivano\Downloads\project\" + input_name;
//             string output_name = "Output.txt";
//             string file_output = @"C:\Users\ivano\Downloads\project\" + output_name;
//             File.Create(file_input).Close();
//             File.Create(file_output).Close();
//             FileInfo f = new FileInfo(file_input);
//             StreamWriter sw = f.AppendText();
//             sw.WriteLine("1dasdafefwfw2");
//             sw.WriteLine("adwd10dwdwdwadf");
//             sw.WriteLine("dwad12ddwdwad1dawd");
//             sw.WriteLine("dasdfdwd30");
//             sw.WriteLine("dawdfdwdsdf25");
//             sw.Close();

            
//             string text_in = File.ReadAllText(file_input);
//             Console.WriteLine("Входной текст:");
//             Console.WriteLine(text_in);
//             string[] strs = text_in.Split('\n');
//             foreach (string s in strs)
//             {
//                 bool check = false;
//                 string temp_s = "";
//                 int num;
//                 for (int i = 0; i < s.Length; i++)
//                 {
//                     if ("1234567890".Contains(s[i]))
//                         temp_s += s[i];
//                     else
//                     {
//                         bool result = int.TryParse(temp_s, out num);
//                         temp_s = "";
//                         if (result == true) 
//                         {
//                             if (num % 2 == 1)
//                             {
//                                 check = true;
//                                 break;
//                             }
//                         }
//                     }
//                 }
//                 if (check)
//                 {
//                     f = new FileInfo(file_output);
//                     sw = f.AppendText();
//                     sw.WriteLine(s.Remove(s.Count()-1));
//                     sw.Close();
//                 }
//             }

//             string text_out = File.ReadAllText(file_output);
//             Console.WriteLine("Результирующий файл:");
//             Console.WriteLine(text_out);
//         }
//     }
// }