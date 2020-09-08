using System;

namespace ZooManager.Providers
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow();
    }
}
