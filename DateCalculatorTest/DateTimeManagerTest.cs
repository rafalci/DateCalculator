using DateCalculator.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DateCalculatorTest
{
    [TestClass]
    public class DateTimeManagerTest
    {
        [TestMethod]
        public void IsValidDate_CorrectFormat_True()
        {
            bool value = DateTimeManager.IsValidDate("01.01.2012");

            Assert.IsTrue(value);
        }

        [TestMethod]
        public void IsValidDate_IncorrectFormat_False()
        {
            bool value = DateTimeManager.IsValidDate("21.20.2001");

            Assert.IsFalse(value);
        }

        [TestMethod]
        public void RevertDatesIfNeeded_FirstDateLessThanSecond_LeaveAsItIs()
        {
            DateTime date1 = new DateTime(2000, 12, 1);
            DateTime date2 = new DateTime(2000, 12, 20);

            DateTimeManager.RevertDatesIfNeeded(ref date1, ref date2);

            Assert.IsTrue(date1 <= date2);
        }

        [TestMethod]
        public void RevertDatesIfNeeded_FirstDateEqualToSecond_LeaveAsItIs()
        {
            DateTime date1 = new DateTime(2018, 4, 16);
            DateTime date2 = new DateTime(2018, 4, 16);

            DateTimeManager.RevertDatesIfNeeded(ref date1, ref date2);

            Assert.IsTrue(date1 <= date2);
        }

        [TestMethod]
        public void RevertDatesIfNeeded_FirstDateGreaterThanSecond_Revert()
        {
            DateTime date1 = new DateTime(2018, 4, 16);
            DateTime date2 = new DateTime(2006, 2, 2);

            DateTimeManager.RevertDatesIfNeeded(ref date1, ref date2);

            Assert.IsTrue(date1 <= date2);
        }

        [TestMethod]
        public void CalculateDates_SameYear_CutYear()
        {
            DateTime date1 = new DateTime(2000, 10, 1);
            DateTime date2 = new DateTime(2000, 12, 20);

            string value = DateTimeManager.CalculateDates(date1, date2);

            string expected = "01.10 - 20.12.2000";

            Assert.AreEqual(value, expected);
        }

        [TestMethod]
        public void CalculateDates_SameYearAndMonth_CutYearAndMonth()
        {
            DateTime date1 = new DateTime(1994, 2, 5);
            DateTime date2 = new DateTime(1994, 2, 8);

            string value = DateTimeManager.CalculateDates(date1, date2);

            string expected = "05 - 08.02.1994";

            Assert.AreEqual(value, expected);
        }

        [TestMethod]
        public void CalculateDates_CompletelyDifferentDates_DisplayInFull()
        {
            DateTime date1 = new DateTime(1999, 1, 10);
            DateTime date2 = new DateTime(2011, 12, 25);

            string value = DateTimeManager.CalculateDates(date1, date2);

            string expected = "10.01.1999 - 25.12.2011";

            Assert.AreEqual(value, expected);
        }
    }
}
