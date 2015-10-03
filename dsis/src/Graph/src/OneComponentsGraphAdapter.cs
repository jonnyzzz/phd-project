using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph.Abstract;
using DSIS.Utils;

namespace DSIS.Graph
{
  public class OneComponentsGraphAdapter<T> : IGraphStrongComponents<T> 
    where T : ICellCoordinate
  {
    private readonly IGraphStrongComponents<T> myComps;
    private readonly IStrongComponentInfo myComponent;

    public OneComponentsGraphAdapter(IGraphStrongComponents<T> comps, IStrongComponentInfo component)
    {
      myComps = comps;
      myComponent = component;

      if (!CollectionUtil.Contains(myComps.Components, component))
        throw new ArgumentException();
    }

    public ICellCoordinateSystem<T> CoordinateSystem
    {
      get { return myComps.CoordinateSystem; }
    }

    public IEnumerable<INode<T>> GetNodes(ICollection<IStrongComponentInfo> componentIds)
    {
      return myComps.GetNodes(componentIds);
    }

    public IEnumerable<INode<T>> GetEdgesWithFilteredEdges(INode<T> node, ICollection<IStrongComponentInfo> componentIds)
    {
      return myComps.GetEdgesWithFilteredEdges(node, componentIds);
    }

    public CountEnumerable<T> GetCoordinates(ICollection<IStrongComponentInfo> components)
    {
      return myComps.GetCoordinates(components);
    }

    public IStrongComponentInfo GetNodeComponent(INode<T> node)
    {
      return myComps.GetNodeComponent(node);
    }

    public IGraph<T> AsGraph(IEnumerable<IStrongComponentInfo> components)
    {
      return myComps.AsGraph(components);
    }

    public IGraphWithStrongComponent<T> AsGraphWithStrongComponents(IEnumerable<IStrongComponentInfo> components)
    {
      return myComps.AsGraphWithStrongComponents(components);
    }

    public IEnumerable<IStrongComponentInfo> Components
    {
      get { return new IStrongComponentInfo[] { myComponent }; }
    }

    public int ComponentCount
    {
      get { return 1; }
    }
  }
}