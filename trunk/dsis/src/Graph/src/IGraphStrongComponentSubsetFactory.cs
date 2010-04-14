using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph
{
  public interface IGraphStrongComponentSubsetFactory
  {
    IReadonlyGraphStrongComponents SubComponents(IReadonlyGraphStrongComponents components,
                                                 IEnumerable<IStrongComponentInfo> subSet);

    IReadonlyGraphStrongComponents<Q> SubComponents<Q>(IReadonlyGraphStrongComponents<Q> components,
                                                       IEnumerable<IStrongComponentInfo> subSet)
      where Q : ICellCoordinate;


    IReadonlyGraphStrongComponents<Q, T> SubComponents<Q, T>(IReadonlyGraphStrongComponents<Q, T> components,
                                                             IEnumerable<IStrongComponentInfo> subSet)
      where Q : ICellCoordinate
      where T : class, INode<Q>;
  }
}