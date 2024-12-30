using System;

// Крестьянин и чёрт
namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxi = Convert.ToInt32(Console.ReadLine());
            if (1 <= maxi  || maxi <= 200000000)
            {
                int count = 0;
                
                for (int i = 1; i <= maxi; i++)
                {
                    int n = i*2;
                    for (int j = i+1; j <= n; j++)
                    {
                        int Z = 1;
                        int temp = n;
                        while (temp > 0)
                        {
                            temp -= j;
                            if (temp == 0)
                            {
                                count += 1;
                            }
                            Z++;
                            temp *= 2;
                        }
                    }
                }
                Console.WriteLine(count);
            }
        }
    }
}