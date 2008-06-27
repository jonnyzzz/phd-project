using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class MeasureSlot
  {
    private readonly List<IMeasureInfo> myMeasures = new List<IMeasureInfo>();

    public static MeasureSlot Get(string key, Context ctx)
    {
      if (ctx.ContainsKey(Key(key)))
      {
        return ctx.Get(Key(key));
      } else
      {
        var ms = new MeasureSlot();
        ctx.Set(Key(key), ms);
        return ms;
      }
    }

    private static Key<MeasureSlot> Key(string key)
    {
      return new Key<MeasureSlot>(key);
    }

    public IEnumerable<IMeasureInfo> ForStep(int Step)
    {
      int proj = 0;
      int step = Step;
      while(true)
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


    private IMeasureInfo Get(int step, int proj)
    {
      foreach (var info in myMeasures)
      {
        if (info.Step == step && info.Proj == proj)
          return info;
      }
      return null;
    }

    public void RegisterResult<Q>(int step, int proj, IGraphMeasure<Q> mes)
      where Q : ICellCoordinate
    {
      var info = Get(step, proj);
      if (info == null)
      {
        myMeasures.Add(new MeasureInfo<Q>(step, proj, mes));
      } else
      {
        info.Join(mes);
      }
    }
  }
}