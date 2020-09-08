using System;

namespace ZooManager.Exceptions
{
    public class ComplianceException : ApplicationException
    {
        public ComplianceException(string message): base(message)
        {
        }
        public ComplianceException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
