using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Processor;
using DSIS.Graph.Abstract;
using DSIS.Utils;

namespace DSIS.Graph.Tarjan
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

    public void DoGeneric(IGraphStrongComponentsWith with)
    {
      with.With(this);
    }

    ICellCoordinateSystem IGraphStrongComponents.CoordinateSystem
    {
      get { return CoordinateSystem; }
    }

    public IEnumerable<IStrongComponentInfo> Components
    {
      get { return myManager.Infos; }
    }

    public ICellCoordinateCollection<TCell> GetCoordinates(IEnumerable<IStrongComponentInfo> components)
    {
      var set = new HashSet<IStrongComponentInfo>(components);
      
      var cnt = set.FoldLeft(0, (x, y) => x.NodesCount + y);
      var coodrs = GetNodes(components).Map(x => x.Coordinate);

      return new CellCoordinateCollection<TCell>(CoordinateSystem, coodrs, cnt);
    }

    public IEnumerable<INode<TCell>> GetEdgesWithFilteredEdges(INode<TCell> node, IEnumerable<IStrongComponentInfo> componentIds)
    {
      var ids = ComponentsFilter.CreateFilter(componentIds, ComponentCount);
      return ids.FilterUpper(myGraph.GetEdges(node));
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
        if (!filter.Accept(node.ComponentId)) 
          continue;
        
        var newFrom = graph.AddNode(node.Coordinate);
        foreach (var tarjanNode in node.EdgesInternal)
        {
          if (filter.Accept(tarjanNode.ComponentId))
          {
            graph.AddEdgeToNode(newFrom, graph.AddNode(tarjanNode.Coordinate));
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
      return ids.FilterUpper(myGraph.Nodes);
    }
  }
}