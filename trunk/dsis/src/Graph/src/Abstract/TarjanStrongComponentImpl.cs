using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Utils;

namespace DSIS.Graph.Abstract
{
  internal class TarjanStrongComponentImpl<TCell> : IGraphStrongComponents<TCell>
    where TCell : ICellCoordinate<TCell>
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

    #region IGraphStrongComponents<TCell> Members

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
      IFilter ids = GetIdsHashset(componentIds);
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
      IFilter filter = GetIdsHashset(new List<IStrongComponentInfo>(components));

      TarjanGraph<TCell> graph = new TarjanGraph<TCell>(myGraph.CoordinateSystem);

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

    public IEnumerable<INode<TCell>> GetNodes(ICollection<IStrongComponentInfo> componentIds)
    {
      IFilter ids = GetIdsHashset(componentIds);

      foreach (TarjanNode<TCell> node in myGraph.NodesInternal)
      {
        if (ids.Accept(node.ComponentId))
          yield return node;
      }
    }

    #endregion

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
      else if (count == 1)
      {
        return new ExactFilter(((TarjanComponentInfo) CollectionUtil.GetFirst(componentIds)).ComponentId);
      }
      else if (count == myManager.Count)
      {
        return ALL_FILTER;
      }
      else if (count > 10)
      {
        Hashset<uint> ids = new Hashset<uint>();
        foreach (TarjanComponentInfo id in componentIds)
        {
          ids.Add(id.ComponentId);
        }
        return new HashSetFilter(ids);
      }
      else
      {
        uint[] data = new uint[count];
        int cnt = 0;
        foreach (TarjanComponentInfo id in componentIds)
        {
          data[cnt++] = id.ComponentId;
        }
        return new ArrayFilter(data);
      }
    }

    #region Nested type: AllFilter

    private class AllFilter : IFilter
    {
      #region IFilter Members

      public bool Accept(uint value)
      {
        return value > 0;
      }

      #endregion
    }

    #endregion

    #region Nested type: ArrayFilter

    private class ArrayFilter : IFilter
    {
      private readonly uint[] myData;

      public ArrayFilter(uint[] data)
      {
        myData = data;
      }

      #region IFilter Members

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

      #endregion
    }

    #endregion

    #region Nested type: DropAllFilter

    private class DropAllFilter : IFilter
    {
      #region IFilter Members

      public bool Accept(uint value)
      {
        return false;
      }

      #endregion
    }

    #endregion

    #region Nested type: ExactFilter

    private class ExactFilter : IFilter
    {
      private readonly uint myValue;

      public ExactFilter(uint value)
      {
        myValue = value;
      }

      #region IFilter Members

      public bool Accept(uint value)
      {
        return value == myValue;
      }

      #endregion
    }

    #endregion

    #region Nested type: HashSetFilter

    private class HashSetFilter : IFilter
    {
      private readonly Hashset<uint> mySet;

      public HashSetFilter(Hashset<uint> set)
      {
        mySet = set;
      }

      #region IFilter Members

      public bool Accept(uint value)
      {
        return mySet.Contains(value);
      }

      #endregion
    }

    #endregion

    #region Nested type: IFilter

    private interface IFilter
    {
      bool Accept(uint value);
    }

    #endregion
  }
}