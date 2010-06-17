using System;
using System.Threading;
using log4net;

namespace DSIS.Utils
{
  public class OneTreadExecutor : IExecutorService, IDisposable
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (OneTreadExecutor));

    private readonly SimpleConcurentQueue<ActionHolder> myQueue = new SimpleConcurentQueue<ActionHolder>();
    private readonly Thread myWorkerThread;
    private readonly AutoResetEvent myEvent = new AutoResetEvent(false);
    private ActionHolder myCurrentAction;

    public OneTreadExecutor()
    {
      myWorkerThread = new Thread(ThreadAction) {Name = "Worker thread", IsBackground = true};
      myWorkerThread.Start();
    }

    private void ThreadAction()
    {
      try
      {
        while (true)
        {
          myEvent.WaitOne();

          for (var a = myQueue.DequeueOrDefault(); a != null; a = myQueue.DequeueOrDefault())
          {
            myCurrentAction = a;
            try
            {
              a.ExecuteAction();
            } catch
            {
              ;// NOP to keep pump running
            }
            finally
            {
              myCurrentAction = null;
            }
          }
        }
      }
      catch (ThreadInterruptedException)
      {
        //
      }
      catch (ThreadAbortException)
      {
        //
      }
      catch (Exception e)
      {
        LOG.Error(e);
      }
    }

    public IExecutingAction Execute(string name, Action<IExecutingAction> action)
    {
      var elem = new ActionHolder(name, action);
      myQueue.Enqueue(elem);
      myEvent.Set();
      return elem;
    }

    public int Pending
    {
      get { return myQueue.Count; }
    }

    public void TerminateAll()
    {
      Dispose();
    }

    public void Dispose()
    {
      myQueue.ForEach(x => x.Cancel());
      myQueue.Clear();
      var z = myCurrentAction;
      if (z != null)
        z.Cancel();

      myWorkerThread.Interrupt();
      while (!myWorkerThread.Join(TimeSpan.FromSeconds(.1)))
      {
        myWorkerThread.Abort();
        Thread.Sleep(500);
      }
    }

    private class ActionHolder : IExecutingAction
    {
      private readonly string myName;
      private readonly Action<IExecutingAction> myAction;
      private volatile bool myIsCanceled;

      public ActionHolder(string name, Action<IExecutingAction> action)
      {
        myName = name;
        myAction = action;
      }

      public void Cancel()
      {
        myIsCanceled = true;
      }

      public void ExecuteAction()
      {
        if (myIsCanceled) return;
        try
        {
          myAction(this);
        }
        catch (ProcessInterruptedException e)
        {
          LOG.Info("Action " + myName + " was interrupted. ", e);
        }
        catch (Exception e)
        {
          LOG.Warn("Failed to execute action " + myName, e);
        }
      }
    }
  }
}