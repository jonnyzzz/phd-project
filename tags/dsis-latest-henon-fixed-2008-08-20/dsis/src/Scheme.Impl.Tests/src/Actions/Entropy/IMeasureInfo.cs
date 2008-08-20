using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public interface IMeasureInfo
  {
    int Proj { get; }
    int Step { get; }

    IEnumerable<IGraphMeasure> Measures();

    double Dist(IMeasureInfo info);

    void Join<T>(IGraphMeasure<T> mes) where T : ICellCoordinate;

    void DoGeneric(IMeasureInfoWith with);
  }

  public interface IMeasureInfoWith
  {
    void With<Q>(IMeasureInfo<Q> info) where Q : ICellCoordinate;
  }
}