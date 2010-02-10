using System;

namespace DSIS.UI.Wizard
{
  public class WizardPackException : Exception
  {
    public WizardPackException(string message) : base(message)
    {
    }

    public WizardPackException(string message, Exception innerException) : base(message, innerException)
    {
    }
  }
}