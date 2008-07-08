/*
 * Created by: 
 * Created: 1 ������� 2006 �.
 */

using System;
using System.Collections.Generic;
using System.IO;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;

namespace DSIS.Graph
{
  public interface IGraph
  {
    int NodesCount { get; }
    int EdgesCount { get; }

    void Dump(TextWriter tw);
    string Dump();

    void DoGeneric(IGraphWith with);    
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
    
    bool IsSelfLoop(TCoordinate node);

    [Obsolete("Use DoGeneric to get IGraph<TNode, TCell>")]
    IGraphDataHoler<TData, INode<TCoordinate>> CreateDataHolder<TData>(Converter<INode<TCoordinate>, TData> def);
    
    void DoGeneric(IGraphWith<TCoordinate> with);    
  }

  public interface IGraph<TCell, TNode> : IGraph<TCell>
    where TNode : Node<TNode, TCell>
    where TCell : ICellCoordinate
  {
    IEnumerable<TNode> NodesInternal { get; }
    IEnumerable<TNode> GetEdgesInternal(INode<TCell> forNode);

    new TNode AddNode(TCell coordinate);

    new IGraph<TCell, TNode> Project(ICellCoordinateSystemProjector<TCell> projector);

    IGraphDataHoler<TData, TNode> CreateDataHolder<TData>(Converter<TNode,TData> def);

    IGraphDataHoler<bool, TNode> CreateNodeFlagsHolder(string key);

    bool Contains(TNode coordinate);

    bool IsSelfLoop(TNode node);
  }  
}