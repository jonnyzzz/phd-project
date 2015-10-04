using System;

namespace EugenePetrenko.Core.FormGenerator.Layout
{
  public class LayoutException : Exception
  {
    public LayoutException(string message) : base(message)
    {
    }

    public LayoutException(string message, Exception innerException) : base(message, innerException)
    {
    }
  }
}