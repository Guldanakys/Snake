using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primenum
{
    class Program
    {
        static bool Prime(string s)
        {
            // меняем строку в число
            int x = int.Parse(s);
            int cnt = 0;

            // запускаем цикл для нахождения делителей
            for (int j = 2; j <= Math.Sqrt(x); ++j)
            {
                if (x % j == 0)
                {
                    cnt++;
                }
            }
            // возвращаем значения
            return cnt == 0 && x != 1;
        }
        static void Main(string[] args)
        {
            // вытаскиваем числа
            for( int i = 0; i < args.Length; ++i )
            {
                if (Prime(args[i]))
                {
                    Console.WriteLine(args[i] + " is prime");
                }
                else
                {
                    Console.WriteLine(args[i] + " is not prime");
                }
            }

            Console.ReadKey();
        }
    }
}
