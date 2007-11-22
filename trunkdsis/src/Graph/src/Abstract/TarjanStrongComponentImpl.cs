using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Utils;

namespace DSIS.Graph.Abstract
{
  internal class TarjanStrongComponentImpl<TCell> : IGraphStrongComponents<TCell>
    where TCell : ICellCoordinate<TCell>
  {
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
      Predicate<uint> ids = GetIdsHashset(componentIds);
      foreach (TarjanNode<TCell> edge in myGraph.GetEdges(node))
      {
        if (ids(edge.ComponentId))
          yield return edge;
      }
    }

    public IStrongComponentInfo GetNodeComponent(INode<TCell> node)
    {
      return myManager.FindByNode((TarjanNode<TCell>) node);
    }

    public IEnumerable<INode<TCell>> GetNodes(ICollection<IStrongComponentInfo> componentIds)
    {
      Predicate<uint> ids = GetIdsHashset(componentIds);

      foreach (TarjanNode<TCell> node in myGraph.NodesInternal)
      {
        if (ids(node.ComponentId))
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

    private static Predicate<uint> GetIdsHashset(ICollection<IStrongComponentInfo> componentIds)
    {
      int count = componentIds.Count;
      if (count == 0)
      {
        return delegate { return false; };
      }
      else if (count == 1)
      {
        uint cid = 0;
        foreach (TarjanComponentInfo id in componentIds)
        {
          cid = id.ComponentId;
          break;
        }
        return delegate(uint v) { return v == cid; };
      }
      else if (count > 10)
      {
        Hashset<uint> ids = new Hashset<uint>();
        foreach (TarjanComponentInfo id in componentIds)
        {
          ids.Add(id.ComponentId);
        }
        return ids.Contains;
      }
      else
      {
        uint[] data = new uint[count];
        int cnt = 0;
        foreach (TarjanComponentInfo id in componentIds)
        {
          data[cnt++] = id.ComponentId;
        }
        return delegate(uint v)
                 {
                   for (int i = 0; i < cnt; i++)
                     if (data[i] == v)
                       return true;
                   return false;
                 };
      }
    }
  }
}