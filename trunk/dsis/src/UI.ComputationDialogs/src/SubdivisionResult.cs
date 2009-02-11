using System.Collections.Generic;
using System.Linq;

namespace DSIS.UI.ComputationDialogs
{
  public class SubdivisionResult
  {
    public long[] Subdivision { get; private set; }
    public bool UseUnsimmetric { get; private set; }

    public ICollection<ISIComputationConstraint> Constraints { get; private set; }

    public SubdivisionResult(long[] subdivision, bool useUnsimmetric, IEnumerable<ISIComputationConstraint> constraints)
    {
      Subdivision = subdivision;
      UseUnsimmetric = useUnsimmetric;
      Constraints = constraints.ToArray();
    }
  }
}