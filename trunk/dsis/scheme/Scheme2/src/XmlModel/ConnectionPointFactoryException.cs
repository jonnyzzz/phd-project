using System;

namespace DSIS.Scheme2.XmlModel
{
  public class ConnectionPointFactoryException : Exception
  {
    public ConnectionPointFactoryException(string message) : base(message)
    {
    }

    public ConnectionPointFactoryException(string message, Exception innerException) : base(message, innerException)
    {
    }
  }
}