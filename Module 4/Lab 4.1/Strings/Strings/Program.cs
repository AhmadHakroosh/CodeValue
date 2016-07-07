using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string sentence = Console.ReadLine();

                if (sentence == null)
                {
                    return;
                }

                else
                {
                    string[] words = sentence.Split(' ');
                    Console.WriteLine($"The sentence contains {words.Length} words.");
                    Array.Reverse(words);
                    Console.WriteLine($"After reversing the words: {string.Join(" ", words)}.");
                    Array.Sort(words);
                    Console.WriteLine($"The sorted array is: {string.Join(" ", words)}.");
                }
            }
        }
    }
}
