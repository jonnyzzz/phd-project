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
  public class DumpGraphMeasureAction2 : IntegerCoordinateSystemActionBase2
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

      string name = folder.CreateFileNameFromTemplate("measure-log2-{0}");

      List<Pair<PairBase<Q>, double>> data = new List<Pair<PairBase<Q>, double>>(measure.Measure);

      data.Sort(delegate(Pair<PairBase<Q>, double> p1, Pair<PairBase<Q>, double> p2)
                  {
                    for (int i = 0; i < system.Dimension; i++)
                    {
                      int v;
                      if ((v = p1.First.From.GetCoordinate(i).CompareTo(p1.First.From.GetCoordinate(i))) != 0)
                        return v;                     
                    } 
                    
                    for (int i = 0; i < system.Dimension; i++)
                    {
                      int v;
                      if ((v = p1.First.To.GetCoordinate(i).CompareTo(p1.First.To.GetCoordinate(i))) != 0)
                        return v;                     
                    } 
                      
                    return 0;
                  });

      using(TextWriter tw = File.CreateText(name))
      {
        tw.WriteLine("Edges: {0}", data.Count);
        tw.WriteLine();
        foreach (Pair<PairBase<Q>, double> pair in data)
        {
          tw.WriteLine("{0}->{1} : {2}", pair.First.From, pair.First.To, pair.Second.ToString("R", CultureInfo.InvariantCulture));
        }
      }
    }

  }
}