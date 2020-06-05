using System;

namespace PracticeWebApi.CommonClasses.Exceptions
{
    public class DuplicateResourceException : Exception
    {
        public DuplicateResourceException(string message, Exception innerException = null)
            : base(message, innerException) { }
    }
}
