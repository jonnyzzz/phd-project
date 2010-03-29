using System;

namespace DSIS.GnuplotDrawer
{
  public class GnuplotDrawException : Exception
  {
    public GnuplotDrawException(string message) : base(message)
    {
    }

    public GnuplotDrawException(string message, Exception innerException) : base(message, innerException)
    {
    }
  }
}