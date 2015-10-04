using System;

namespace EugenePetrenko.Shared.Core.Ioc.JC
{
  public class JContainerException : ComponentContainerException
  {
    public JContainerException(string message) : base(message)
    {
    }

    public JContainerException(string message, Exception innerException) : base(message, innerException)
    {
    }
  }
}