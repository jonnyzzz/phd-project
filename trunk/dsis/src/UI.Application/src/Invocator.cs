using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DSIS.Core.Ioc;
using DSIS.UI.UI;
using DSIS.Utils;

namespace DSIS.UI.Application
{
  [ComponentImplementation]
  public class Invocator : IInvocator
  {
    private readonly Form myPumpForm;
    private readonly Timer myActionsTimer;
    private readonly List<MyQueuedAction> myActions = new List<MyQueuedAction>();

    public Invocator()
    {
      myPumpForm = new Form
                     {
                       Width = 1,
                       Height = 1,
                       Top = 10000,
                       Left = 10000,
                       Visible = false,
                       Text = "DSIS Invocator Form",
                       ShowInTaskbar = false,
                       StartPosition = FormStartPosition.Manual};
      myPumpForm.Show();
      myPumpForm.Visible = false;
      myActionsTimer = new Timer {Enabled = false, Interval = 100};
      myActionsTimer.Tick += myActionsTimer_Tick;
    }

    private void myActionsTimer_Tick(object sender, EventArgs e)
    {
      myActionsTimer.Enabled = false;

      HashSet<MyQueuedAction> actions;
      lock (myActions)
      {
        actions = new HashSet<MyQueuedAction>(myActions);
      }

      var now = DateTime.Now;
      actions.RemoveWhere(x => !x.Execute(now, InvokeOrQueue));

      lock(myActions)
      {
        myActions.RemoveAll(actions.Contains);
        myActionsTimer.Enabled = myActions.Count > 0;
      }
    }

    public void InvokeOrQueue(string name, Action action)
    {
      myPumpForm.InvokeAction(action);
    }

    public IDisposable ExecuteWithTimeout(string name, TimeSpan interval, Action action)
    {
      lock (myActions)
      {
        var ac= new MyQueuedAction(DateTime.Now + interval, name, action);
        myActions.Add(ac);
        myActionsTimer.Enabled = true;
        return ac;
      }
    }

    private class MyQueuedAction : IDisposable
    {
      private bool myIsDisposed;
      private readonly DateTime myDue;
      private readonly string myName;
      private readonly Action myAction;

      public MyQueuedAction(DateTime due, string name, Action action)
      {
        myDue = due;
        myName = name;
        myAction = action;
      }

      public bool Execute(DateTime time, Action<string,Action> execute)
      {
        if (myIsDisposed)
          return true;

        if (myDue < time)
        {
          execute(myName, myAction);
          return true;
        }

        return false;
      }

      public void Dispose()
      {
        myIsDisposed = true;
      }
    }
     
  }
}