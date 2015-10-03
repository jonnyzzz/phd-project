using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph
{
  public interface IGraphStrongComponentSubsetFactory
  {
    IGraphStrongComponents SubComponents(IGraphStrongComponents components, IEnumerable<IStrongComponentInfo> subSet);

    IGraphStrongComponents<Q> SubComponents<Q>(IGraphStrongComponents<Q> components,
                                               IEnumerable<IStrongComponentInfo> subSet)
      where Q : ICellCoordinate;
  }
}