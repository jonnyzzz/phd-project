using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract.Algorithms
{
  public static partial class GraphAlgorithms
  {
/*
    public delegate IGraph<TCell, TNode> Create<TCell, TNode>(ICellCoordinateSystem<TCell> cs)
      where TCell : ICellCoordinate
      where TNode : class, INode<TCell>;

    public static IReadonlyGraph<TCell, TNode> Project<TCell, TNode>(this IReadonlyGraph<TCell, TNode> baseGraph, ICellCoordinateSystemProjector<TCell> projector, Create<TCell, TNode> create)
      where TCell : ICellCoordinate
      where TNode : class, INode<TCell>
    {
      var toSystem = projector.ToSystem;
      var graph = create(toSystem);

      foreach (var node in baseGraph.NodesInternal)
      {
        var proj = projector.Project(node.Coordinate);
        if (toSystem.IsNull(proj)) 
          continue;
        
        var gNode = graph.AddNode(proj);
        if (gNode == null) 
          continue;

        foreach (var edge in baseGraph.GetEdgesInternal(node))
        {
          var eProj = projector.Project(edge.Coordinate);
          if (toSystem.IsNull(eProj)) 
            continue;
          
          var gToNode = graph.AddNode(eProj);
          if (gToNode == null) 
            continue;
          
          graph.AddEdgeToNode(gNode, gToNode);
        }
      }
      return graph;
    }
*/
  }
}