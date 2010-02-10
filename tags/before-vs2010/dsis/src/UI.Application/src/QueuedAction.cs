using System;

namespace DSIS.UI.Application
{
  internal class QueuedAction : QueuedActionBase
  {
    private readonly DateTime myDue;

    public QueuedAction(string name, Action action, Action<string, Action> executor, Action<IQueuedAction> removeMe, DateTime due) : base(name, action, executor, removeMe)
    {
      myDue = due;
    }

    protected override void OnActionFinished()
    {
      RemoveFromQueue();
    }

    public override bool Execute()
    {
      if (DateTime.Now > myDue)
      {
        DoExecute();
        return true;
      }
      return false;
    }
  }
}