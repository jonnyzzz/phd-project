using System;
using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;

namespace DSIS.Scheme.Actions
{
  public class LoopAction : IAction
  {
    private readonly int myCount;
    private readonly IAction myAction;

    public LoopAction(int count, IAction action)
    {
      if (count <= 0)
        throw new ArgumentException("Count should be >= 1", "count");
      myCount = count;
      myAction = action;
    }

    public ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return myAction.Compatible(ctx);
    }

    public Context Apply(Context ctx)
    {
      for(int i = 0; i<myCount; i++)
      {
        ICollection<ContextMissmatch> check = myAction.Compatible(ctx);
        if (check.Count != 0)
        {
          throw new ContextMissmatchException(check);
        }

        Context newCtx = myAction.Apply(ctx);
        newCtx.AddAllNew(ctx);
        ctx = newCtx;
      }
      return ctx;      
    }
  }
}