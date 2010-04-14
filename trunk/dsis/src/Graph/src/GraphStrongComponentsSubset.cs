using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph
{
  public class GraphStrongComponentsSubset<Q> : IGraphStrongComponents<Q>
    where Q : ICellCoordinate
  {
    private readonly IGraphStrongComponents<Q> myComponents;
    private readonly HashSet<IStrongComponentInfo> mySubset;

    public GraphStrongComponentsSubset(IGraphStrongComponents<Q> components, IEnumerable<IStrongComponentInfo> subset)
    {
      myComponents = components;
      mySubset = new HashSet<IStrongComponentInfo>(subset);

      if (!new HashSet<IStrongComponentInfo>(components.Components).ContainsAll(subset))
      {
        throw new ArgumentException("Failed to create SubComponent for alien component");
      }
    }

    ICellCoordinateSystem IGraphStrongComponents.CoordinateSystem
    {
      get { return CoordinateSystem; }
    }

    public IEnumerable<IStrongComponentInfo> Components
    {
      get { return mySubset; }
    }

    public int ComponentCount
    {
      get { return mySubset.Count; }
    }

    public void DoGeneric(IGraphStrongComponentsWith with)
    {
      with.With(this);
    }

    public ICellCoordinateSystem<Q> CoordinateSystem
    {
      get { return myComponents.CoordinateSystem; }
    }

    private void AssertComponent(IStrongComponentInfo info)
    {
      if (!mySubset.Contains(info))
        throw new ArgumentException(string.Format("Component {0} is not contained in StrongComponentsSubset", info));
    }

    private void AssertComponent(IEnumerable<IStrongComponentInfo> info)
    {
      info.ForEach(AssertComponent);
    }

    public IEnumerable<INode<Q>> GetNodes(IEnumerable<IStrongComponentInfo> componentIds)
    {
      AssertComponent(componentIds);
      return myComponents.GetNodes(componentIds);
    }

    public IEnumerable<INode<Q>> GetEdgesWithFilteredEdges(INode<Q> node, IEnumerable<IStrongComponentInfo> componentIds)
    {
      AssertComponent(componentIds);
      return myComponents.GetEdgesWithFilteredEdges(node, componentIds);
    }

    public ICellCoordinateCollection<Q> GetCoordinates(IEnumerable<IStrongComponentInfo> components)
    {
      AssertComponent(components);
      return myComponents.GetCoordinates(components);
    }

    public IStrongComponentInfo GetNodeComponent(INode<Q> node)
    {
      return myComponents.GetNodeComponent(node);
    }

    public IGraph<Q> AsGraph(IEnumerable<IStrongComponentInfo> components)
    {
      if (mySubset.ContainsAny(components)) 
        return myComponents.AsGraph(components);
      return null;
    }
  }
}