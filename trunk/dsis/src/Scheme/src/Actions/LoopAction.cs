using System;
using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;

namespace DSIS.Scheme.Actions
{
  public struct LoopIndex
  {
    public readonly int Index;
    public readonly int Count;

    public LoopIndex(int index, int count)
    {
      Index = index;
      Count = count;
    }
  }

  public class LoopAction : DebugableAction, IAction
  {
    public static readonly Key<LoopIndex> LoopIndexKey = new Key<LoopIndex>("loop");

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
          throw new ContextMissmatchException(check, this);
        }
        ctx.Set(LoopIndexKey, new LoopIndex(i, myCount));
        Context newCtx = myAction.Apply(ctx);
        newCtx.AddAllNew(ctx);        
        ctx = newCtx;
      }
      return ctx;      
    }
  }
}