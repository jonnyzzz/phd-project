using System.Diagnostics;

namespace DSIS.Scheme.Actions
{
  public abstract class DebugableAction : IActionDebug
  {
    private readonly StackTrace myStacktrace;

    public DebugableAction()
    {
      myStacktrace = new StackTrace(true);
    }

    public StackTrace Creation
    {
      get { return myStacktrace; }
    }
  }
}