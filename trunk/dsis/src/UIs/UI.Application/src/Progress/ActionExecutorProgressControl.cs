using System;
using System.Windows.Forms;
using DSIS.Core.Util;
using DSIS.UI.UI;
using DSIS.Utils;
using EugenePetrenko.Shared.Core.Ioc.Api;
using log4net;

namespace DSIS.UI.Application.Progress
{
  [TypeInstanciable]
  public class ActionExecutorProgressControl : IActionExecution
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (ActionProgressControl));
    private readonly IInvocator myInvocator;
    private readonly ProgressBarControl myControl;
    private readonly StackedProgressBarControlModel myModel;

    private readonly IExecutorService myExecutor;

    public event EventHandler<EventArgs> ComputationStarted;
    public event EventHandler<EventArgs> ComputationFinished;

    public ActionExecutorProgressControl(IInvocator invocator, IExecutorService executor)
    {
      myExecutor = executor;
      myInvocator = invocator;
      myModel = new StackedProgressBarControlModel();
      myControl = new ProgressBarControl(myModel, myInvocator);
    }

    public Control Control
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
      myInvocator.AssertUIThread();
      
      myControl.CreateControl();

      myExecutor.Execute(name, hook =>
                                 {
                                   FireStarted(name);

                                   try
                                   {
                                     myModel.UnderProgress(name, action, () => { });
                                   } catch (Exception e)
                                   {
                                     LOG.Error("Action " + name + " failed. " + e.Message, e);
                                   }
                                   finally
                                   {
                                     FireFinished(name);
                                   }
                                 });
    }
  }
}