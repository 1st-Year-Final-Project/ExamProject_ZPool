using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZPool.Services.Interface;

namespace ZPool.Helpers
{
    public class DateTimeComparer : IDateTimeComparer
    {
        /// <summary>
        /// Compares the DateTimes and returns true if A is in range of plus/minus 2 hours of B.
        /// </summary>
        /// <param name="compareValue"></param>
        /// <param name="filterCriteria"></param>
        /// <returns>bool</returns>
        public bool CompareDateTime(DateTime compareValue, DateTime filterCriteria)
        {
            if (compareValue.CompareTo(filterCriteria) == 0)
            {
                return true;
            }

            if (CompareDate(compareValue, filterCriteria))
            {
                if (CompareHours(compareValue, filterCriteria)) return true;
            }

            return false;
        }

        /// <summary>
        /// Compares only the date and returns true if A and B are the same day.
        /// </summary>
        /// <param name="dateTimeA"></param>
        /// <param name="dateTimeB"></param>
        /// <returns>bool</returns>
        public bool CompareDate(DateTime dateTimeA, DateTime dateTimeB)
        {
            var dateA = dateTimeA.Date;
            var dateB = dateTimeB.Date;

            if (dateA == dateB)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Compares the hour value of the DateTime.
        /// Returns all DateTimes in range of plus/minus 2 hours.
        /// </summary>
        /// <param name="dateTimeA"></param>
        /// <param name="dateTimeB"></param>
        /// <returns>bool</returns>
        private bool CompareHours(DateTime dateTimeA, DateTime dateTimeB)
        {
            int hourA = dateTimeA.Hour;
            int hourB = dateTimeB.Hour;

            if (hourA == hourB) return true;
            if (hourA >= hourB - 2 && hourA <= hourB + 2) return true;
            else
                return false;
        }
    }
}
