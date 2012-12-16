using System;
using System.Threading;
using DSIS.Utils;
using log4net;

namespace DSIS.SimpleRunner.Computation
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
      using (var mem = new MemoryMonitorThread(myMemoryLimit))
      {
        using (var timeout = new TimeoutThread(myTimeout))
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
                                        try
                                        {
                                          if (!SkipError && Error != null)
                                          {
                                            Error(e);
                                          }
                                        } catch (Exception ee)
                                        {
                                          LOG.Error(ee);
                                        }
                                      }
                                    });
          thread.Name = "Guarded " + name;
          thread.IsBackground = false;

          timeout.Timeout += () =>
                               {
                                 LOG.Error("Timeout " + myTimeout + " for action " + name);
                                 SkipError = true;
                                 thread.Interrupt();
                                 thread.Abort();
                               };
          mem.MemoryLimit += () =>
                               {
                                 LOG.Error("Memory limit" + myMemoryLimit + " for action " + name);

                                 SkipError = true;
                                 while(thread.IsAlive)
                                 {
                                   thread.Interrupt();
                                   thread.Abort();
                                 }
                               };
          thread.Start(); 
          
          mem.Run();
          timeout.Run();

          thread.Join();
        }
      }
    }
  }
}