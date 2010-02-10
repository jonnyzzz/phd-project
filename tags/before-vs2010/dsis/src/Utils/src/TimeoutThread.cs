using System;
using System.Threading;
using log4net;

namespace DSIS.Utils
{
  public class TimeoutThread : IDisposable
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (TimeoutThread));

    private readonly TimeSpan mySpan;
    private Thread myThread;

    public event VoidDelegate Timeout;

    public TimeoutThread(TimeSpan span)
    {
      mySpan = span;
    }

    public void Run()
    {
      if (mySpan == TimeSpan.MaxValue)
        return;

      myThread = new Thread(()=>
                              {
                                try
                                {
                                  Thread.Sleep(mySpan);
                                } catch
                                {
                                  //NOP
                                }
                                try
                                {
                                  if (Timeout != null && myThread != null)
                                    Timeout();
                                } catch (Exception e)
                                {
                                  LOG.Error(e);
                                }
                              });
      myThread.IsBackground = false;
      myThread.Name = "Timeout " + mySpan;
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