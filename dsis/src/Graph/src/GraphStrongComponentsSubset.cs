using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph
{
  public class GraphStrongComponentsSubset<Q, T> : IReadonlyGraphStrongComponents<Q, T>, IReadonlyGraphStrongComponents<Q>, IReadonlyGraphStrongComponents
    where Q : ICellCoordinate
    where T : class, INode<Q>
  {
    private readonly IReadonlyGraphStrongComponents<Q,T> myComponents;
    private readonly HashSet<IStrongComponentInfo> mySubset;

    public GraphStrongComponentsSubset(IReadonlyGraphStrongComponents<Q,T> components, IEnumerable<IStrongComponentInfo> subset)
    {
      myComponents = components;
      mySubset = new HashSet<IStrongComponentInfo>(subset);

      if (!new HashSet<IStrongComponentInfo>(components.Components).ContainsAll(subset))
      {
        throw new ArgumentException("Failed to create SubComponent for alien component");
      }
    }

    IReadonlyGraphStrongComponentsAccessor<Q> IReadonlyGraphStrongComponents<Q>.Accessor(IEnumerable<IStrongComponentInfo> components)
    {
      return Accessor(components);
    }

    public void DoGeneric(IReadonlyGraphStrongComponentsWith<Q> with)
    {
      with.With(this);
    }

    IReadonlyGraphStrongComponents IReadonlyGraphStrongComponents<Q>.Upcast
    {
      get { return this; }
    }

    public IReadonlyGraphStrongComponents<Q> Upcast
    {
      get { return this; }
    }

    public IStrongComponentInfo Find(T node)
    {
      var c = myComponents.Find(node);
      if (c == null || !mySubset.Contains(c)) return null;
      return c;
    }

    public IReadonlyGraph<Q, T> UnderlyingGraph
    {
      get { return myComponents.UnderlyingGraph; }
    }

    public IReadonlyGraphStrongComponentsAccessor<Q, T> Accessor(IEnumerable<IStrongComponentInfo> components)
    {
      return myComponents.Accessor(components.Where(mySubset.Contains).ToArray());
    }

    public IEnumerable<IStrongComponentInfo> Components
    {
      get { return mySubset; }
    }

    public int ComponentCount
    {
      get { return mySubset.Count; }
    }

    public ICellCoordinateSystem<Q> CoordinateSystem
    {
      get { return myComponents.Upcast.CoordinateSystem; }
    }

    public void DoGeneric(IReadonlyGraphStrongComponentsWith with)
    {
      with.With(this);
    }

    ICellCoordinateSystem IReadonlyGraphStrongComponents.CoordinateSystem
    {
      get { return CoordinateSystem; }
    }
  }
}