// using System;

// public class Phone
// {
//     public string Number { get; set; }
//     public string Operator { get; set; }
//     public int ContractYear { get; set; }

//     public Phone(string number, string @operator, int contractYear)
//     {
//         Number = number;
//         Operator = @operator;
//         ContractYear = contractYear;
//     }
//     public override string ToString() => $"{Number} ({Operator}) {ContractYear}";
// }

// public class Person
// {
//     public string FullName { get; set; }
//     public Phone[] Phones { get; set; }
//     public string City { get; set; }
//     public int PhoneCount { get; private set; }

//     public Person(string fullName, string city, int maxPhones)
//     {
//         FullName = fullName;
//         Phones = new Phone[maxPhones];
//         City = city;
//         PhoneCount = 0;
//     }

//     public void AddPhone(Phone phone)
//     {
//         Phones[PhoneCount++] = phone;
//     }
//     public override string ToString() => $"{FullName}, {City}\n  {string.Join("\n  ", Phones, 0, PhoneCount)}";
// }

// public class Phonebook
// {
//     public Person[] People { get; set; }
//     public int PersonCount { get; set; }

//     public Phonebook(int maxPeople)
//     {
//         People = new Person[maxPeople];
//         PersonCount = 0;
//     }

//     public void AddPerson(Person person)
//     {
//         People[PersonCount++] = person;
//     }
// }

// public class Program
// {
//     public static void Main(string[] args)
//     {
//         // Set maximum sizes directly
//         int maxPeople = 100;     // Maximum number of people in the phonebook
//         int maxPhones = 5;      // Maximum number of phones per person

//         Phonebook phonebook = new Phonebook(maxPeople);

//         while (true)
//         {
//             Console.WriteLine("\n1. Add | 2. Year | 3. Operator | 4. Number | 5. City | 6. Exit");
//             Console.Write("Choose: ");
//             string choice = Console.ReadLine();

//             switch (choice)
//             {
//                 case "1":
//                     // Add Person
//                     Console.Write("Name: ");
//                     string fullName = Console.ReadLine();
//                     Console.Write("City: ");
//                     string city = Console.ReadLine();
//                     var person = new Person(fullName, city, maxPhones);

//                     while (true)
//                     {
//                         Console.Write("Phone (or Enter): ");
//                         string number = Console.ReadLine();
//                         if (string.IsNullOrEmpty(number)) break;

//                         Console.Write("Operator: ");
//                         string @operator = Console.ReadLine();
//                         Console.Write("Year: ");
//                         int year = int.Parse(Console.ReadLine());

//                         person.AddPhone(new Phone(number, @operator, year));
//                     }
//                     phonebook.AddPerson(person);
//                     Console.WriteLine("Added.");
//                     break;

//                 case "2":
//                     // Select by Contract Year
//                     Console.Write("Year: ");
//                     int contractYear = int.Parse(Console.ReadLine());
//                     for (int i = 0; i < phonebook.PersonCount; i++)
//                     {
//                         Person personToSearch = phonebook.People[i];
//                         for (int j = 0; j < personToSearch.PhoneCount; j++)
//                         {
//                             if (personToSearch.Phones[j].ContractYear == contractYear)
//                             {
//                                 Console.WriteLine(personToSearch);
//                                 Console.WriteLine("---");
//                                 break;
//                             }
//                         }
//                     }
//                     break;

//                 case "3":
//                     // Select by Operator
//                     Console.Write("Operator: ");
//                     string operatorName = Console.ReadLine();
//                     for (int i = 0; i < phonebook.PersonCount; i++)
//                     {
//                         Person personToSearch = phonebook.People[i];
//                         for (int j = 0; j < personToSearch.PhoneCount; j++)
//                         {
//                             if (personToSearch.Phones[j].Operator == operatorName)
//                             {
//                                 Console.WriteLine(personToSearch);
//                                 Console.WriteLine("---");
//                                 break;
//                             }
//                         }
//                     }
//                     break;

//                 case "4":
//                     // Select by Phone Number
//                     Console.Write("Number: ");
//                     string phoneNumber = Console.ReadLine();
//                     for (int i = 0; i < phonebook.PersonCount; i++)
//                     {
//                         Person personToSearch = phonebook.People[i];
//                         for (int j = 0; j < personToSearch.PhoneCount; j++)
//                         {
//                             if (personToSearch.Phones[j].Number == phoneNumber)
//                             {
//                                 Console.WriteLine(personToSearch);
//                                 Console.WriteLine("---");
//                                 break;
//                             }
//                         }
//                     }
//                     break;

//                 case "5":
//                     // Select by City
//                     Console.Write("City: ");
//                     string cityToSearch = Console.ReadLine();
//                     for (int i = 0; i < phonebook.PersonCount; i++)
//                     {
//                         Person personToSearch = phonebook.People[i];
//                         if (personToSearch.City == cityToSearch)
//                         {
//                             Console.WriteLine(personToSearch);
//                             Console.WriteLine("---");
//                         }
//                     }
//                     break;

//                 case "6":
//                     Console.WriteLine("Bye!");
//                     return;
//                 default:
//                     Console.WriteLine("Invalid choice.");
//                     break;
//             }
//         }
//     }
// }