using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph;
using DSIS.Util;

namespace DSIS.Graph.Abstract
{
  internal class TarjanStrongComponentImpl<TCell, TValue> : IGraphStrongComponents<TCell, TValue>
    where TCell : ICellCoordinate<TCell>
  {
    private TarjanGraph<TCell, TValue> myGraph;
    private TarjanComponentInfoManager myManager;

    internal TarjanStrongComponentImpl(TarjanGraph<TCell, TValue> graph, TarjanComponentInfoManager manager)
    {
      myGraph = graph;
      myManager = manager;
    }

    public IEnumerable<IStrongComponentInfo> Components
    {
      get { return myManager.Infos; }
    }

    public int ComponentCount
    {
      get { return myManager.Count; }
    }

    public IEnumerable<INode<TCell, TValue>> GetNodes(IEnumerable<IStrongComponentInfo> componentIds)
    {
      Hashset<uint> ids = GetIdsHashset(componentIds);

      if (ids.Count == 0)
        yield break;
      
      foreach (TarjanNode<TCell, TValue> node in myGraph.NodesInternal)
      {
        if (ids.Contains(node.ComponentId))
          yield return node;
      }
    }

    private static Hashset<uint> GetIdsHashset(IEnumerable<IStrongComponentInfo> componentIds)
    {
      Hashset<uint> ids = new Hashset<uint>();
      foreach (TarjanComponentInfo id in componentIds)
      {
        ids.Add(id.ComponentId);
      }
      return ids;
    }

    public IEnumerable<INode<TCell, TValue>> GetEdgesWithFilteredEdges(INode<TCell, TValue> node, IEnumerable<IStrongComponentInfo> componentIds)
    {
      Hashset<uint> ids = GetIdsHashset(componentIds);
      foreach (TarjanNode<TCell, TValue> edge in myGraph.GetEdges(node))
      {
        if (ids.Contains(edge.ComponentId))
          yield return edge;
      }
    }

    public IEnumerable<TCell> GetCoordinates(IEnumerable<IStrongComponentInfo> components)
    {
      foreach (INode<TCell, TValue> node in GetNodes(components))
      {
        yield return node.Coordinate;
      }
    }
  }
}