using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateCalculator.Managers
{
    public static class ConsoleManager
    {
        public static StringBuilder Header { get; set; }

        static ConsoleManager()
        {
            Header = new StringBuilder();
        }

        public static void WriteLine(string text)
        {
            RefreshHeader();
            Console.WriteLine(text);
        }

        public static void Write(string text)
        {
            RefreshHeader();
            Console.Write(text);
        }

        public static void RefreshHeader()
        {         
            Console.Clear();
            Console.WriteLine("===================================================================================");
            Console.WriteLine();
            Console.Write(Header.ToString());
            Console.WriteLine("===================================================================================");
            Console.WriteLine();
        }
    }
}
