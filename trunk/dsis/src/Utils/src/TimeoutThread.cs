using System;
using System.Threading;

namespace DSIS.Utils
{
  public class TimeoutThread : IDisposable
  {
    private readonly TimeSpan mySpan;
    private Thread myThread;

    public event VoidDelegate Timeout;

    public TimeoutThread(TimeSpan span)
    {
      mySpan = span;
    }

    public void Run()
    {
      myThread = new Thread(()=>
                              {
                                Thread.Sleep(mySpan);
                                if (Timeout != null)
                                  Timeout();
                              });
      myThread.IsBackground = false;
      myThread.Name = "Timeout " + mySpan;
      myThread.Start();
    }

    public void Dispose()
    {
      if (myThread != null && myThread.IsAlive)
      {
        myThread.Interrupt();
        myThread = null;
      }
    }
  }
}