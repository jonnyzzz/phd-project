using System;

namespace DSIS.Scheme2.Graph
{
  public class SchemeGraphException : Exception
  {
    public SchemeGraphException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public SchemeGraphException(string message) : base(message)
    {
    }
  }
}