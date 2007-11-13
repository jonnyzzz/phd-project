using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph.Abstract;

namespace DSIS.Graph
{
  public interface IGraphStrongComponents<TCoordinate>
    where TCoordinate : ICellCoordinate<TCoordinate>
  {
    IEnumerable<IStrongComponentInfo> Components { get; }
    int ComponentCount { get; }

    //todo: Move to CountEnumerable
    IEnumerable<INode<TCoordinate>> GetNodes(ICollection<IStrongComponentInfo> componentIds);

    //todo: Move to CountEnumerable
    IEnumerable<INode<TCoordinate>> GetEdgesWithFilteredEdges(INode<TCoordinate> node, ICollection<IStrongComponentInfo> componentIds);

    CountEnumerable<TCoordinate> GetCoordinates(ICollection<IStrongComponentInfo> components);

    IStrongComponentInfo GetNodeComponent(INode<TCoordinate> node);
  }
}