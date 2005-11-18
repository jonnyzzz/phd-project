using System;

namespace EugenePetrenko.Gui2.Kernell2.Serialization
{
    /// <summary>
    /// Summary description for SerializationException.
    /// </summary>
    public class SerializationException : Exception
    {
        public SerializationException(string message) : base(message)
        {
        }

        public SerializationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}