using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;

namespace DSIS.Graph
{
  public interface IGraph : IReadonlyGraph
  {
    void DoGeneric(IGraphWith with);
  }

  public interface IGraph<TCoordinate> : IGraph, IReadonlyGraph<TCoordinate>
    where TCoordinate : ICellCoordinate
  {
    /// <summary>
    /// Adds new edge connefting fromNode with toNode if there was no suck edge.
    /// </summary>
    /// <param name="fromNode"></param>
    /// <param name="toNode"></param>
    void AddEdgeToNode(INode<TCoordinate> fromNode, INode<TCoordinate> toNode);

    /// <summary>
    /// Creates new node in the graph in case this was no such node or
    /// return existing node referece.
    /// </summary>
    /// <param name="coordinate"></param>
    /// <returns></returns>
    INode<TCoordinate> AddNode(TCoordinate coordinate);

    void DoGeneric(IGraphWith<TCoordinate> with);
  }

  public interface IGraph<TCell, TNode> : IGraph<TCell>, IReadonlyGraph<TCell, TNode>
    where TNode : Node<TNode, TCell>
    where TCell : ICellCoordinate
  {
    new TNode AddNode(TCell coordinate);

    /// <summary>
    /// Adds new edge connefting fromNode with toNode if there was no suck edge.
    /// </summary>
    /// <param name="fromNode"></param>
    /// <param name="toNode"></param>
    void AddEdgeToNode(TNode fromNode, TNode toNode);
  }  
}