using System;
using System.Threading;
using log4net;

namespace DSIS.Utils
{
  public class MemoryMonitorThread : IDisposable
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (MemoryMonitorThread));
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
                                  while (myThread != null)
                                  {
                                    Thread.Sleep(1500);
                                    if (MemoryLimit != null && GC.GetTotalMemory(false) > myLimit && GC.GetTotalMemory(true) > myLimit)
                                    {
                                      LOG.Info("Memory usage limit acheived.");
                                      MemoryLimit();
                                      return;
                                    }
                                  }
                                }
                                catch(ThreadInterruptedException) {}
                                catch(ThreadAbortException) {}
                                catch(Exception e)
                                {
                                  LOG.Error(e);
                                }
                              });
      myThread.Name = "Memory Detecter";
      myThread.IsBackground = true;
      myThread.Start();
    }

    public void Dispose()
    {
      var thread = myThread;
      myThread = null;
      if (thread != null && thread.IsAlive)
      {
        thread.Interrupt();
        thread.Join();
      }
    }
  }
}