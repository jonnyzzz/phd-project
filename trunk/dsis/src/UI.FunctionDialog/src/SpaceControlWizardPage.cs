using DSIS.UI.Wizard;

namespace DSIS.UI.FunctionDialog
{
  public class SpaceControlWizardPage : WizardPageBase<SpaceControl>
  {
    private readonly SpaceModel myModel;

    public SpaceControlWizardPage(SpaceModel model)
    {
      myModel = model;
      ControlInternal = new SpaceControl(myModel);
      Title = "Select system space";
    }
  }
}