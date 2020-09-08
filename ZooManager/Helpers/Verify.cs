using System;

namespace ZooManager.Helpers
{
    public static class Verify
    {
        public static TItemType NotNull<TItemType>(TItemType item, string name) where TItemType: class
        {
            if (item == null)
            {
                throw new ArgumentNullException($"{name} is null");
            }
            return item;
        }
        public static string NotNullOrEmpty(string item, string name)
        {
            NotNull(item, name);

            if (item==string.Empty)
            {
                throw new ArgumentNullException($"{name} is empty");
            }
            return item;
        }
 
        public static int GreaterThan(int testValue, int minValue, string name)
        {
            if (testValue <= minValue)
            {
                throw new ArgumentException($"{name} should be > {minValue} but is {testValue}");
            }
            return testValue;
        }

        public static int GreaterThanOrEqualTo(int testValue, int minValue, string name)
        {
            if (testValue < minValue)
            {
                throw new ArgumentException($"{name} should be >= {minValue} but is {testValue}");
            }
            return testValue;
        }
    }
}
