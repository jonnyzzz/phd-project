using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public abstract class MeasureSlotBase : IMeasureSlot
  {
    public IEnumerable<IMeasureInfo> ForStep(int Step)
    {
      int proj = 0;
      int step = Step;
      while (true)
      {
        var info = Get(step, proj);
        if (info == null)
        {
          yield break;
        }
        yield return info;

        proj++;
        step++;
      }
    }

    public void RegisterResult<Q>(int step, int proj, IGraphMeasure<Q> mes)
      where Q : ICellCoordinate
    {
      var info = Get(step, proj);
      if (info == null)
      {
        Add(new MeasureInfo<Q>(step, proj, mes));
      }
      else
      {
        info.Join(mes);
      }
    }

    protected abstract void Add(IMeasureInfo mes);

    protected abstract IMeasureInfo Get(int step, int proj);
  }
}