using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class BiggestMeasureInfo<Q> : MeasureInfoBase<Q>
    where Q : ICellCoordinate
  {
    private IGraphMeasure<Q> myMeasure;

    public BiggestMeasureInfo(int proj, int step, IGraphMeasure<Q> mes) : base(proj, step)
    {
      myMeasure = mes;
    }

    public override IEnumerable<IGraphMeasure<Q>> Measures2()
    {
      yield return myMeasure;
    }

    protected override void JoinInternal(IGraphMeasure<Q> mes)
    {
      if (myMeasure.GetEntropy() < mes.GetEntropy())
      {
        myMeasure = mes;
      }
    }
  }
}