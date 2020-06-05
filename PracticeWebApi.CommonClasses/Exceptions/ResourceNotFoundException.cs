using System;

namespace PracticeWebApi.CommonClasses.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string message, Exception innerException = null) 
            : base(message, innerException) { }
    }
}
