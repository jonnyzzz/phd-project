using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph
{
  public interface IGraphStrongComponents
  {
    IEnumerable<IStrongComponentInfo> Components { get; }
    int ComponentCount { get; }    
  }

  //TODO: Add graph data holder here.
  //TODO: Create IGraphStrongComponents<TCell, TNode> ...
  public interface IGraphStrongComponents<TCoordinate> : IGraphStrongComponents
    where TCoordinate : ICellCoordinate
  {
    ICellCoordinateSystem<TCoordinate> CoordinateSystem { get; }
        
    IEnumerable<INode<TCoordinate>> GetNodes(IEnumerable<IStrongComponentInfo> componentIds);
        
    IEnumerable<INode<TCoordinate>> GetEdgesWithFilteredEdges(INode<TCoordinate> node, IEnumerable<IStrongComponentInfo> componentIds);

    ICellCoordinateCollection<TCoordinate> GetCoordinates(IEnumerable<IStrongComponentInfo> components);

    IStrongComponentInfo GetNodeComponent(INode<TCoordinate> node);

    IGraph<TCoordinate> AsGraph(IEnumerable<IStrongComponentInfo> components);
  }
}