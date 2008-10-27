using System;
using System.Threading;
using System.Windows.Forms;
using DSIS.Core.Util;
using DSIS.UI.Application.Doc;
using DSIS.UI.Controls;
using log4net;
using DSIS.Utils;

namespace DSIS.UI.Application.Progress
{
  [DocumentComponent]
  public class ActionProgressControl : IDocumentControl, IActionExecution
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (ActionProgressControl));
    private readonly ProgressBarControl myControl;

    public ActionProgressControl()
    {
      myControl = new ProgressBarControl();
    }

    public string Ancor
    {
      get { return "ZZZZ"; }
    }

    public Layout[] Float
    {
      get { return new[] {Layout.LEFT, Layout.TOP,}; }
    }

    public Control Control
    {
      get { return myControl; }
    }

    public void ExecuteAsync(string name, Action<IProgressInfo> action)
    {
      var impl = new ProgressImpl {Maximum = 1, Text = name};
      if (myControl.IsHandleCreated)
        myControl.ProgressModel = impl;

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
                                    myControl.InvokeAction(()=>myControl.ProgressModel = null);
                                  }
                                });
      thread.Name = "Action " + name;
      thread.IsBackground = false;

      thread.Start();
    }
  }
}