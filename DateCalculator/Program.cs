using DateCalculator.Managers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DateCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Initialize();
            Console.ReadKey();
            Console.WriteLine();

           do
           {
                InitializeHeader();

                DateTime dateTime1 = ReadDateFromConsole();
                ConsoleManager.Header.Replace("1) __ . __ . ____", "1) " + dateTime1.ToShortDateString());
                DateTime dateTime2 = ReadDateFromConsole();
                ConsoleManager.Header.Replace("2) __ . __ . ____", "2) " + dateTime2.ToShortDateString());

                ConsoleManager.RefreshHeader();

                DateTimeManager.RevertDatesIfNeeded(ref dateTime1, ref dateTime2);

                ConsoleManager.Write("The necessary data has been entered. Click any key to calculate...");
                Console.ReadKey();
                ConsoleManager.Write("Calculation...");
                Thread.Sleep(1000);

                ConsoleManager.Header.Replace("______ - ______", DateTimeManager.CalculateDates(dateTime1, dateTime2));
                ConsoleManager.Write("DONE! Click escape to stop...");

            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape) ;
        }

        private static void Initialize()
        {
            Console.WriteLine("================================== HELLO ==================================");
            Console.WriteLine();
            Console.WriteLine("This application will calculate dates provided by you.");
            Console.WriteLine();
            Console.WriteLine("Click any key to continue...");
            Console.WriteLine();
            Console.WriteLine("===========================================================================");
        }

        private static void InitializeHeader()
        {
            ConsoleManager.Header.Clear();
            ConsoleManager.Header.AppendLine("Please enter two dates using the correct date format(DD.MM.YYYY)");
            ConsoleManager.Header.AppendLine();
            ConsoleManager.Header.AppendLine(" 1) __ . __ . ____");
            ConsoleManager.Header.AppendLine(" 2) __ . __ . ____");
            ConsoleManager.Header.AppendLine();
            ConsoleManager.Header.AppendLine("Ignore the display order at this time, it will be changed later(if needed)");
            ConsoleManager.Header.AppendLine();
            ConsoleManager.Header.AppendLine("RESULT: ______ - ______");
            ConsoleManager.Header.AppendLine();
        }

        private static DateTime ReadDateFromConsole()
        {
            string date = null;

            do
            {
                if (date != null)
                {
                    ConsoleManager.Write("Incorrect format!");
                    Console.ReadKey();
                }

                ConsoleManager.Write("Enter a date: ");

                date = Console.ReadLine();
            }
            while (!DateTimeManager.IsValidDate(date));

            return DateTime.Parse(date, new CultureInfo("pl-PL")) ;
        }


    }
}
