using System;

namespace DSIS.Scheme2.ConnectionPoints.Object
{
  public class ObjectNodeFactoryException : Exception
  {
    public ObjectNodeFactoryException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public ObjectNodeFactoryException(string message) : base(message)
    {
    }
  }
}