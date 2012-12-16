using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DSIS.SimpleRunner.Entropy.Draw;

namespace DSIS.SimpleRunner.Entropy.Projection
{
  public class ProjectToTheSameEntropyDraw : DrawEntropyBase
  {
    private static IEnumerable<double> Scan(IDictionary<int, double[]> ds, int idx)
    {
      var result = new List<double>();
      for (int i = idx; ; i++)
      {
        double[] dl;
        if (!ds.TryGetValue(i, out dl))
          break;
        int k = i - idx;
        if (k >= 0 && k < dl.Length)
          result.Add(dl[i - idx]);
        else
          break;
      }
      return result;
    }

    protected override IEnumerable<LineData> CreateSeria(IDictionary<int, double[]> results)
    {
      return results.Keys.Select(bs => new LineData(bs.ToString(CultureInfo.InvariantCulture), Scan(results, bs)));
    }
  }
}