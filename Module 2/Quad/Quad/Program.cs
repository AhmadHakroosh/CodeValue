using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quad
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c;
            while (true)
            {
                Console.WriteLine("Enter a new Quadratic Equation:");
                String equation = Console.ReadLine();
                String[] arguments = equation.Split(' ');

                if (arguments.Length != 3)
                {
                    Console.WriteLine("Invalid number of arguments!");
                }

                else
                {
                    if (!double.TryParse(arguments[0], out a))
                    {
                        Console.WriteLine($"{arguments[0]} is not a valid argument!");
                        continue;
                    }

                    if (!double.TryParse(arguments[1], out b))
                    {
                        Console.WriteLine($"{arguments[1]} is not a valid argument!");
                        continue;
                    }

                    if (!double.TryParse(arguments[2], out c))
                    {
                        Console.WriteLine($"{arguments[2]} is not a valid argument!");
                        continue;
                    }

                    double sqrt = (b*b) - (4*a*c);

                    if (sqrt > 0)
                    {
                        Console.WriteLine($"First root: {(-b + Math.Sqrt(sqrt)) / (2 * a)}, Second root: {(-b - Math.Sqrt(sqrt)) / (2 * a)}");
                    }

                    else if (sqrt < 0)
                    {
                        Console.WriteLine("There is no solution for this equation!");
                    }

                    else
                    {
                        Console.WriteLine($"Root: {-b / (2 * a)}");
                    }
                }
            }
        }
    }
}
