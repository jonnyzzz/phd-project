using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
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
    private static readonly ILog LOG = LogManager.GetLogger(typeof(ActionProgressControl));
    private readonly IInvocator myInvocator;
    private readonly ProgressBarControl myControl;

    private readonly List<Thread> myWorkerThreads = new List<Thread>();

    public event EventHandler ComputationStarted;
    public event EventHandler ComputationFinished;

    private readonly AtomicInteger myPendings = new AtomicInteger(0);

    public ActionExecutorProgressControl(IInvocator invocator)
    {
      myInvocator = invocator;
      myControl = new ProgressBarControl(myInvocator);
    }

    public IActionExecution Execution { get { return this; } }

    public Control Control { get { return myControl; } }

    public void ExecuteAsync(string name, Action<IProgressInfo> action)
    {
      myControl.CreateControl();

      if (myPendings.Inc(1) == 1 && ComputationStarted != null)
      {
        ComputationStarted(this,EventArgs.Empty);
      } 

      var impl = new ProgressImpl {Maximum = 1, Text = name};
      
      if (!myControl.HasModel && myControl.IsHandleCreated)
        myControl.SetProgressModel(impl);

      var thread = new Thread(delegate()
                                {
                                  try
                                  {
                                    action(impl);
                                  } catch(Exception e)
                                  {
                                    LOG.Error("Action " + name + " failed. " + e.Message, e);
                                  } finally
                                  {
                                    myInvocator.InvokeOrQueue("Worker thread finished", ()=>myControl.ClearProgressIfSame(impl));
                                    myInvocator.InvokeOrQueue("Notify event", ()=>
                                                                                {
                                                                                  if (myPendings.Dec(1) == 0 && ComputationFinished != null)
                                                                                  {
                                                                                    ComputationFinished(this, EventArgs.Empty);
                                                                                  } 
                                                                                });
                                    lock (myWorkerThreads) myWorkerThreads.Add(Thread.CurrentThread);
                                  }
                                });
      thread.Name = "Action " + name;
      thread.IsBackground = false;

      lock(myWorkerThreads) myWorkerThreads.Add(thread);

      thread.Start();
    }

    public void BeforeDocumentContainerDisposed()
    {
      Thread[] x;
      lock (myWorkerThreads) x = myWorkerThreads.ToArray();

      for (bool isWorking = true; isWorking;)
      {
        isWorking = false;
        foreach (var thread in x)
        {
          if (thread.IsAlive)
          {
            isWorking = thread.Join(500);
          }
        }
      }
    }
  }
}