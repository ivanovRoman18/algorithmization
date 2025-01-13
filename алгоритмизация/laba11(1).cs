//Задача 1

    //Меню

    //Дан класс "Печь", в котором выставляются поля "температура", "длительность".
    //Дан класс "Хлеб", в котором выставляются поля от родителя("температура", "длительность (время выпечки)"),
    //"наименование (пшеничный, урожайный и т.д.)"

    //Конструктор с отсылкой на базовый

    //Создать меню с пунктами, где будет заполнение базы данных(по хлебу) - массив(или список)
    //Выборка по длительности(всё, что печётся дольше, чем заданное время, можно в часах и минутах или просто в минутах)
    //Выборка по температурному режиму(всё, что печётся при заданной температуре)

    //Если база не заполнена, то выводить это(выборка невозоможна)

    //Возвращаться в главное меню(while).

    //Меню:
    //1. Заполение
    //2. Выборка по длительности
    //3. Выборка по температуре
    //4. Выход

using System;

// Класс "Печь" (базовый класс)
public class Oven
{
    public int Temperature { get; set; }
    public int Duration { get; set; }

    public Oven(int temperature, int duration)
    {
        Temperature = temperature;
        Duration = duration;
    }
}

// Класс "Хлеб" (наследуется от "Печь")
public class Bread : Oven
{
    public string Name { get; set; }

    public Bread(int temperature, int duration, string name) : base(temperature, duration)
    {
        Name = name;
    }

    public override string ToString()
    {
        return $"Название: {Name}, Температура: {Temperature}°C, Длительность: {Duration} мин.";
    }
}

public class Program
{
    static List<Bread> breadList = new List<Bread>();
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Заполнение базы данных (хлеб)");
            Console.WriteLine("2. Выборка по длительности");
            Console.WriteLine("3. Выборка по температуре");
            Console.WriteLine("4. Выход");
            Console.Write("Выберите пункт меню: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddBread();
                    break;
                case "2":
                    SearchByDuration();
                    break;
                case "3":
                    SearchByTemperature();
                    break;
                case "4":
                    Console.WriteLine("Программа завершена.");
                    return;
                default:
                    Console.WriteLine("Неверный пункт меню, попробуйте еще раз.");
                    break;
            }
        }
    }

    static void AddBread()
    {
        Console.Write("Введите название хлеба: ");
        string name = Console.ReadLine();
        Console.Write("Введите температуру выпекания (°C): ");
        int temperature= Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите длительность выпекания (в минутах): ");
        int duration = Convert.ToInt32(Console.ReadLine());
        
        breadList.Add(new Bread(temperature, duration, name));
        Console.WriteLine("Хлеб добавлен в базу данных.");
    }

    static void SearchByDuration()
    {
        if (breadList.Count == 0)
        {
            Console.WriteLine("База данных пуста. Заполнение невозможно.");
             return;
        }
        Console.Write("Введите минимальную длительность выпекания (в минутах): ");
        int minDuration = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"\nХлеб с длительностью более {minDuration} минут:");
        bool found = false;
        foreach (Bread bread in breadList)
        {
            if (bread.Duration > minDuration)
            {
                Console.WriteLine(bread);
                found = true;
            }
        }

        if (!found)
        {
           Console.WriteLine("Не найдено хлеба с заданной длительностью.");
        }
    }

    static void SearchByTemperature()
    {
        if (breadList.Count == 0)
        {
            Console.WriteLine("База данных пуста. Заполнение невозможно.");
            return;
        }
        Console.Write("Введите температуру выпекания (°C): ");
        int temperature = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine($"\nХлеб, выпекающийся при {temperature}°C:");
        bool found = false;
        foreach (Bread bread in breadList)
        {
            if (bread.Temperature == temperature)
            {
                Console.WriteLine(bread);
                 found = true;
            }
        }
          if (!found)
        {
           Console.WriteLine("Не найдено хлеба с заданной температурой.");
        }
    }
}