using System.Collections.Generic;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class AndLogger : Logger
  {
    private readonly List<Logger> myChain = new List<Logger>();

    public AndLogger()
    {
    }

    public AndLogger(params Logger[] loggers)
    {
      myChain.AddRange(loggers);
    }

    public void AddLogger(Logger logger)
    {
      myChain.Add(logger);
    }


    public override void Write(string text)
    {
      foreach (var logger in myChain)
      {
        logger.Write(text);
      }
    }
  }
}