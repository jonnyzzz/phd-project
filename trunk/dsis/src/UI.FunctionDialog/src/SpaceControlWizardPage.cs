using DSIS.UI.Wizard;

namespace DSIS.UI.FunctionDialog
{
  public class SpaceControlWizardPage : WizardPageBase
  {
    private readonly SpaceModel myModel;

    public SpaceControlWizardPage(SpaceModel model)
    {
      myModel = model;
      Control = new SpaceControl(myModel);
      Title = "Select system space";
    }
  }
}