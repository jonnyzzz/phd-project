using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph.Abstract;

namespace DSIS.Graph
{
  public interface IGraphStrongComponents
  {
    IEnumerable<IStrongComponentInfo> Components { get; }
    int ComponentCount { get; }    
  }

  public interface IGraphStrongComponents<TCoordinate> : IGraphStrongComponents
    where TCoordinate : ICellCoordinate
  {
    ICellCoordinateSystem<TCoordinate> CoordinateSystem { get; }
        
    IEnumerable<INode<TCoordinate>> GetNodes(IEnumerable<IStrongComponentInfo> componentIds);
        
    IEnumerable<INode<TCoordinate>> GetEdgesWithFilteredEdges(INode<TCoordinate> node, IEnumerable<IStrongComponentInfo> componentIds);

    CountEnumerable<TCoordinate> GetCoordinates(ICollection<IStrongComponentInfo> components);

    IStrongComponentInfo GetNodeComponent(INode<TCoordinate> node);

    IGraph<TCoordinate> AsGraph(IEnumerable<IStrongComponentInfo> components);
  }
}