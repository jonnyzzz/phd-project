using System;
using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using JetBrains.dotTrace.Api;

namespace DSIS.Scheme.Impl.Actions.Performance
{
  public abstract class RecordTimeActionBase : IAction
  {
    private readonly IAction myAction;

    protected RecordTimeActionBase(IAction action)
    {
      myAction = action;
    }

    public Context Apply(Context ctx)
    {
      DateTime start = DateTime.Now;

      CPUProfiler.Start();
      var res = myAction.Apply(ctx);
      CPUProfiler.Stop();

      
      var span = DateTime.Now - start;

      ActionFinished(ctx, res, span);
      return res;
    }

    protected abstract void ActionFinished(Context ctx, Context output, TimeSpan span);

    public IAction Clone()
    {
      return CloneInternal(myAction.Clone());
    }

    protected abstract IAction CloneInternal(IAction action);

    public ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return myAction.Compatible(ctx);
    }
    
  }
}