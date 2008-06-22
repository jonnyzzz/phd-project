using System;
using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;

namespace DSIS.Scheme.Actions
{
  public class LoopAction : DebugableAction, IAction
  {
    public static readonly Key<LoopIndex> LoopIndexKey = new Key<LoopIndex>("loop");

    private readonly string myKey;
    private readonly int myCount;
    private readonly IAction myAction;

    public LoopAction(string key, int count, IAction action)
    {
      if (count <= 0)
        throw new ArgumentException("Count should be >= 1", "count");
      myCount = count;
      myKey = key;
      myAction = action;
    }

    public ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      var cz = new Context();
      cz.AddAll(ctx);
      LoopIndexKey.Set(cz, new LoopIndex(0,0));
      Key().Set(cz, new LoopIndex(0,0));
      return myAction.Compatible(cz);
    }

    public Context Apply(Context ctx)
    {
      for(int i = 0; i<myCount; i++)
      {
        LoopIndexKey.Set(ctx, new LoopIndex(i, myCount));
        Key().Set(ctx, new LoopIndex(i, myCount));
        var check = myAction.Compatible(ctx);
        if (check.Count != 0)
          throw new ContextMissmatchException(check, this, ctx);

        var newCtx = myAction.Apply(ctx);
        newCtx.AddAllNew(ctx);        
        ctx = newCtx;
      }
      return ctx;      
    }

    public Key<LoopIndex> Key()
    {
      return CreateKey(myKey);
    }

    public static Key<LoopIndex> CreateKey(string key)
    {
      return new Key<LoopIndex>(key);
    }

    public delegate void ConstructGraph(IActionGraphPartBuilder bld, Key<LoopIndex> key);
    public static LoopAction CreateAgreagated(string key, int count, ConstructGraph constructor)
    {
      return new LoopAction(key, count, new AgregateAction(x => constructor(x, CreateKey(key))));      
    }
  }
}