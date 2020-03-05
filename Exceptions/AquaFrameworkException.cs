using System;

namespace AquaFramework.Exceptions
{
    class AquaFrameworkException : Exception
    {
        public AquaFrameworkException(string message) : base(message) { }
    }
}

