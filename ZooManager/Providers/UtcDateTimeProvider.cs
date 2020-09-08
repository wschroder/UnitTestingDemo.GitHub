using System;

namespace ZooManager.Providers
{
    public class UtcDateTimeProvider : IDateTimeProvider
    {
        private static readonly IDateTimeProvider _instance = new UtcDateTimeProvider();

        public static IDateTimeProvider Instance => _instance;

        public DateTime UtcNow()
        {
            return DateTime.UtcNow;
        }
    }
}
