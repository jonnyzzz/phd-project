using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
using DSIS.Scheme.Ctx;

namespace DSIS.UI.ComputationDialogs
{
  public interface IComputationConstraint
  {
    bool CanContinue(Context ctx);
  }

  public interface ICellImageBuilderWizardResult
  {
    ICellImageBuilderSettings Setting { get;}
    long[] Subdivision { get;}

    ICellImageBuilderWizardResult Next(Context ctx);
  }

  public interface ISIConstructionWizard
  {
    ICellImageBuilderWizardResult ShowWizard(ICellCoordinateSystem system);
  }
}