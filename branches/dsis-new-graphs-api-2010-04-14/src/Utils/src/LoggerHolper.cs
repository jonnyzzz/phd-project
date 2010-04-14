using System;
using log4net;

namespace DSIS.Utils
{
  public static class LoggerHolper
  {
    public static void Catch(this ILog log, string title, Action action)
    {
      try
      {
        action();
      } catch(Exception e)
      {
        log.ErrorFormat("Failed. {0}. {1}", title, e.Message, e);
      }
    }
  }
}