using System.Collections.Generic;
using System.Globalization;
using System.IO;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Console
{
  public class DumpGraphMeasureAction2 : IntegerCoordinateSystemActionBase3
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

      string name = folder.CreateFileNameFromTemplate("measure-log2-{0}");

      var data = new List<Pair<PairBase<Q>, double>>(measure.Measure);

      data.Sort(delegate(Pair<PairBase<Q>, double> p1, Pair<PairBase<Q>, double> p2)
                  {
                    for (var i = 0; i < Dimension; i++)
                    {
                      int v;
                      if ((v = p1.First.From.GetCoordinate(i).CompareTo(p2.First.From.GetCoordinate(i))) != 0)
                        return v;                     
                    } 
                    
                    for (var i = 0; i < Dimension; i++)
                    {
                      int v;
                      if ((v = p1.First.To.GetCoordinate(i).CompareTo(p2.First.To.GetCoordinate(i))) != 0)
                        return v;                     
                    } 
                      
                    return 0;
                  });

      using(TextWriter tw = File.CreateText(name))
      {
        tw.WriteLine("Edges: {0}", data.Count);
        tw.WriteLine();
        foreach (var pair in data)
        {
          tw.WriteLine("{0}->{1} : {2}", pair.First.From, pair.First.To, pair.Second.ToString("R", CultureInfo.InvariantCulture));
        }
      }
    }
  }
}