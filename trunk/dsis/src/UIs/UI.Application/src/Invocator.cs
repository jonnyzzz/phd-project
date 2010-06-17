using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DSIS.UI.UI;
using DSIS.Utils;
using EugenePetrenko.Shared.Core.Ioc.Api;
using log4net;

namespace DSIS.UI.Application
{
  [ComponentImplementation]
  public class Invocator : IInvocator, IDisposable
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof(Invocator));

    private readonly Form myPumpForm;
    private readonly Timer myActionsTimer;
    private readonly List<IQueuedAction> myActions = new List<IQueuedAction>();
    private readonly ReenterableSafe myReenterableSafe = new ReenterableSafe();

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
                       StartPosition = FormStartPosition.Manual
                     };
      myPumpForm.Show();
      myPumpForm.Visible = false;
      myActionsTimer = new Timer {Enabled = false, Interval = 300};
      myActionsTimer.Tick += myActionsTimer_Tick;
      myActionsTimer.Enabled = true;
    }

    private void myActionsTimer_Tick(object sender, EventArgs e)
    {
      myReenterableSafe.Action(
        delegate
          {
            HashSet<IQueuedAction> actions;
            lock (myActions)
            {
              actions = new HashSet<IQueuedAction>(myActions);
            }

            actions.RemoveWhere(x => x.Execute());

            lock (myActions)
            {
              myActions.RemoveAll(x=>!actions.Contains(x));
            }
          });
    }

    public void InvokeOrQueue(string name, Action action)
    {
      ExecuteWithTimeout(name, TimeSpan.Zero, action);      
    }

    private void DoExecute(string name, Action action)
    {
      myPumpForm.InvokeAction(
        delegate
        {
          try
          {
            action();
          }
          catch (Exception e)
          {
            LOG.Error("Action " + name + " has failed: " + e.Message, e);
          }
        });
    }

    private void RemoveFromQueue(IQueuedAction action)
    {
      lock(myActions)
      {
        myActions.Remove(action);
      }
    }

    public IDisposable ExecuteWithTimeout(string name, TimeSpan interval, Action action)
    {
      lock (myActions)
      {
        var ac = new QueuedAction(name, action, DoExecute, RemoveFromQueue, DateTime.Now + interval);
        myActions.Add(ac);
        return ac;
      }
    }

    public IDisposable ExecuteRepeating(string name, TimeSpan interval, Action action)
    {
      lock (myActions)
      {
        var ac = new RepeatingAction(name, action, DoExecute, RemoveFromQueue, interval);
        myActions.Add(ac);
        return ac;
      }
    }

    public void AssertUIThread()
    {
      if (myPumpForm.InvokeRequired)
      {
        throw new InvalidOperationException("This method should be called from UI thread");
      }
    }

    public void Dispose()
    {
      myActionsTimer.Enabled = false;
      myActionsTimer.Dispose();
      myPumpForm.Dispose();
    }
  }
}