using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Loop.Iterators
{
  public abstract class ContextBase<T,N> 
    where T : ICellCoordinate
    where N : class, INode<T>
  {
    protected readonly IReadonlyGraphStrongComponents<T, N> myComponents;
    [Obsolete]
    protected readonly IStrongComponentInfo myComponent;

    protected readonly IReadonlyGraphStrongComponentsAccessor<T, N> myAccessor;
    protected readonly IEqualityComparer<N> COMPARER;

    protected ContextBase(IReadonlyGraphStrongComponents<T, N> components, IStrongComponentInfo component)
    {
      if (component == null)
        throw new ArgumentNullException("component");

      myComponents = components;

      myAccessor = components.Accessor(component.Enum());
      COMPARER = components.UnderlyingGraph.Comparer;
    }
  }
}