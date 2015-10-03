using System;
using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;

namespace DSIS.Scheme.Actions
{
  public class LoopAction : DebugableAction, IAction, ISimpleAction
  {
    public static readonly Key<LoopIndex> LoopIndexKey = new Key<LoopIndex>("loop");

    private readonly int myCount;
    //TODO:
    private readonly ISimpleAction myAction;

    public LoopAction(int count, IAction action)
    {
      if (count <= 0)
        throw new ArgumentException("Count should be >= 1", "count");
      myCount = count;
      myAction = (ISimpleAction) action;
    }

    public ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      Context cz = new Context();
      cz.AddAll(ctx);
      LoopIndexKey.Set(cz, new LoopIndex(0,0));
      return myAction.Compatible(cz);
    }

    public Context Apply(Context ctx)
    {
      for(int i = 0; i<myCount; i++)
      {
        ctx.Set(LoopIndexKey, new LoopIndex(i, myCount));
        ICollection<ContextMissmatch> check = myAction.Compatible(ctx);
        if (check.Count != 0)
          throw new ContextMissmatchException(check, this, ctx);

        Context newCtx = myAction.Apply(ctx);
        newCtx.AddAllNew(ctx);        
        ctx = newCtx;
      }
      return ctx;      
    }
  }
}