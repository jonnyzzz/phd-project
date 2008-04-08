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
  public class DumpGraphMeasureAction : IntegerCoordinateSystemActionBase2
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      return ColBase(base.Check<T, Q>(system, ctx),
                     Create(Keys.GraphMeasure<Q>()),
                     Create(FileKeys.WorkingFolderKey));      
    }

    protected sealed override void Apply<T, Q>(T system, Context input, Context output)
    {
      IGraphMeasure<Q> measure = Keys.GraphMeasure<Q>().Get(input);
      WorkingFolderInfo folder = FileKeys.WorkingFolderKey.Get(input);

      string name = folder.CreateFileNameFromTemplate("measure-log-{0}");

      List<Pair<PairBase<Q>, double>> data = new List<Pair<PairBase<Q>, double>>(measure.Measure);
      Dictionary<Q, int> enu = new Dictionary<Q, int>();

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
        foreach (Pair<PairBase<Q>, double> pair in data)
        {
          tw.WriteLine("{0}->{1} : {2}", enu[pair.First.From], enu[pair.First.To], pair.Second.ToString("R", CultureInfo.InvariantCulture));
        }
      }
    }

  }
}