using System;

namespace DSIS.Scheme.Exec
{
  public class ActionGraphException : Exception
  {
    public ActionGraphException(string message) : base(message)
    {
    }

    public ActionGraphException(string message, Exception innerException) : base(message, innerException)
    {
    }
  }
}