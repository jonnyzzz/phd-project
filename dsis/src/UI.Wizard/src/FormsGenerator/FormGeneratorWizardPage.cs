using DSIS.UI.UI;

namespace DSIS.UI.Wizard.FormsGenerator
{
  public class FormGeneratorWizardPage : WizardPageBase<FormGenerator>
  {
    private readonly IErrorProvider<bool> myErrors;
    
    public FormGeneratorWizardPage(string title, object model)
    {
      myErrors = model as IErrorProvider<bool>;
      ControlInternal = new FormGenerator(model);
      
      Title = title;
    }

    public override bool Validate()
    {
      if (myErrors != null && !myErrors.Validate())
        return false;

      return base.Validate();
    }
  }
}