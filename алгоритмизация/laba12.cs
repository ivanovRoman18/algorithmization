using System;
using System.Collections.Generic;

// Будут два наследника одного класса, простенькая задача.
//  1 класс будет печка характеризоваться объект будет следующими полями температура, время ( задавать в минутах),
//   два класса наследниками класса печь, клас хлеб- наследник класса печи, поля будут из класса печь + будут свои поля характеризующие наименование хлеба и вес,
//    второй наследник от класса печь - мясо ( будет наименование и вес) поля одинаковые, будет меню по заполнению создаваться база по хлебу по мясу, 
//    поиск осуществляется по времени приготовления то есть мы берём и хлеб и мясо, поиск например по температурному режиму берём общее, выдавать все данные,
//     перед тем как осуществлять поиск должно быть заполнение,

// Базовый класс "Печь"
public class Oven
{
    public int Temperature { get; set; }
    public int Time { get; set; }

    public Oven(int temperature, int time)
    {
        Temperature = temperature;
        Time = time;
    }
}

// Класс-наследник "Хлеб"
public class Bread : Oven
{
    public string Name { get; set; }
    public int Weight { get; set; }

    public Bread(string name, int weight, int temperature, int time) : base(temperature, time)
    {
        Name = name;
        Weight = weight;
    }
        public override string ToString()
        {
        return $"Хлеб: {Name}, вес: {Weight} г, темп.: {Temperature}°C, время: {Time} мин";
    }
}

// Класс-наследник "Мясо"
public class Meat : Oven
{
    public string Name { get; set; }
    public int Weight { get; set; }

    public Meat(string name, int weight, int temperature, int time) : base(temperature, time)
    {
        Name = name;
        Weight = weight;
    }
      public override string ToString()
        {
            return $"Мясо: {Name}, вес: {Weight} г, темп.: {Temperature}°C, время: {Time} мин";
        }
}

class Program
{
    static List<Bread> breadDatabase = new List<Bread>();
    static List<Meat> meatDatabase = new List<Meat>();
    
    static void Main(string[] args)
    {
        int choice = 0;
        while (choice != 5)
        {
            DisplayMenu();

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Ошибка: Неверный ввод, введите число от 1 до 5.");
                continue;
            }
            Console.WriteLine();
            switch (choice)
            {
                case 1:
                    AddFoodToDatabase();
                    break;
                case 2:
                    SearchByTime();
                    break;
                case 3:
                    SearchByTemperature();
                    break;
                case 4:
                    DisplayAllData();
                    break;
                case 5:
                    Console.WriteLine("Программа завершена.");
                    break;
                default:
                    Console.WriteLine("Ошибка: Неверный выбор пункта меню. Выберите от 1 до 5.");
                    break;
            }
        }
    }
   static void DisplayMenu()
    {
        Console.WriteLine("Меню:");
        Console.WriteLine("1. Заполнение баз данных");
        Console.WriteLine("2. Поиск по времени приготовления");
        Console.WriteLine("3. Поиск по температурному режиму");
        Console.WriteLine("4. Вывести все данные");
        Console.WriteLine("5. Выход");
        Console.Write("Выберите пункт: ");
    }
   static void AddFoodToDatabase()
    {
        Console.WriteLine("Выберите, что добавить:");
        Console.WriteLine("1. Хлеб");
        Console.WriteLine("2. Мясо");
        Console.Write("Выберите пункт: ");
        int choice = Convert.ToInt32(Console.ReadLine());
        if (choice == 1)
        {
           AddBread();
        }
        else
        {
           AddMeat();
        }
    }
    static void AddBread()
    {
        Console.Write("Введите название хлеба: ");
        string name = Console.ReadLine();
        Console.Write("Введите вес хлеба (г): ");
        int weight = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите температуру (°C): ");
        int temperature = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите время (мин): ");
        int time = Convert.ToInt32(Console.ReadLine());
        breadDatabase.Add(new Bread(name, weight, temperature, time));
        Console.WriteLine("Хлеб добавлен.\n");
    }
    static void AddMeat()
     {
        Console.Write("Введите название мяса: ");
        string name = Console.ReadLine();
        Console.Write("Введите вес мяса (г): ");
        int weight = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите температуру приготовления(°C): ");
        int temperature = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите время приготовления(мин): ");
        int time  = Convert.ToInt32(Console.ReadLine());
        meatDatabase.Add(new Meat(name, weight, temperature, time));
        Console.WriteLine("Мясо добавлено.\n");
    }
    static void SearchByTime()
    {
        Console.Write("Введите минимальное время приготовления (мин): ");
        int minTime = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Результаты поиска по времени приготовления:\n");
        Console.WriteLine("Хлеб:");
        bool breadFound = false;
        foreach (var bread in breadDatabase)
        {
            if (bread.Time >= minTime)
            {
                Console.WriteLine(bread);
                breadFound = true;
            }
        }
         if (!breadFound)
        {
           Console.WriteLine("Нет хлеба с таким временем.\n");
        }
           Console.WriteLine("\nМясо:");
        bool meatFound = false;
         foreach (var meat in meatDatabase)
        {
            if (meat.Time >= minTime)
            {
                Console.WriteLine(meat);
                meatFound = true;
            }
        }
         if (!meatFound)
        {
           Console.WriteLine("Нет мяса с таким временем.\n");
        }
    }

    static void SearchByTemperature()
    {
        Console.Write("Введите температуру (°C): ");
        int targetTemperature = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Результаты поиска по температуре:\n");
        Console.WriteLine("Хлеб:");
        bool breadFound = false;
        foreach (var bread in breadDatabase)
        {
            if (bread.Temperature == targetTemperature)
           {
                Console.WriteLine(bread);
                 breadFound = true;
            }
        }
        if (!breadFound)
        {
             Console.WriteLine("Нет хлеба с такой температурой.\n");
        }

        Console.WriteLine("\nМясо:");
        bool meatFound = false;
         foreach (var meat in meatDatabase)
        {
            if (meat.Temperature == targetTemperature)
            {
                Console.WriteLine(meat);
                meatFound = true;
            }
        }
         if (!meatFound)
        {
            Console.WriteLine("Нет мяса с такой температурой.\n");
        }
    }
    static void DisplayAllData()
   {
      Console.WriteLine("Данные по хлебу:");
       if (breadDatabase.Count == 0)
       {
          Console.WriteLine("Нет данных о хлебе.\n");
        }
      else
       {
           foreach (var bread in breadDatabase)
            {
                Console.WriteLine(bread);
            }
         Console.WriteLine(); 

      Console.WriteLine("Данные по мясу:");
       if (meatDatabase.Count == 0)
       {
           Console.WriteLine("Нет данных о мясе.\n");
        }
       else
      {
            foreach (var meat in meatDatabase)
            {
                Console.WriteLine(meat);
            }
        Console.WriteLine(); // отступ
      }
   }
}
}