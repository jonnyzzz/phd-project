using DSIS.Scheme.Ctx;

namespace DSIS.UI.ComputationDialogs.Constraints
{
  public class OneStepConstraint : ISIComputationConstraint
  {
    public bool CanContinue(Context ctx)
    {
      return false;
    }
  }
}