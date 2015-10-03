using System.Collections.Generic;

namespace DSIS.SimpleRunner
{
  public class ProjectTheSameMeasureEntropyDraw : DrawEntropyBase
  {    
    protected override IEnumerable<LineData> CreateSeria(IDictionary<int, double[]> results)
    {
      foreach (KeyValuePair<int, double[]> pair in results)
      {
        yield return new LineData(pair.Key.ToString(), pair.Value);
      }
    }
  }
}