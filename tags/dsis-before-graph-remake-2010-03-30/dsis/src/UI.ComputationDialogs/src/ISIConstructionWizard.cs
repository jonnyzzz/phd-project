using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
using DSIS.Scheme.Ctx;

namespace DSIS.UI.ComputationDialogs
{
  public interface ISIComputationConstraint
  {
    bool CanContinue(Context ctx);
  }

  public interface ICellImageBuilderWizardResult
  {
    ICellImageBuilderSettings Setting { get;}
    long[] Subdivision { get;}

    /// <summary>
    /// Called starting from first application of parameters to 
    /// get next portion of parameters or null to finish
    /// </summary>
    /// <param name="ctx"></param>
    /// <returns></returns>
    ICellImageBuilderWizardResult Next(Context ctx);
  }

  public interface ISIConstructionWizard
  {
    ICellImageBuilderWizardResult ShowWizard(ICellCoordinateSystem system);
  }
}