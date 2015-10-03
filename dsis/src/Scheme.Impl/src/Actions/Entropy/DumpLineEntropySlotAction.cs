using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class DumpLineEntropySlotAction : ActionBase
  {
    private readonly string myKey;

    public DumpLineEntropySlotAction(string key)
    {
      myKey = key;
    }

    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return EmptyArray<ContextMissmatch>.Instance;
    }

    protected override void Apply(Context ctx, Context result)
    {
      var logger = Logger.Instance(ctx);
      var slot = CurveLengthSlotHelper.Get(myKey, SlotStore.Get(ctx));

      logger.Write("Dump all results:");

      slot.EnumerateData((id, c, l) => logger.Write(string.Format("{2}\t{0},\t{1:G}", c, l, id)));

      var dc = new Dictionary<long, Pair<long, double>>();
      slot.EnumerateData((id, c, l) => dc.Add(id, Pair.Of(c, l)));

      var keys = new List<long>(dc.Keys);
      keys.Sort();


      Func<long, long, double> fln = (n, k) => Math.Log(dc[n + k].Second/dc[n].Second)/k;
      Action sep = () =>
                     {
                       logger.Write("");
                       logger.Write("----------------");
                       logger.Write("");
                     };

      sep();

      foreach (var _key in keys)
      {
        var key = _key;

        sep();

        logger.Write(string.Format("Base on Step={0}, Count={1}, Length={2}", key, dc[key].First, dc[key].Second));
        logger.Write("");

        foreach (var c in keys.Where(v=>v >= key))
        {
          var v = dc[c];
          logger.Write(string.Format("Step={0},\tCount={1},\tLength={2:G},\tLn2={3:G}", c, v.First, v.Second, fln(key, c-key)));
        }
      }

      sep();

      logger.Write("Topmost f(n,n_{max} - n):= 1/k ln_2 (l_{n+k}/l_{n})");
      var maxKey = keys.Max();
      foreach (var key in keys)
      {
        var fmt = string.Format("n={0},\tk={1},\tv={2}", key, maxKey-key, fln(key, maxKey-key));
        logger.Write(fmt);
      }
    }
  }
}