using System;

namespace ToolsManagement.Exceptions
{
    public class WrongValueException : Exception
    {
        public WrongValueException(string message) : base(message)
        {

        }
    }
}
