using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    class Program
    {
        public static List<int> CalcPrimes(int a, int b)
        {
            List<int> primes = new List<int>();
            for (int i = a; i < b; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }
            return primes;
        }

        private static bool IsPrime(int a)
        {
            if (a == 2) return true;
            else if ((a & 1) == 0) return false;
            else
            {
                for (int i = 3; i * i < a; i++)
                {
                    if ((a % i) == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Please enter range start: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Please enter range end: ");
            int b = int.Parse(Console.ReadLine());

            List<int> primes = CalcPrimes(a, b);

            Console.WriteLine($"There are {primes.Count} prime numbers between {a} and {b}:");
            foreach (var prime in primes)
            {
                Console.Write($"{prime} ");
            }
            Console.Read();
        }
    }
}
