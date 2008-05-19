using DSIS.UI.Wizard;

namespace DSIS.UI.FunctionDialog
{
  public class SystemFunctionSelectionWizard : SimpleWizard
  {
    public SystemFunctionSelectionWizard() : base(new[]{new SpaceControlWizardPage(new SpaceModel())})
    {
      Title = "System Function";
    }
  }
}