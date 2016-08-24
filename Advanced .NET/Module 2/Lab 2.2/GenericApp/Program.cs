using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp
{
    class Program
    {
        //1. You don't have to write "Attribute", you can remove the postfix. [Key] is suffcient.
        //2. You are using this class as a key, but you did not override the GetHashCode and the Equals method, which are necessary for IDictionary to work properly.
        //3. Interesting solution.
        //4. You code does not compile.
        [KeyAttribute]
        public struct IntEx
        {
            //It isn't good for the key to be mutable. What will happen if someone will change the state of the object? The 'Key' will change but the value will remain.
            //Due to that the Hash Table may return valus that you did not expect.
            public int Value { get; }

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

        public class StringEx
        {
            public string Value { get; }

            public StringEx()
                : this(string.Empty)
            {
                
            }

            public StringEx(string value)
            {
                Value = value;
            }

            public override bool Equals(object obj)
            {
                var casted = obj as StringEx;
                if (null == casted)
                {
                    return false;
                }

                return casted.Value == Value;
            }

            public override int GetHashCode() => Value?.GetHashCode() ?? 0;

            public override string ToString() => Value;

            public static implicit operator StringEx(string value)
            {
                return new StringEx(value);
            }
        }


        static void Main(string[] args)
        {
            var multiDictionary = new MultiDictionary<IntEx, StringEx>();

            multiDictionary.CreateNewValue(1);

            multiDictionary.Add(1, "one");
            multiDictionary.Add(2, "two");
            multiDictionary.Add(3, "three");

            multiDictionary.Add(1, "ich");
            multiDictionary.Add(2, "nee");
            multiDictionary.Add(3, "sun");

            //Good. It throws an exception
            var dictionary = new MultiDictionary<double, StringEx> {{0.1, "bla"}};

            PrintMultiDic(multiDictionary);
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private static void PrintMultiDic<T>(MultiDictionary<T, StringEx> multiDictionary) where T: struct
        {
            foreach (var item in multiDictionary)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
