using System;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Performance
{
  public class PerformanceSlot
  {
    private readonly object LOCK = new object();
    private TimeSpan myTime;

    public void AddTimeSlot(TimeSpan span)
    {
      lock(LOCK)
      {
        myTime += span;
      }
    }

    public static PerformanceSlot Get(string key, Context ctx)
    {
      if (ctx.ContainsKey(Key(key)))
      {
        return ctx.Get(Key(key));
      }
      else
      {
        var ms = new PerformanceSlot();
        ctx.Set(Key(key), ms);
        return ms;
      }
    }

    public TimeSpan Time
    {
      get { return myTime; }
    }

    private static Key<PerformanceSlot> Key(string key)
    {
      return new Key<PerformanceSlot>(key);
    }
  }
}