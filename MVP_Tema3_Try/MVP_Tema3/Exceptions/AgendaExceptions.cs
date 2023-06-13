using System;

namespace MVP_Tema3.Exceptions
{
    class AgendaException : ApplicationException
    {
        public AgendaException(string message)
            : base(message)
        {
        }
    }
}
