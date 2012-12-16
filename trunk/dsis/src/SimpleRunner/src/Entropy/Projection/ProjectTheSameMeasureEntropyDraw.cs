using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DSIS.SimpleRunner.Entropy.Draw;

namespace DSIS.SimpleRunner.Entropy.Projection
{
  public class ProjectTheSameMeasureEntropyDraw : DrawEntropyBase
  {    
    protected override IEnumerable<LineData> CreateSeria(IDictionary<int, double[]> results)
    {
      return results.Select(pair => new LineData(pair.Key.ToString(CultureInfo.InvariantCulture), pair.Value));
    }
  }
}