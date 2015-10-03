using System;
using log4net;

namespace DSIS.UI.Application
{
  internal abstract class QueuedActionBase : IDisposable, IQueuedAction
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (QueuedActionBase));
    private readonly string myName;
    private readonly Action myAction;
    private readonly Action<string, Action> myExecutor;
    private readonly Action<IQueuedAction> myRemoveMe;
    private bool myIsDisposed;
    private bool myIsRemoved;

    public QueuedActionBase(string name, Action action, Action<string, Action> executor, Action<IQueuedAction> removeMe)
    {
      myName = name;
      myAction = action;
      myExecutor = executor;
      myRemoveMe = removeMe;
    }

    protected void DoExecute()
    {
      myExecutor(myName, () =>
                           {
                             try
                             {
                               if (!myIsDisposed)
                                 myAction();
                             }
                             catch (Exception e)
                             {
                               LOG.Error(string.Format("Failed to execute action '{0}'. {1}", myName, e.Message), e);
                             }
                             finally
                             {
                               OnActionFinished();
                             }
                           });
    }

    public void Dispose()
    {
      myIsDisposed = true;
    }

    protected abstract void OnActionFinished();

    protected void RemoveFromQueue()
    {
      if (!myIsRemoved)
      {
        myIsRemoved = true;
        myRemoveMe(this);
      }
    }

    protected bool IsDisposed
    {
      get { return myIsDisposed; }
    }

    public abstract bool Execute();
  }
}