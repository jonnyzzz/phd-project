/*
 * Created by: 
 * Created: 1 декабря 2006 г.
 */

using System.Collections.Generic;
using System.IO;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;

namespace DSIS.Graph
{
  public interface IGraph
  {
    int NodesCount { get; }
    int EdgesCount { get; }
    
  }

  public interface IGraph<TCoordinate> : IGraph where TCoordinate : ICellCoordinate
  {
    ICellCoordinateSystem<TCoordinate> CoordinateSystem { get; }
    IEnumerable<INode<TCoordinate>> Nodes { get; }

    IEnumerable<INode<TCoordinate>> GetEdges(INode<TCoordinate> forNode);

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

    bool Contains(TCoordinate coordinate);

    IGraph<TCoordinate> Project(ICellCoordinateSystemProjector<TCoordinate> projector);

    bool HasArcToItself(TCoordinate node);

    void Dump(TextWriter tw);
    string Dump();
  }

  public interface IGraphWithStrongComponent<TCell> : IGraph<TCell>
    where TCell : ICellCoordinate
  {
    IGraphStrongComponents<TCell> ComputeStrongComponents(IProgressInfo info);
  }
}