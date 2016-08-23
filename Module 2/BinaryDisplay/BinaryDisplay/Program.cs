using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryDisplay
{
    //No UnitTests.
    //No input validations.
    //Wrong result for the count of '1' in negative numbers
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter a number: ");
            int number = int.Parse(Console.ReadLine());
            string binary = Convert.ToString(number, 2);
            Console.WriteLine($"The binary number that represents the one you entered is: {binary}");
            int count = 0;

            while (number > 0)
            {
                count += number & 1;
                number >>= 1;
            }

            Console.WriteLine($"There are {count} 1's in the binary number {binary}");
            Console.ReadLine();
        }
    }
}
