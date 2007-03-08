using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Utils;

namespace DSIS.Graph.Abstract
{
  internal class TarjanStrongComponentImpl<TCell> : IGraphStrongComponents<TCell>
    where TCell : ICellCoordinate<TCell>
  {
    private TarjanGraph<TCell> myGraph;
    private TarjanComponentInfoManager myManager;

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

    public IEnumerable<TCell> GetCoordinates(IEnumerable<IStrongComponentInfo> components)
    {
      foreach (INode<TCell> node in GetNodes(components))
      {
        yield return node.Coordinate;
      }
    }

    public IEnumerable<INode<TCell>> GetEdgesWithFilteredEdges(INode<TCell> node,
                                                               IEnumerable<IStrongComponentInfo> componentIds)
    {
      Hashset<uint> ids = GetIdsHashset(componentIds);
      foreach (TarjanNode<TCell> edge in myGraph.GetEdges(node))
      {
        if (ids.Contains(edge.ComponentId))
          yield return edge;
      }
    }

    public IStrongComponentInfo GetNodeComponent(INode<TCell> node)
    {
      return myManager.FindByNode((TarjanNode<TCell>) node);
    }

    public IEnumerable<INode<TCell>> GetNodes(IEnumerable<IStrongComponentInfo> componentIds)
    {
      Hashset<uint> ids = GetIdsHashset(componentIds);

      if (ids.Count == 0)
        yield break;


      foreach (TarjanNode<TCell> node in myGraph.NodesInternal)
      {
        if (ids.Contains(node.ComponentId))
          yield return node;
      }
    }

    #endregion

    private static Hashset<uint> GetIdsHashset(IEnumerable<IStrongComponentInfo> componentIds)
    {
      Hashset<uint> ids = new Hashset<uint>();
      foreach (TarjanComponentInfo id in componentIds)
      {
        ids.Add(id.ComponentId);
      }
      return ids;
    }
  }
}