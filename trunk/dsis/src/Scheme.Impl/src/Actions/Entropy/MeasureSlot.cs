using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class MeasureSlot<Q> where Q : ICellCoordinate
  {
    private readonly List<MeasureInfo<Q>> myMeasures = new List<MeasureInfo<Q>>();

    public static MeasureSlot<Q> Get(string key, Context ctx)
    {
      if (ctx.ContainsKey(Key(key)))
      {
        return ctx.Get(Key(key));
      } else
      {
        var ms = new MeasureSlot<Q>();
        ctx.Set(Key(key), ms);
        return ms;
      }
    }

    private static Key<MeasureSlot<Q>> Key(string key)
    {
      return new Key<MeasureSlot<Q>>(key);
    }

    public IEnumerable<MeasureInfo<Q>> ForStep(int Step)
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


    public MeasureInfo<Q> Get(int step, int proj)
    {
      foreach (var info in myMeasures)
      {
        if (info.Step == step && info.Proj == proj)
          return info;
      }
      return null;
    }

    public void RegisterResult(int step, int proj, IGraphMeasure<Q> mes)
    {
      MeasureInfo<Q> info = Get(step, proj);
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