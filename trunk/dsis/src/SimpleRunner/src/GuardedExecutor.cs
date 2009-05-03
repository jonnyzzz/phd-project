using System;
using System.Threading;
using DSIS.Utils;
using log4net;

namespace DSIS.SimpleRunner
{
  public class GuardedExecutor
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (GuardedExecutor));

    private readonly long myMemoryLimit;
    private readonly TimeSpan myTimeout;

    public GuardedExecutor(long memoryLimit, TimeSpan timeout)
    {
      myMemoryLimit = memoryLimit;
      myTimeout = timeout;
    }

    public event Action<Exception> Error;

    public event Action TimeOut;

    public event Action OutOfMemory;    

    public void Execute(string name, Action a)
    {
      using(var mem = new MemoryMonitorThread(myMemoryLimit))
      {
        using(var timeout = new TimeoutThread(myTimeout))
        {
          bool SkipError = false;
          var thread = new Thread(() =>
                                    {
                                      try
                                      {
                                        a();
                                      }
                                      catch (Exception e)
                                      {
                                        LOG.Error(e);
                                        if (!SkipError && Error != null)
                                        {
                                          Error(e);
                                        }
                                      }
                                    });
          thread.Name = "Guarded " + name;
          thread.IsBackground = false;

          timeout.Timeout += () =>
                               {
                                 SkipError = true;
                                 thread.Interrupt();
                                 thread.Abort();
                                 LOG.Error("Timeout " + myTimeout + " for action " + name);
                               };
          mem.MemoryLimit += () => {
                                     SkipError = true;
                                     thread.Interrupt();
                                     thread.Abort();
                                     LOG.Error("Memory limit" + myTimeout + " for action " + name);
          };
          mem.Run();
          timeout.Run();

          thread.Start();

          thread.Join();
        }
      }
    }
  }
}