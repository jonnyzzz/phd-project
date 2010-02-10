using System;

namespace DSIS.UI.Controls
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