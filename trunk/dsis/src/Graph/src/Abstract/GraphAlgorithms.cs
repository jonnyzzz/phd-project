using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  public static partial class GraphAlgorithms
  {
    public delegate IGraph<TCell> Create<TCell>(ICellCoordinateSystem<TCell> cs) where TCell : ICellCoordinate;

    public static IGraph<TCell> Project<TCell>(this IGraph<TCell> baseGraph, ICellCoordinateSystemProjector<TCell> projector, Create<TCell> create)
      where TCell : ICellCoordinate
    {
      var toSystem = projector.ToSystem;
      var graph = create(toSystem);

      foreach (var node in baseGraph.Nodes)
      {
        var proj = projector.Project(node.Coordinate);
        if (toSystem.IsNull(proj)) 
          continue;
        
        var gNode = graph.AddNode(proj);
        if (gNode == null) 
          continue;

        foreach (var edge in baseGraph.GetEdges(node))
        {
          var eProj = projector.Project(edge.Coordinate);
          if (!toSystem.IsNull(eProj)) 
            continue;
          
          var gToNode = graph.AddNode(eProj);
          if (gToNode == null) 
            continue;
          
          graph.AddEdgeToNode(gNode, gToNode);
        }
      }
      return graph;
    }
  }
}