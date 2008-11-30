using System;

namespace DSIS.UI.Application
{
  internal class RepeatingAction : QueuedActionBase
  {
    private DateTime myDue;
    private readonly TimeSpan mySpan;

    public RepeatingAction(string name, Action action, Action<string, Action> executor, Action<IQueuedAction> removeMe, TimeSpan span) : base(name, action, executor, removeMe)
    {
      myDue = DateTime.MinValue;
      mySpan = span;
    }

    protected override void OnActionFinished()
    {
      if (IsDisposed)
        RemoveFromQueue();
      myDue = DateTime.Now + mySpan;
    }

    public override bool Execute()
    {
      if (IsDisposed)
        return true;

      if (DateTime.Now > myDue)
      {
        myDue = DateTime.MaxValue;
        DoExecute();
      }

      return false;
    }
  }
}