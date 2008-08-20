using System.Collections.Generic;
using System.Globalization;
using System.IO;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Console
{
  public class DumpGraphMeasureAction : IntegerCoordinateSystemActionBase3
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(Context ctx)
    {
      return ColBase(base.Check<T, Q>(ctx),
                     Create(Keys.GraphMeasure<Q>()),
                     Create(FileKeys.WorkingFolderKey));      
    }

    protected sealed override void Apply<T, Q>(Context input, Context output)
    {
      var measure = Keys.GraphMeasure<Q>().Get(input);
      var folder = FileKeys.WorkingFolderKey.Get(input);

      string name = folder.CreateFileNameFromTemplate("measure-log-{0}");

      var data = new List<Pair<PairBase<Q>, double>>(measure.Measure);
      var enu = new Dictionary<Q, int>();

      int cnt = 0;
      foreach (Pair<PairBase<Q>, double> pair in data)
      {
        PairBase<Q> q = pair.First;
        int tmp;
        if (!enu.TryGetValue(q.From, out tmp)) enu[q.From] = ++cnt;
        if (!enu.TryGetValue(q.To, out tmp)) enu[q.To] = ++cnt;
      }

      data.Sort(delegate(Pair<PairBase<Q>, double> p1, Pair<PairBase<Q>, double> p2)
                  {
                    if (enu[p1.First.From] < enu[p2.First.From])
                      return -1;
                    if (enu[p1.First.From] > enu[p2.First.From])
                      return 1;
                    if (enu[p1.First.To] < enu[p2.First.To])
                      return -1;
                    if (enu[p1.First.To] > enu[p2.First.To])
                      return 1;

                    return 0;
                  });

      using(TextWriter tw = File.CreateText(name))
      {
        tw.WriteLine("Edges: {0}, Nodes: {1}", data.Count, enu.Count);
        tw.WriteLine();
        foreach (var pair in data)
        {
          tw.WriteLine("{0}->{1} : {2}", enu[pair.First.From], enu[pair.First.To], pair.Second.ToString("R", CultureInfo.InvariantCulture));
        }
      }
    }

  }
}