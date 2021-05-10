using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZPool.Services.Interface
{
    public interface IDateTimeComparer
    {
        bool CompareDateTime(DateTime compareValue, DateTime filterCriteria);
        bool CompareDate(DateTime dateTimeA, DateTime dateTimeB);
    }
}
