using System;

namespace DSIS.Function.UserDefined
{
  public class UserDefinedFactoryException : Exception
  {
    public UserDefinedFactoryException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public UserDefinedFactoryException(string message) : base(message)
    {
    }
  }
}