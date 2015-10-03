using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph
{
  public interface IGraphStrongComponents
  {
    ICellCoordinateSystem CoordinateSystem { get; }
    IEnumerable<IStrongComponentInfo> Components { get; }
    int ComponentCount { get; }

    void DoGeneric(IGraphStrongComponentsWith with);
  }

  public interface IGraphStrongComponentsWith
  {
    void With<Q>(IGraphStrongComponents<Q> components) where Q : ICellCoordinate;
  }

  //TODO: Add graph data holder here.
  //TODO: Create IGraphStrongComponents<TCell, TNode> ...
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
}