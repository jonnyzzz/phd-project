using System;
using System.Threading;

namespace DSIS.Utils
{
  public class MemoryMonitorThread : IDisposable
  {
    private readonly long myLimit;
    private Thread myThread;

    public event VoidDelegate MemoryLimit;

    public MemoryMonitorThread(long limit)
    {
      myLimit = limit;
    }

    public void Run()
    {
      myThread = new Thread(delegate()
                              {
                                try
                                {
                                  while (true)
                                  {
                                    Thread.Sleep(500);
                                    if (GC.GetTotalMemory(false) > myLimit)
                                    {
                                      MemoryLimit();
                                      return;
                                    }
                                  }
                                }
                                catch
                                {
                                  ;//NOP
                                }
                              });
      myThread.Name = "Memory Detecter";
      myThread.IsBackground = true;
      myThread.Start();
    }

    public void Dispose()
    {
      if (myThread != null && myThread.IsAlive)
      {
        myThread.Interrupt();
        myThread.Abort();
        myThread.Join();
      }
    }
  }
}