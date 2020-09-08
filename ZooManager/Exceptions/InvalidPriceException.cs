using System;
using ZooManager.Entities;

namespace ZooManager.Exceptions
{
    public class InvalidPriceException : Exception
    {
        public InvalidPriceException(RetailItem item) : this($"{item.Id} | {item.Name}")
        {
        }
        public InvalidPriceException(string message) : base(message)
        {
        }
    }
}
