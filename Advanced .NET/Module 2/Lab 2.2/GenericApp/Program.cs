using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp
{
    class Program
    {
        [KeyAttribute]
        public class IntEx
        {
            public int Value { get; set; }

            public IntEx(int value)
            {
                Value = value;
            }

            public override string ToString()
            {
                return Value.ToString();
            }

            public static implicit operator IntEx(int value)
            {
                return new IntEx(value);
            }
        }


        static void Main(string[] args)
        {
            var multiDictionary = new MultiDictionary<IntEx, string>();

            multiDictionary.CreateNewValue(1);

            multiDictionary.Add(1, "one");
            multiDictionary.Add(2, "two");
            multiDictionary.Add(3, "three");

            multiDictionary.Add(1, "ich");
            multiDictionary.Add(2, "nee");
            multiDictionary.Add(3, "sun");

            PrintMultiDic(multiDictionary);
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private static void PrintMultiDic<T>(MultiDictionary<T, string> multiDictionary)
        {
            foreach (var item in multiDictionary)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
