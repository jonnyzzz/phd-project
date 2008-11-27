using System.Collections.Generic;
using DSIS.IntegerCoordinates;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl
{
  public abstract class IntegerCoordinateSystemActionBase3 : IntegerCoordinateSystemActionBase2
  {
    private int? myDimension;

    public int Dimension
    {
      get
      {
        return myDimension.Value;
      }
    }

    protected virtual ICollection<ContextMissmatchCheck> Check<T, Q>(Context ctx)
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate
    {
      return EmptyArray<ContextMissmatchCheck>.Instance;
    }

    protected sealed override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      myDimension = system.Dimension;
      try
      {
        return ColBase(base.Check<T, Q>(system, ctx), Check<T, Q>(ctx).ToArray());       
      } finally
      {
        myDimension = null;
      }
    }

    protected abstract void Apply<T, Q>(Context input, Context output)
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate;


    protected sealed override void Apply<T, Q>(T system, Context input, Context output)
    {
      try
      {
        myDimension = system.Dimension;
        Apply<T, Q>(input, output);
      } finally
      {
        myDimension = null;
      }
    }
  }
}