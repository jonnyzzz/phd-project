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

    protected static void Collect()
    {
      GC.Collect(GC.MaxGeneration);
      GC.WaitForPendingFinalizers();
      GC.Collect(GC.MaxGeneration);
      GC.WaitForPendingFinalizers();
    }

    protected static long Memory
    {
      get { 
        Collect();
        return GC.GetTotalMemory(true); 
      }
    }

    protected static void Usage(long begin)
    {
      double usage = Memory - begin;
      Console.Out.WriteLine("Memory Usage: {0} mb", usage / 1024 /1024);
    }

    protected static double DoAction(DAction d, int count)
    {
      DateTime start = DateTime.Now;
      for (int i = 0; i < count; i++)
      {
        d();
      }
      return (DateTime.Now - start).TotalMilliseconds;
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