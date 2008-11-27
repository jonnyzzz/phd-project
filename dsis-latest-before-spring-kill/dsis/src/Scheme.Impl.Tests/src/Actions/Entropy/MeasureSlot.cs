using System.Collections.Generic;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class MeasureSlot : MeasureSlotBase
  {
    private readonly List<IMeasureInfo> myMeasures = new List<IMeasureInfo>();

    protected override void Add(IMeasureInfo mes)
    {
      myMeasures.Add(mes);
    }

    protected override IMeasureInfo Get(int step, int proj)
    {
      foreach (var info in myMeasures)
      {
        if (info.Step == step && info.Proj == proj)
          return info;
      }
      return null;
    }
  }
}