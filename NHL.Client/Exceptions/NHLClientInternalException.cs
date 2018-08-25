using System;

namespace NHL.Client.Exceptions
{
    public class NHLClientInternalException : Exception
    {
        internal NHLClientInternalException(string message)
            :base(message)
        {

        }
    }
}
