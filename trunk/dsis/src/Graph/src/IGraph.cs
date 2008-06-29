/*
 * Created by: 
 * Created: 1 декабря 2006 г.
 */

using System;
using System.Collections.Generic;
using System.IO;
using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph.Abstract;
using DSIS.Utils;

namespace DSIS.Graph
{
  public interface IGraph
  {
    int NodesCount { get; }
    int EdgesCount { get; }

    NodeFlags NodeFlags { get; }

    void Dump(TextWriter tw);
    string Dump();

    void DoGeneric(IGraphWith with);    
  }
  
  public interface IGraphWith
  {
    void With<TCell, TNode>(IGraph<TCell, TNode> graph)
      where TCell : ICellCoordinate
      where TNode : Node<TNode, TCell>;
  }
  
  public interface IGraphWith<TCell> 
    where TCell : ICellCoordinate
  {
    void With<TNode>(IGraph<TCell, TNode> graph)
      where TNode : Node<TNode, TCell>;
  }


  public interface IGraphDataHoler<TData,TNode> : IDisposable
  {
    TData GetData(TNode node);

    void SetData(TNode node, TData data);
    bool HasData(TNode node);

    void CleanAll();
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

    IGraphDataHoler<TData, INode<TCoordinate>> CreateDataHolder<TData>(Converter<INode<TCoordinate>, TData> def);
    void DisposeDataHolder<TData>(IGraphDataHoler<TData, INode<TCoordinate>> holder);

    void DoGeneric(IGraphWith<TCoordinate> with);    
  }

  public interface IGraph<TCell, TNode> : IGraph<TCell>
    where TNode : Node<TNode, TCell>
    where TCell : ICellCoordinate
  {
    IEnumerable<TNode> NodesInternal { get; }
    IEnumerable<TNode> GetEdgesInternal(INode<TCell> forNode);

    IGraphDataHoler<TData, TNode> CreateDataHolder<TData>(Converter<TNode,TData> def);
    void DisposeDataHolder<TData>(IGraphDataHoler<TData, TNode> holder);

    bool Contains(TNode coordinate);

    bool IsSelfLoop(TNode node);
  }  
}