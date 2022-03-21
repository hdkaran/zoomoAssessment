using System;

namespace Zoomo.Problem2
{
    [Serializable]
    public class InvalidTriangleException : Exception
    {
        public InvalidTriangleException() {  }

        public InvalidTriangleException(string message)
            : base(String.Format(message))
        {
        }
    }
}