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
  public interface IGraph<TCoordinate, TNodeValue> where TCoordinate : ICellCoordinate <TCoordinate>
  {
    ICellCoordinateSystem<TCoordinate> CoordinateSystem { get; }
    IEnumerable<INode<TCoordinate,TNodeValue>> Nodes { get; }

    int NodesCount { get; }
    int EdgesCount { get; }

    IEnumerable<INode<TCoordinate, TNodeValue>> GetEdges(INode<TCoordinate, TNodeValue> forNode);

    /// <summary>
    /// Adds new edge connefting fromNode with toNode if there was no suck edge.
    /// </summary>
    /// <param name="fromNode"></param>
    /// <param name="toNode"></param>
    void AddEdgeToNode(INode<TCoordinate, TNodeValue> fromNode, INode<TCoordinate, TNodeValue> toNode);

    /// <summary>
    /// Creates new node in the graph in case this was no such node or
    /// return existing node referece.
    /// </summary>
    /// <param name="coordinate"></param>
    /// <returns></returns>
    INode<TCoordinate, TNodeValue> AddNode(TCoordinate coordinate);

    void Dump(TextWriter tw);
    string Dump();
  }

  public interface IGraphWithStrongComponent<TCell, TValue> : IGraph<TCell, TValue> where TCell : ICellCoordinate<TCell>
  {
    IGraphStrongComponents<TCell, TValue> ComputeStrongComponents(IProgressInfo info);
  }
}