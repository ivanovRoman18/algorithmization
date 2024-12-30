// отгадай число

using System;

public class RGR1
{
    public static void Main(string[] args)
    {
        // 1. Чтение входных данных
        int numActions = int.Parse(Console.ReadLine());
        string[] actionLines = new string[numActions];
        for (int i = 0; i < numActions; i++)
        {
            actionLines[i] = Console.ReadLine();
        }
        int result = int.Parse(Console.ReadLine());

        // 2. Прямой проход для получения коэффициентов
        int xCoefficient = 1;
        int constantTerm = 0;

        for (int i = 0; i < numActions; i++)
        {
            string action = actionLines[i];
            string[] parts = action.Split(' ');
            string operation = parts[0];
            string value = parts[1];

            if (value == "x")
            {
                if (operation == "+")
                {
                    xCoefficient += 1;
                }
                else if (operation == "-")
                {
                    xCoefficient -= 1;
                }
            }
            else
            {
                int numValue = int.Parse(value);
                if (operation == "+")
                {
                    constantTerm += numValue;
                }
                else if (operation == "-")
                {
                    constantTerm -= numValue;
                }
                else if (operation == "*")
                {
                    constantTerm *= numValue;
                    xCoefficient *= numValue;
                }
            }
        }
        
        // 3. Вычисление X и вывод результата
        if (xCoefficient == 0)
        {
          Console.WriteLine("Невозможно определить задуманное число");
        }
       else
        {
           int x = (result - constantTerm) / xCoefficient;
           Console.WriteLine(x);
        }
    }
}


