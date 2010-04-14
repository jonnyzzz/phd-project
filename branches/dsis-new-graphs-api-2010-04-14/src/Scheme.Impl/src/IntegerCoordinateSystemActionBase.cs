using System.Collections.Generic;
using DSIS.IntegerCoordinates;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl
{
  public abstract class IntegerCoordinateSystemActionBase : ActionBase
  {
    public sealed override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      if (ctx.ContainsKey(Keys.IntegerCoordinateSystemInfo))
      {
        Check check = Create(ctx);
        Keys.IntegerCoordinateSystemInfo.Get(ctx).DoGeneric(check);
        return CheckContext(ctx, check.Result.ToArray());
      }
      else
      {
        return CheckContext(ctx, Create(Keys.IntegerCoordinateSystemInfo));
      }
    }

    protected sealed override void Apply(Context ctx, Context result)
    {
      IIntegerCoordinateSystem info = ctx.Get(Keys.IntegerCoordinateSystemInfo);
//      Keys.IntegerCoordinateSystemInfo.Set(result, info);
      info.DoGeneric(Create(ctx, result));      
    }

    protected abstract With Create(Context @in, Context @out);

    protected virtual Check Create(Context @in)
    {
      return new Check(@in);
    }

    protected class Check : IIntegerCoordinateSystemWith
    {
      protected readonly Context myContext;
      public readonly List<ContextMissmatchCheck> Result = new List<ContextMissmatchCheck>();

      public Check(Context context)
      {
        myContext = context;
      }

      public virtual void Do<T, Q>(T system) 
        where T : IIntegerCoordinateSystem<Q> 
        where Q : IIntegerCoordinate
      {
      }
    }

    protected abstract class With : IIntegerCoordinateSystemWith
    {
      protected readonly Context myContext;
      protected readonly Context myOutputContext;

      protected With(Context context, Context outputContext)
      {
        myContext = context;
        myOutputContext = outputContext;
      }

      public abstract void Do<T, Q>(T system)
        where T : IIntegerCoordinateSystem<Q>
        where Q : IIntegerCoordinate;
    }
  }
}