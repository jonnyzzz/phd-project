using System;
using System.Collections.Generic;
using System.Linq;
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
      var set = subset.ToList();
      mySubset = new HashSet<IStrongComponentInfo>(set);

      var infos = new HashSet<IStrongComponentInfo>(components.Components);
      if (!set.All(infos.Contains))
        throw new ArgumentException("Failed to create SubComponent for alien component");
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
      var ids = componentIds.ToList();
      AssertComponent(ids);
      return myComponents.GetNodes(ids);
    }

    public IEnumerable<INode<Q>> GetEdgesWithFilteredEdges(INode<Q> node, IEnumerable<IStrongComponentInfo> componentIds)
    {
      var ids = componentIds.ToList();
      AssertComponent(ids);
      return myComponents.GetEdgesWithFilteredEdges(node, ids);
    }

    public ICellCoordinateCollection<Q> GetCoordinates(IEnumerable<IStrongComponentInfo> components)
    {
      var infos = components.ToList();
      AssertComponent(infos);
      return myComponents.GetCoordinates(infos);
    }

    public IStrongComponentInfo GetNodeComponent(INode<Q> node)
    {
      return myComponents.GetNodeComponent(node);
    }

    public IGraph<Q> AsGraph(IEnumerable<IStrongComponentInfo> components)
    {
      var infos = components.ToList();
      if (infos.Any(t => mySubset.Contains(t))) 
        return myComponents.AsGraph(infos);
      return null;
    }
  }
}