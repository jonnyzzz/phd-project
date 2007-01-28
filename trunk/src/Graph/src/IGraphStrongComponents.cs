using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;

namespace DSIS.Graph
{
  public interface IGraphStrongComponents<TCoordinate> 
    where TCoordinate : ICellCoordinate<TCoordinate>
  {
    IEnumerable<IStrongComponentInfo> Components { get;}
    int ComponentCount { get; }

    IEnumerable<INode<TCoordinate>> GetNodes(IEnumerable<IStrongComponentInfo> componentIds);
    IEnumerable<INode<TCoordinate>> GetEdgesWithFilteredEdges(INode<TCoordinate> node, IEnumerable<IStrongComponentInfo> componentIds);

    IEnumerable<TCoordinate> GetCoordinates(IEnumerable<IStrongComponentInfo> components);
  }
}