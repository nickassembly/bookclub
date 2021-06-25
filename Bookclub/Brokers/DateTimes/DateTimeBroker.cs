using Bookclub.Core.Interfaces;
using System;

namespace Bookclub.Brokers.DateTimes
{
    public class DateTimeBroker : IDateTimeBroker
    {
        // TODO: remove datetime broker and logging broker
        public DateTimeOffset GetCurrentDateTime() =>
            DateTimeOffset.UtcNow;
    }
}
