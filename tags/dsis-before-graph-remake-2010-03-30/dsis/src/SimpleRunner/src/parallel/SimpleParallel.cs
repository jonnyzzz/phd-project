using System;
using System.Collections.Generic;
using System.Threading;
using DSIS.Utils;

namespace DSIS.SimpleRunner.parallel
{
  public class SimpleParallel
  {
    private readonly object LOCK = new object();
    private readonly object DO_PARALLEL_LOCK = new object();
    private readonly int myProcessors;
    private readonly List<WaitHandle> myWorking = new List<WaitHandle>();

    public SimpleParallel()
    {
      myProcessors = Environment.ProcessorCount;
      Console.Out.WriteLine("-->>>Processors count: {0}", myProcessors);      
    }

    public void WaitForEnd()
    {
      while(true)
      {
        WaitHandle[] handles;
        lock(LOCK)
        {
          handles = myWorking.ToArray();
        }
        if (handles.Length == 0)
          return;

        WaitHandle.WaitAny(handles);
      }
    }

    public void DoParallel(VoidDelegate action)
    {
      lock (DO_PARALLEL_LOCK)
      {       
        WaitHandle[] array;
        lock (LOCK)
        {
          array = myWorking.ToArray();
        }
        if (array.Length >= myProcessors)
        {
          WaitHandle.WaitAny(array);
        }


        var evt = new ManualResetEvent(false);
        lock (LOCK)
        {
          myWorking.Add(evt);
        }
        ThreadPool.QueueUserWorkItem(delegate
                                       {
                                         Console.Out.WriteLine("-->>>Started thread action");
                                         try
                                         {
                                           action();
                                         }
                                         finally
                                         {
                                           lock (LOCK)
                                           {
                                             evt.Set();
                                             myWorking.Remove(evt);
                                           }
                                         }
                                         Console.Out.WriteLine("-->>>Finished thread action");
                                       });
      }
    }
  }
}