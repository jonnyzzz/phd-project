using System;
using System.Threading;

namespace DSIS.Utils
{
  public class ReenterableSafe
  {
    private readonly object LOCK = new object();
    private int myWorking = 0;

    public bool Action(Action act)
    {
      if (Interlocked.CompareExchange(ref myWorking, 1, 0) == 0)
        return false;
      try
      {
        act();
      } finally
      {
        myWorking = 0;
      }
      return true;
    }
  }
}