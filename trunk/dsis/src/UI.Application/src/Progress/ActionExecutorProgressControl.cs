using System;
using System.Threading;
using DSIS.Core.Ioc;
using DSIS.Core.Util;
using DSIS.UI.UI;
using DSIS.Utils;
using log4net;

namespace DSIS.UI.Application.Progress
{
  [TypeInstanciable]
  public class ActionExecutorProgressControl : IActionExecution
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (ActionProgressControl));
    private readonly IInvocator myInvocator;
    private readonly ProgressBarControl myControl;

    private readonly IExecutorService myExecutor;

    public event EventHandler<EventArgs> ComputationStarted;
    public event EventHandler<EventArgs> ComputationFinished;

    public ActionExecutorProgressControl(IInvocator invocator, IExecutorService executor)
    {
      myExecutor = executor;
      myInvocator = invocator;
      myControl = new ProgressBarControl(myInvocator) {IsInterruptable = true};
    }

    public ProgressBarControl Control
    {
      get { return myControl; }
    }

    private void FireStarted(string name)
    {
      myInvocator.InvokeOrQueue("Action started event " + name, () => ComputationStarted.Fire(this, EventArgs.Empty));
    }

    private void FireFinished(string name)
    {
      myInvocator.InvokeOrQueue("Action started event " + name, () => ComputationFinished.Fire(this, EventArgs.Empty));
    }

    public void ExecuteAsync(string name, Action<IProgressInfo> action)
    {
      myControl.CreateControl();

      myExecutor.Execute(name, hook =>
                                 {
                                   var impl = CreateProgressImpl(name, hook);
                                   FireStarted(name);

                                   try
                                   {
                                     action(impl);
                                   }
                                   catch (Exception e)
                                   {
                                     LOG.Error("Action " + name + " failed. " + e.Message, e);
                                   }
                                   finally
                                   {
                                     myInvocator.InvokeOrQueue("Worker thread finished",
                                                               () =>
                                                               myControl.ClearProgressIfSame(impl));
                                     FireFinished(name);
                                   }
                                 });
    }

    private ProgressImpl CreateProgressImpl(string name, IExecutingAction hook)
    {
      var impl = new ProgressImpl {Maximum = 1, Text = name};
      impl.Interrupted += delegate { hook.Interrupt(); };

      var lck = new AutoResetEvent(false);
      myInvocator.InvokeOrQueue(
        "Set progress for action " + name,
        () =>
          {
            try
            {
              if (!myControl.HasModel && myControl.IsHandleCreated)
                myControl.SetProgressModel(impl);
            }
            finally
            {
              lck.Set();
            }
          });
      lck.WaitOne();
      return impl;
    }

    public void BeforeDocumentContainerDisposed()
    {
      myExecutor.TerminateAll();
    }
  }
}