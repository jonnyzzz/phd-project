using System.Collections.Generic;
using DSIS.IntegerCoordinates;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl
{
  public abstract class IntegerCoordinateSystemActionBase2 : IntegerCoordinateSystemActionBase
  {
    protected new virtual ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate<Q>
    {
      return EmptyArray<ContextMissmatchCheck>.Instance;
    }

    protected abstract void Apply<T,Q>(T system, Context input, Context output)
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate<Q>;


    protected sealed override With Create(Context @in, Context @out)
    {
      return new With2(@in, @out, this);
    }

    protected sealed override Check Create(Context @in)
    {
      return new Check2(@in, this);
    }

    protected class Check2 : Check
    {
      private readonly IntegerCoordinateSystemActionBase2 myInstance;

      public Check2(Context context, IntegerCoordinateSystemActionBase2 instance) : base(context)
      {
        myInstance = instance;
      }

      public override void Do<T, Q>(T system)
      {
        base.Do<T, Q>(system);
        Result.AddRange(myInstance.Check<T,Q>(system, myContext));
      }
    }

    protected class With2 : With
    {
      private readonly IntegerCoordinateSystemActionBase2 myInstance;

      public With2(Context context, Context outputContext, IntegerCoordinateSystemActionBase2 instance) : base(context, outputContext)
      {
        myInstance = instance;
      }

      public override void Do<T, Q>(T system)
      {
        myInstance.Apply<T,Q>(system, myContext, myOutputContext);
      }
    }
  }
}