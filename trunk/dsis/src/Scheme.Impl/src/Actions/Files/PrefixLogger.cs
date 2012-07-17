namespace DSIS.Scheme.Impl.Actions.Files
{
  public class PrefixLogger : Logger
  {
    private readonly Logger myLogger;
    private readonly string myPrefix;

    public PrefixLogger(Logger logger, string prefix)
    {
      myLogger = logger;
      myPrefix = prefix;
    }

    public override void Write(string text)
    {
      myLogger.Write(myPrefix + text);
    }
  }
}