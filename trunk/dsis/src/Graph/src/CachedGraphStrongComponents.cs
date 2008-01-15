using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph.Abstract;

namespace DSIS.Graph
{
  public class CachedGraphStrongComponents<T>  : IGraphStrongComponents<T>
    where T : ICellCoordinate
  {
    private readonly IGraphStrongComponents<T> myOriginal;
    private readonly Dictionary<IStrongComponentInfo, IGraph<T>> myCache = new Dictionary<IStrongComponentInfo, IGraph<T>>();

    public CachedGraphStrongComponents(IGraphStrongComponents<T> original)
    {
      myOriginal = original;
    }

    private IGraph<T> Cache(IStrongComponentInfo info)
    {
      IGraph<T> graph;
      if (!myCache.TryGetValue(info, out graph))
      {
        graph = myOriginal.AsGraph(new IStrongComponentInfo[] {info});
        myCache[info] = graph;
      }
      return graph;
    }

    public IEnumerable<INode<T>> GetNodes(ICollection<IStrongComponentInfo> componentIds)
    {
      foreach (IStrongComponentInfo id in componentIds)
      {
        foreach (INode<T> node in Cache(id).Nodes)
        {
          yield return node;
        }
      }
    }

    public IEnumerable<INode<T>> GetEdgesWithFilteredEdges(INode<T> node, ICollection<IStrongComponentInfo> componentIds)
    {
      //todo: Hack!
      return ((INodeInternal<T>) node).Edges;
    }

    public CountEnumerable<T> GetCoordinates(ICollection<IStrongComponentInfo> componentIds)
    {
      int N = 0;
      foreach (IStrongComponentInfo id in componentIds)
      {
        N += id.NodesCount;
      }

      return new CountEnumerable<T>(CoordinatesImpl(componentIds), N);
    }

    private IEnumerable<T> CoordinatesImpl(ICollection<IStrongComponentInfo> componentIds)
    {
      foreach (INode<T> node in GetNodes(componentIds))
      {
        yield return node.Coordinate;
      }
    }

    public IStrongComponentInfo GetNodeComponent(INode<T> node)
    {
      return myOriginal.GetNodeComponent(node);
    }

    public IGraph<T> AsGraph(IEnumerable<IStrongComponentInfo> components)
    {      
      return myOriginal.AsGraph(components);
    }

    public IGraphWithStrongComponent<T> AsGraphWithStrongComponents(IEnumerable<IStrongComponentInfo> components)
    {
      return myOriginal.AsGraphWithStrongComponents(components);
    }

    public IEnumerable<IStrongComponentInfo> Components
    {
      get { return myOriginal.Components; }
    }

    public int ComponentCount
    {
      get { return myOriginal.ComponentCount; }
    }
  }
}