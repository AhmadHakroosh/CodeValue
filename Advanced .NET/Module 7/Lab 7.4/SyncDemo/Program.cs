using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SyncDemo
{
    class Program
    {
        private readonly static Mutex SyncFileMutex = new Mutex(false, "Test...");
        const string _file = @"c:\temp\data.txt";

        static void Main(string[] args)
        {
            for (int i = 0; i < 10000; i++)
            {
                SyncFileMutex.WaitOne();
                File.AppendAllText(_file, Process.GetCurrentProcess().Id.ToString() + Environment.NewLine);
                SyncFileMutex.ReleaseMutex();
            }
        }
    }
}
