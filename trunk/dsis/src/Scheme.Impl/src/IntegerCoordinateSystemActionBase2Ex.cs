using System;
using System.Collections.Generic;
using DSIS.IntegerCoordinates;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl
{
  public abstract class IntegerCoordinateSystemActionBase2Ex : IntegerCoordinateSystemActionBase2
  {
    protected sealed override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      var checks = new List<ContextMissmatchCheck>();
      GetChecks<T,Q>(system, checks.Add);
      return ColBase(base.Check<T, Q>(system, ctx), checks.ToArray());
    }

    protected virtual void GetChecks<T, Q>(T system, Action<ContextMissmatchCheck> addCheck)
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate
    {      
    }
  }
}