using System.Collections.Generic;

namespace DSIS.SimpleRunner
{
  public class ProjectToTheSameEntropyDraw : DrawEntropyBase
  {
    private static List<double> Scan(IDictionary<int, double[]> ds, int idx)
    {
      List<double> result = new List<double>();
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
      foreach (int bs in results.Keys)
      {
        yield return new LineData(bs.ToString(), Scan(results, bs));
      }
    }
  }
}