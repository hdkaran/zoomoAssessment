using System;

namespace Zoomo.Problem3
{
    public class FileFormatNotCorrectException: Exception
    {
        public FileFormatNotCorrectException() {  }

        public FileFormatNotCorrectException(string message)
            : base(String.Format(message))
        {
        }
    }
}