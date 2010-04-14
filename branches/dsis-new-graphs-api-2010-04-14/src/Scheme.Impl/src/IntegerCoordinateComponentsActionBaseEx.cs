using System;
using System.Collections.Generic;
using DSIS.Graph;
using DSIS.IntegerCoordinates;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl
{
  public abstract class IntegerCoordinateComponentsActionBaseEx : IntegerCoordinateComponentsActionBase
  {
    protected sealed override IEnumerable<ContextMissmatchCheck> Check<T, Q, TNode>(T system, Context ctx, IReadonlyGraphStrongComponents<Q, TNode> comps)
    {
      var checks = new List<ContextMissmatchCheck>();
      GetChecks(system, comps, checks.Add);
      return ColBase(Check<T, Q>(system, ctx), checks.ToArray());
    }

    protected virtual void GetChecks<T, Q, N>(T system, IReadonlyGraphStrongComponents<Q,N> comps, Action<ContextMissmatchCheck> addCheck)
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate
      where N : class, INode<Q>
    {
    }

  }
}