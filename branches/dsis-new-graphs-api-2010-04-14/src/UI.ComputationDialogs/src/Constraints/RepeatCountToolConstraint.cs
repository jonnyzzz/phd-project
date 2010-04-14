using DSIS.Scheme.Ctx;

namespace DSIS.UI.ComputationDialogs.Constraints
{
  public class RepeatCountToolConstraint : ISIComputationConstraint
  {
    private readonly long myCount;
    private long myValue;

    public RepeatCountToolConstraint(long count)
    {
      myCount = count;
    }

    public bool CanContinue(Context ctx)
    {
      return ++myValue < myCount;
    }
  }
}