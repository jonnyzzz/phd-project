using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph
{
  public interface IReadonlyGraphStrongComponentsShared
  {
    IEnumerable<IStrongComponentInfo> Components { get; }

    int ComponentCount { get; }
  }

  public interface IReadonlyGraphStrongComponents : IReadonlyGraphStrongComponentsShared
  {
    ICellCoordinateSystem CoordinateSystem { get; }

    void DoGeneric(IReadonlyGraphStrongComponentsWith with);
  }


  public interface IReadonlyGraphComponentsShared<TCell> : IReadonlyGraphStrongComponentsShared
    where TCell : ICellCoordinate
  {
    ICellCoordinateSystem<TCell> CoordinateSystem { get; }
  }

  public interface IReadonlyGraphStrongComponents<TCell> : IReadonlyGraphComponentsShared<TCell>
    where TCell : ICellCoordinate
  {
    IReadonlyGraphStrongComponentsAccessor<TCell> Accessor(IEnumerable<IStrongComponentInfo> components);

    void DoGeneric(IReadonlyGraphStrongComponentsWith<TCell> with);

    IReadonlyGraphStrongComponents Upcast { get; }
  }

  public interface IReadonlyGraphStrongComponentsAccessor<TCell>
    where TCell : ICellCoordinate
  {
    ICellCoordinateCollection<TCell> GetCoordinates();

    IReadonlyGraph<TCell> AsGraph();
  }

  public interface IReadonlyGraphStrongComponentsAccessor<TCell, TNode> : IReadonlyGraphStrongComponentsAccessor<TCell>
    where TCell : ICellCoordinate
    where TNode : class, INode<TCell>
  {
    IEnumerable<TNode> GetNodes();
    IEnumerable<TNode> GetEdges(TNode node);
  }

  public interface IReadonlyGraphStrongComponents<TCell, TNode> : IReadonlyGraphStrongComponentsShared 
    where TCell : ICellCoordinate
    where TNode : class, INode<TCell>
  {
    IReadonlyGraphStrongComponents<TCell> Upcast { get; }

    IStrongComponentInfo Find(TNode node);

    IReadonlyGraph<TCell, TNode> UnderlyingGraph { get; }
    
    IReadonlyGraphStrongComponentsAccessor<TCell, TNode> Accessor(IEnumerable<IStrongComponentInfo> components);
  }


  //TODO: Add graph data holder here.
  //TODO: Create IGraphStrongComponents<TCell, TNode> ...
  [Obsolete]
  public interface IGraphStrongComponents<Q> : IGraphStrongComponents
    where Q : ICellCoordinate
  {
    new ICellCoordinateSystem<Q> CoordinateSystem { get; }

    IEnumerable<INode<Q>> GetNodes(IEnumerable<IStrongComponentInfo> componentIds);

    IEnumerable<INode<Q>> GetEdgesWithFilteredEdges(INode<Q> node, IEnumerable<IStrongComponentInfo> componentIds);

    ICellCoordinateCollection<Q> GetCoordinates(IEnumerable<IStrongComponentInfo> components);

    IStrongComponentInfo GetNodeComponent(INode<Q> node);

    IGraph<Q> AsGraph(IEnumerable<IStrongComponentInfo> components);
  }

  public interface IGraphStrongComponents : IReadonlyGraphStrongComponents
  {
    void DoGeneric(IGraphStrongComponentsWith with);
  }

  public interface IReadonlyGraphStrongComponentsWith
  {
    void With<TCell, TNode>(IReadonlyGraphStrongComponents<TCell, TNode> components)
      where TCell : ICellCoordinate
      where TNode : class, INode<TCell>;
  }

  public interface IReadonlyGraphStrongComponentsWith<TCell>
    where TCell : ICellCoordinate
  {
    void With<TNode>(IReadonlyGraphStrongComponents<TCell, TNode> components)
      where TNode : class, INode<TCell>;
  }

  public interface IGraphStrongComponentsWith
  {
    void With<TCell>(IGraphStrongComponents<TCell> components) where TCell : ICellCoordinate;
  }


}