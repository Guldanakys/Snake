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

            int x = int.Parse(s);
            int cnt = 0;

            for (int j = 2; j <= Math.Sqrt(x); ++j)
            {
                if (x % j == 0)
                {
                    cnt++;
                }
            }

            return cnt == 0 && x != 1;
        }
        static void Main(string[] args)
        {
            for( int i = 0; i < args.Length; ++i )
            {
                if (Prime(args[i]))
                {
                    Console.WriteLine(args[i] + "is prime");
                }
                else
                {
                    Console.WriteLine(args[i] + "is not prime");
                }
            }
        }
    }
}
