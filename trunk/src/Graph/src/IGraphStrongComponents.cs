using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;

namespace DSIS.Graph
{
  public interface IGraphStrongComponents<TCoordinate, TValue> where TCoordinate : ICellCoordinate<TCoordinate>
  {
    IEnumerable<IStrongComponentInfo> Components { get;}
    int ComponentCount { get; }

    IEnumerable<INode<TCoordinate, TValue>> GetNodes(IEnumerable<IStrongComponentInfo> componentIds);
    IEnumerable<INode<TCoordinate, TValue>> GetEdgesWithFilteredEdges(INode<TCoordinate, TValue> node, IEnumerable<IStrongComponentInfo> componentIds);

    IEnumerable<TCoordinate> GetCoordinates(IEnumerable<IStrongComponentInfo> components);
  }
}