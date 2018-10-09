using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateCalculator.Managers
{
    public static class DateTimeManager
    {
        public static bool IsValidDate(string date)
        {
            try
            {
                string[] splitedDate = date.Split('.');
                int day = Int32.Parse(splitedDate[0]);
                int month = Int32.Parse(splitedDate[1]);
                int year = Int32.Parse(splitedDate[2]);

                DateTime parsed = new DateTime(day, month, day);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void RevertDatesIfNeeded(ref DateTime dateTime1, ref DateTime dateTime2)
        {
            DateTime tempDate = dateTime2;

            if (dateTime1 > dateTime2)
            {
                dateTime2 = new DateTime(dateTime1.Year, dateTime1.Month, dateTime1.Day);
                dateTime1 = tempDate;
            }
        }

        public static string CalculateDates(DateTime date1, DateTime date2)
        {
            if (date1.Year == date2.Year)
            {
                if (date1.Month == date2.Month)
                {
                    return date1.ToString("dd") + " - " + date2.ToString("dd.MM.yyyy");
                }

                return date1.ToString("dd.MM") + " - " + date2.ToString("dd.MM.yyyy");
            }

            return date1.ToString("dd.MM.yyyy") + " - " + date2.ToString("dd.MM.yyyy");
        }
    }
}
