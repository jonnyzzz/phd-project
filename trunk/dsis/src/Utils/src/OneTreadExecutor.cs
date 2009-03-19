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
    private ActionHolder myCurrentAction = null;


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
            a.ExecuteAction();
            myCurrentAction = null;
          }
        }
      } catch(ThreadInterruptedException)
      {
        //
      } catch(ThreadAbortException)
      {
        //
      } catch(Exception e)
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
      myQueue.Clear();

      for(var action = myCurrentAction; action != null; action = myCurrentAction)
      {
        action = myCurrentAction;
        if (action != null)
        {
          action.Interrupt();
          Thread.Sleep(100);
        }
      }

      myWorkerThread.Interrupt();
      if (!myWorkerThread.Join(TimeSpan.FromSeconds(.1)))
      {
        myWorkerThread.Abort();
      }
    }

    private class ActionHolder : IExecutingAction
    {
      private static readonly ILog LOG = LogManager.GetLogger(typeof (ActionHolder));

      private readonly string myName;
      private readonly Action<IExecutingAction> myAction;
      private volatile bool myIsCanceled;
      private readonly Thread myWorker;

      private readonly ManualResetEvent myWaitFinishEvent = new ManualResetEvent(false);
      private readonly ManualResetEvent myActionFinishEvent = new ManualResetEvent(false);
      private readonly ManualResetEvent myExecutionWait = new ManualResetEvent(false);

      public ActionHolder(string name, Action<IExecutingAction> action)
      {
        myName = name;
        myAction = action;
        myWorker = new Thread(ThreadExecute) {Name = ("Worker for action " + myName), IsBackground = true};
        myWaitFinishEvent.Set();
      }

      private void ThreadExecute()
      {
        try
        {
          if (!myIsCanceled)
          {
            try
            {
              myAction(this);
            }
            catch (Exception e)
            {
              LOG.Error(e.Message, e);
            }
          }
          myActionFinishEvent.Set();
          myWaitFinishEvent.WaitOne();
        } finally
        {
          myExecutionWait.Set();
        }
      }

      public void Interrupt()
      {
        var th = new Thread(InterruptInternal)
                   {
                     Name = ("Interrup for " + myName),
                     Priority = ThreadPriority.AboveNormal,
                     IsBackground = false
                   };
        th.Start();
      }

      private void InterruptInternal()
      {
        //Stop waiting for thread to finish
        myExecutionWait.Set();
        
        myWaitFinishEvent.Reset();
        Cancel();

        //If thread is finished
        if (myActionFinishEvent.WaitOne(10, true))
        {
          myWaitFinishEvent.Set();
          return;
        }

        //Thread is finished
        if (myWorker.Join(10))
        {
          myWaitFinishEvent.Set();
          return;
        }

        Func<bool> alive = () => !myWorker.Join(100) && !myActionFinishEvent.WaitOne(100, true);

        myWorker.Interrupt();
        if (!alive())
        {
          myWaitFinishEvent.Set();
          return;
        }

        while (alive())
        {
          myWorker.Abort();
        }
      }

      public void Cancel()
      {
        myIsCanceled = true;
      }

      public void ExecuteAction()
      {
        if (!myIsCanceled)
        {
          myWorker.Start();
          myExecutionWait.WaitOne();
        }
      }
    }
  }
}