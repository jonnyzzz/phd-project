using System;
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

  public interface IReadonlyGraph<TCell> : IReadonlyGraph, IReadonlyGraphDeprecated<TCell>
    where TCell : ICellCoordinate
  {
    void DoGeneric(IReadonlyGraphWith<TCell> with);

    ICellCoordinateSystem<TCell> CoordinateSystem { get; }

    IEnumerable<INode<TCell>> Nodes { get; }

    IReadonlyGraph<TCell> Project(ICellCoordinateSystemProjector<TCell> projector);

    bool Contains(TCell coordinate);
    bool IsSelfLoop(TCell node);
  }

  public interface IReadonlyGraph<TCell, TNode> : IReadonlyGraph<TCell>
    where TNode : INode<TCell>
    where TCell : ICellCoordinate
  {
    [CanBeNull]
    new TNode Find(TCell node);
    
    IEnumerable<TNode> NodesInternal { get; }
    IEnumerable<TNode> GetEdgesInternal(TNode forNode);

    IGraphDataHoler<TData, TNode> CreateDataHolder<TData>(Converter<TNode, TData> def);
    IGraphDataHoler<bool, TNode> CreateNodeFlagsHolder(string key);

    bool IsSelfLoop(TNode node);
  }


  public interface IReadonlyGraphDeprecated<TCell>
    where TCell : ICellCoordinate
  {
    [Obsolete("Use DoGeneric to get IReadonlyGraph<TNode, TCell>")]
    IEnumerable<INode<TCell>> GetEdges([NotNull] INode<TCell> forNode);

    [Obsolete("Use DoGeneric to get IReadonlyGraph<TNode, TCell>")]
    INode<TCell> Find(TCell node);

    [Obsolete("Use DoGeneric to get IReadonlyGraph<TNode, TCell>")]
    IGraphDataHoler<TData, INode<TCell>> CreateDataHolder<TData>(Converter<INode<TCell>, TData> def);
  }
}