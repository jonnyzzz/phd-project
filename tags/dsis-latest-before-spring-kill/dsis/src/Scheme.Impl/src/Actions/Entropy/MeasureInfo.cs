using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class MeasureInfo<Q> : MeasureInfoBase<Q>
    where Q : ICellCoordinate
  {
    private readonly List<IGraphMeasure<Q>> myMeasures;

    public override IEnumerable<IGraphMeasure<Q>> Measures2()
    {
      return myMeasures; 
    }

    public MeasureInfo(int step, int proj, IGraphMeasure<Q> measure) : base(step, proj)
    {
      myMeasures = new List<IGraphMeasure<Q>> {measure};
    }

    protected override void JoinInternal(IGraphMeasure<Q> mes)
    {
      myMeasures.Add(mes);
    }
  }
}