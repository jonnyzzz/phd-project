﻿using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using JetBrains.Annotations;

namespace DSIS.Graph
{
  public interface IReadonlyGraph
  {
    int NodesCount { get; }
    int EdgesCount { get; }

    void DoGeneric(IReadonlyGraphWith with);
  }

  public interface IReadonlyGraph<TCell> : IReadonlyGraph
    where TCell : ICellCoordinate
  {
    ICellCoordinateSystem<TCell> CoordinateSystem { get; }
    IReadonlyGraph<TCell> Project(ICellCoordinateSystemProjector<TCell> projector);

    bool Contains(TCell coordinate);

    [Obsolete("Use TNode version")]
    bool IsSelfLoop(TCell node);

    IEnumerable<TCell> NodesCoordinates { get; }
    IEnumerable<INode<TCell>> Nodes { get; }

    void DoGeneric(IReadonlyGraphWith<TCell> with);
  }

  public interface IReadonlyGraph<TCell, TNode> : IReadonlyGraph<TCell>
    where TNode : class, INode<TCell>
    where TCell : ICellCoordinate
  {
    [CanBeNull]
    TNode Find(TCell node);
    
    IEnumerable<TNode> NodesInternal { get; }
    IEnumerable<TNode> GetEdgesInternal(TNode forNode);

    IGraphDataHolder<TData, TNode> CreateDataHolder<TData>(Converter<TNode, TData> def);
    IGraphDataHolder<bool, TNode> CreateNodeFlagsHolder(string key);
    IGraphDataHolder<uint, TNode> GetComponentIdHolder();

    //TODO: Move to INode
    bool IsSelfLoop(TNode node);

    IEqualityComparer<TNode> Comparer { get; }
  }
}