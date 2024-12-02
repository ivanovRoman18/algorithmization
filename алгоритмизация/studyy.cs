using System;

namespace project{
    class Studyy
    {
        static void Main(){
            Console.Write("Введите количество символов: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите число");
            int last = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Введите число");
            int cur = int.Parse(Console.ReadLine());

            int localmax = 0;
            bool necht  = true;
            int maxi1=0;
            int maxi2=0;
            byte q = 0;
            int del5 = 0; 
            if (last%10==5){
                del5++;
            }
            if (cur%10==5){
                del5++;
            }
            
            for(int i=2; i<n; i++){
                Console.WriteLine("Введите число");
                int next = int.Parse(Console.ReadLine());
                if (last<cur && cur> next){
                    localmax +=1;
                }
                if (next%10==5){
                    del5++;
                }

                while(q<1){
                    maxi1 = Math.Max(last,Math.Max(cur,next));
                    maxi2 = last+cur+next - maxi1 - Math.Min(last,Math.Min(cur,next));
                    q++;
                }
                
                if (maxi1>next){
                    maxi2 = Math.Max(maxi2,next);
                }
                else{
                    maxi2=maxi1;
                    maxi1 = next;
                }
                
                if (last % 2 == 0 || cur % 2 == 0 || next % 2 == 0){
                    necht = false;
                }
                
                last = cur;
                cur = next;
            }   
            Console.Write("количесвто локальных максимумов: ");
            Console.WriteLine(localmax);
            Console.WriteLine("второй максимальный элемент {0}", maxi2);
            Console.WriteLine("элементов которые оканчиваются на 5:  {0} штук", del5);

            if (necht== true){
                Console.WriteLine("все элементы нечётные");
            }
            else{
                System.Console.WriteLine("есть чётные элемент(ы)");
            }
              
            }
        }
    }



