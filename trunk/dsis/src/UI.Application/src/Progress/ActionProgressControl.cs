using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using DSIS.Core.Util;
using DSIS.UI.Application.Doc;
using DSIS.UI.Controls;
using DSIS.UI.UI;
using log4net;

namespace DSIS.UI.Application.Progress
{
  [DocumentComponent]
  public class FakeControl : IDocumentControl
  {
    private readonly Control myControl;

    public FakeControl()
    {
      myControl = new Button() {Text = "Fake control", BackColor = Color.Azure};
    }

    public string Ancor
    {
      get { return "aAAA"; }
    }

    public Layout[] Float
    {
      get { return new[] {Layout.LEFT, Layout.BOTTON,}; }
    }

    public Control Control
    {
      get { return myControl; }
    }
  }

  [DocumentComponent]
  public class ActionProgressControl : IDocumentControl, IActionExecution, IDocumentComponent
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof(ActionProgressControl));

    private readonly IInvocator myInvocator;
    private readonly ProgressBarControl myControl;
    private readonly List<Thread> myWorkerThreads = new List<Thread>();
    
    public ActionProgressControl(IInvocator invocator)
    {
      myInvocator = invocator;
      myControl = new ProgressBarControl(myInvocator);
    }

    public string Ancor
    {
      get { return "ZZZZ"; }
    }

    public Layout[] Float
    {
      get { return new[] {Layout.LEFT, Layout.BOTTON,}; }
    }

    public Control Control
    {
      get { return myControl; }
    }

    public void ExecuteAsync(string name, Action<IProgressInfo> action)
    {
      myControl.CreateControl();

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