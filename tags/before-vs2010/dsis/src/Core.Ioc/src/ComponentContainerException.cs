using System;

namespace DSIS.Core.Ioc
{
  public class ComponentContainerException : Exception
  {
    public ComponentContainerException(string message) : base(message)
    {
    }

    public ComponentContainerException(string message, Exception innerException) : base(message, innerException)
    {
    }
  }
}