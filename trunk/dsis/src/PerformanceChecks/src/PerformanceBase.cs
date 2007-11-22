using System;

namespace DSIS.PerformanceChecks
{
  public abstract class PerformanceBase
  {
    protected delegate void DAction();

    protected static double DoAction(DAction d)
    {
      return DoAction(d, 1);
    }

    protected static double DoAction(DAction d, int count)
    {
      DateTime start = DateTime.Now;
      for (int i = 0; i < count; i++)
      {
        d();
      }
      return (DateTime.Now - start).Milliseconds;
    }

    protected static double DoAction(string caption, DAction d)
    {
      return DoAction(caption, d, 1);
    }

    protected static double DoAction(string caption, DAction d, int count)
    {
      double dt = DoAction(d, count);
      Console.Out.WriteLine("{0} time was {1}ms", caption, dt);
      return dt;
    }    
  }
}