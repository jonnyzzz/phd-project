using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Utils;

namespace DSIS.Graph.Abstract
{
  internal class TarjanStrongComponentImpl<TCell> : IGraphStrongComponents<TCell>
    where TCell : ICellCoordinate
  {
    private static readonly IFilter ALL_FILTER = new AllFilter();
    private static readonly IFilter DROP = new DropAllFilter();
    private readonly TarjanGraph<TCell> myGraph;
    private readonly TarjanComponentInfoManager myManager;

    internal TarjanStrongComponentImpl(TarjanGraph<TCell> graph, TarjanComponentInfoManager manager)
    {
      myGraph = graph;
      myManager = manager;
    }

    public int ComponentCount
    {
      get { return myManager.Count; }
    }

    public IEnumerable<IStrongComponentInfo> Components
    {
      get { return myManager.Infos; }
    }

    public CountEnumerable<TCell> GetCoordinates(ICollection<IStrongComponentInfo> components)
    {
      int cnt = 0;
      foreach (IStrongComponentInfo info in components)
      {
        cnt += info.NodesCount;
      }
      return new CountEnumerable<TCell>(GetCoordinatesImpl(components), cnt);
    }

    public IEnumerable<INode<TCell>> GetEdgesWithFilteredEdges(INode<TCell> node,
                                                               ICollection<IStrongComponentInfo> componentIds)
    {
      var ids = GetIdsHashset(componentIds);
      foreach (TarjanNode<TCell> edge in myGraph.GetEdges(node))
      {
        if (ids.Accept(edge.ComponentId))
          yield return edge;
      }
    }

    public IStrongComponentInfo GetNodeComponent(INode<TCell> node)
    {
      return myManager.FindByNode((TarjanNode<TCell>) node);
    }

    public IGraph<TCell> AsGraph(IEnumerable<IStrongComponentInfo> components)
    {
      return AsGraphWithStrongComponents(components);
    }

    public IGraphWithStrongComponent<TCell> AsGraphWithStrongComponents(IEnumerable<IStrongComponentInfo> components)
    {
      IFilter filter = GetIdsHashset(new List<IStrongComponentInfo>(components));

      var graph = new TarjanGraph<TCell>(myGraph.CoordinateSystem);

      foreach (TarjanNode<TCell> node in myGraph.NodesInternal)
      {
        if (filter.Accept(node.ComponentId))
        {
          INode<TCell> newFrom = graph.AddNode(node.Coordinate);
          foreach (TarjanNode<TCell> tarjanNode in node.EdgesInternal)
          {
            if (filter.Accept(tarjanNode.ComponentId))
            {
              graph.AddEdgeToNode(newFrom, graph.AddNode(tarjanNode.Coordinate));
            }
          }
        }
      }
      return graph;
    }

    public ICellCoordinateSystem<TCell> CoordinateSystem
    {
      get { return myGraph.CoordinateSystem; }
    }

    public IEnumerable<INode<TCell>> GetNodes(ICollection<IStrongComponentInfo> componentIds)
    {
      IFilter ids = GetIdsHashset(componentIds);

      foreach (TarjanNode<TCell> node in myGraph.NodesInternal)
      {
        if (ids.Accept(node.ComponentId))
          yield return node;
      }
    }

    private IEnumerable<TCell> GetCoordinatesImpl(ICollection<IStrongComponentInfo> components)
    {
      foreach (INode<TCell> node in GetNodes(components))
      {
        yield return node.Coordinate;
      }
    }

    private IFilter GetIdsHashset(ICollection<IStrongComponentInfo> componentIds)
    {
      int count = componentIds.Count;
      if (count == 0)
      {
        return DROP;
      }
      if (count == 1)
      {
        return new ExactFilter(((TarjanComponentInfo) componentIds.GetFirst()).ComponentId);
      }
      if (count == myManager.Count)
      {
        return ALL_FILTER;
      }
      if (count > 10)
      {
        var ids = new Hashset<uint>();
        foreach (TarjanComponentInfo id in componentIds)
        {
          ids.Add(id.ComponentId);
        }
        return new HashSetFilter(ids);
      }
      var data = new uint[count];
      int cnt = 0;
      foreach (TarjanComponentInfo id in componentIds)
      {
        data[cnt++] = id.ComponentId;
      }
      return new ArrayFilter(data);
    }

    private class AllFilter : IFilter
    {
      public bool Accept(uint value)
      {
        return value > 0;
      }
    }

    private class ArrayFilter : IFilter
    {
      private readonly uint[] myData;

      public ArrayFilter(uint[] data)
      {
        myData = data;
      }

      public bool Accept(uint value)
      {
        if (value <= 0)
          return false;

        for (int i = 0; i < myData.Length; i++)
        {
          if (value == myData[i])
            return true;
        }
        return false;
      }
    }

    private class DropAllFilter : IFilter
    {
      public bool Accept(uint value)
      {
        return false;
      }
    }

    private class ExactFilter : IFilter
    {
      private readonly uint myValue;

      public ExactFilter(uint value)
      {
        myValue = value;
      }

      public bool Accept(uint value)
      {
        return value == myValue;
      }
    }

    private class HashSetFilter : IFilter
    {
      private readonly Hashset<uint> mySet;

      public HashSetFilter(Hashset<uint> set)
      {
        mySet = set;
      }

      public bool Accept(uint value)
      {
        return mySet.Contains(value);
      }
    }

    private interface IFilter
    {
      bool Accept(uint value);
    }
  }
}