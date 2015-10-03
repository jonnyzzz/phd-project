using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public interface IMeasureSlot
  {
    IEnumerable<IMeasureInfo> ForStep(int Step);

    void RegisterResult<Q>(int step, int proj, IGraphMeasure<Q> mes)
      where Q : ICellCoordinate;
  }
}