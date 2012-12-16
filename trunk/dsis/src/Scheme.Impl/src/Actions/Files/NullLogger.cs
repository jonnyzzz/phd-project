using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class NullLogger : Logger, ILogger
  {
    public override void Write(string text)
    {
    }

    public override void Write(string fmt, params object[] data)
    {
    }

    void ILogger.Write(string text)
    {
    }

    void ILogger.Write(string text, params object[] pps)
    {
    }
  }
}