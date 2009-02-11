using System.Collections.Generic;

namespace DSIS.UI.ComputationDialogs
{
  public class SubdivisionResult
  {
    public long[] Subdivision { get; private set; }
    public bool UseUnsimmetric { get; private set; }

    public ICollection<IComputationConstraint> Constraints { get; private set; }

    public SubdivisionResult(long[] subdivision, bool useUnsimmetric, ICollection<IComputationConstraint> constraints)
    {
      Subdivision = subdivision;
      UseUnsimmetric = useUnsimmetric;
      Constraints = constraints;
    }
  }
}