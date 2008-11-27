using DSIS.Scheme;
using DSIS.Scheme.Ctx;

namespace DSIS.UI.ComputationDialogs.Measure
{
  public interface IComputeInvariantMeasureMethodSelector
  {
    bool IsApplicable(Context ctx);

    IAction ShowWizard();
  }
}