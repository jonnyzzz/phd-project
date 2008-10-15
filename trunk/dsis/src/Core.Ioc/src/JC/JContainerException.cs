using System;

namespace DSIS.Core.Ioc.JC
{
  public class JContainerException : Exception
  {
    public JContainerException(string message) : base(message)
    {
    }

    public JContainerException(string message, Exception innerException) : base(message, innerException)
    {
    }
  }
}