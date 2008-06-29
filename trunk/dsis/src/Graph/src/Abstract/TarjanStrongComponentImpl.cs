using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;

namespace DSIS.Graph.Abstract
{
  internal class TarjanStrongComponentImpl<TCell, TNode> : IGraphStrongComponents<TCell>
    where TCell : ICellCoordinate
    where TNode : Node<TNode, TCell>
  {
    private readonly IGraph<TCell,TNode> myGraph;
    private readonly TarjanComponentInfoManager myManager;

    internal TarjanStrongComponentImpl(IGraph<TCell, TNode> graph, TarjanComponentInfoManager manager)
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

    public IEnumerable<INode<TCell>> GetEdgesWithFilteredEdges(INode<TCell> node, IEnumerable<IStrongComponentInfo> componentIds)
    {
      var ids = ComponentsFilter.CreateFilter(componentIds, ComponentCount);      
      foreach (TNode edge in myGraph.GetEdges(node))
      {
        if (ids.Accept(edge.ComponentId))
          yield return edge;
      }
    }

    public IStrongComponentInfo GetNodeComponent(INode<TCell> node)
    {
      return myManager.FindByNode(node);
    }

    public IGraph<TCell> AsGraph(IEnumerable<IStrongComponentInfo> components)
    {
      var filter = ComponentsFilter.CreateFilter(components, ComponentCount);

      var graph = new TarjanGraph<TCell>(myGraph.CoordinateSystem);

      foreach (var node in myGraph.NodesInternal)
      {
        if (filter.Accept(node.ComponentId))
        {
          INode<TCell> newFrom = graph.AddNode(node.Coordinate);
          foreach (var tarjanNode in node.EdgesInternal)
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

    public IEnumerable<INode<TCell>> GetNodes(IEnumerable<IStrongComponentInfo> componentIds)
    {
      var ids = ComponentsFilter.CreateFilter(componentIds, ComponentCount);

      foreach (var node in myGraph.NodesInternal)
      {
        if (ids.Accept(node.ComponentId))
          yield return node;
      }
    }

    private IEnumerable<TCell> GetCoordinatesImpl(IEnumerable<IStrongComponentInfo> components)
    {
      foreach (INode<TCell> node in GetNodes(components))
      {
        yield return node.Coordinate;
      }
    }
  }
}