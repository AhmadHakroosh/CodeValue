using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinqAndObjects
{
    static class Extenssions
    {
        public static void CopyTo(this object obj, object to)
        {
            obj.GetType().GetProperties().Where(v => v.CanWrite == true).ToList().ForEach(v => to.GetType().GetProperty(v.Name).SetValue(to, v.GetValue(obj, null), null));
        }
    }

    class Test
    {
        public int NoWrite { get; }
        public int Normal { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var test1 = new Test { Normal = 1 };
            var test2 = new Test { Normal = 32 };
            test1.CopyTo(test2);
            Debug.Assert(test2.Normal == 1);

            foreach (var item in Assembly.Load("mscorlib").GetTypes().Where(v => v.IsInterface))
                Console.WriteLine(item);

            foreach (var item in Process.GetProcesses().Where(v => v.Threads.Count < 5).OrderBy(v => v.Id))
                Console.WriteLine($"name: {item.ProcessName}, id: {item.Id}, start time: {Try(() => item.StartTime.ToString())}");

            foreach (var item in Process.GetProcesses().Where(v => v.Threads.Count < 5).OrderBy(v => v.Id).GroupBy(v => v.BasePriority))
                Console.WriteLine($"BasePriority: {item.Key}, Count: {item.Count()}");

            Console.WriteLine($"Total Threads: {Process.GetProcesses().Sum(v => v.Threads.Count)}");

            Console.ReadKey();
        }

        static string Try(Func<string> action)
        {
            try
            {
                return action();
            }
            catch { }

            return "";
        }
    }
}