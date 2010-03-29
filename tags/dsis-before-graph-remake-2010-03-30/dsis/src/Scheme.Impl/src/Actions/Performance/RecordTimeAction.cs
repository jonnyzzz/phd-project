using System;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Performance
{
  public class RecordTimeAction : RecordTimeActionBase
  {
    private readonly string myKey;

    public RecordTimeAction(IAction action, string key) : base(action)
    {
      myKey = key;
      Key = new Key<TimeSpan>(GetType().FullName + ":" + myKey);
    }

    public Key<TimeSpan> Key { get; private set;}

    protected override void ActionFinished(Context ctx, Context output, TimeSpan span)
    {
      Key.Set(output, span);
    }

    protected override IAction CloneInternal(IAction action)
    {
      return new RecordTimeAction(action, myKey);
    }
  }
}