using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public interface IMeasureInfo<Q> : IMeasureInfo 
    where Q : ICellCoordinate
  {
    IEnumerable<IGraphMeasure<Q>> Measures2();
  }
}