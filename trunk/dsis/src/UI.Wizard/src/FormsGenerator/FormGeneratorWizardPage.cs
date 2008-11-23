using DSIS.UI.UI;

namespace DSIS.UI.Wizard.FormsGenerator
{
  public class FormGeneratorWizardPage : WizardPageBase<FormGenerator>
  {
    private readonly IErrorProvider<bool> myErrors;
    
    public FormGeneratorWizardPage(string title, object model, IFieldInfoManager manager)
    {
      myErrors = model as IErrorProvider<bool>;
      ControlInternal = new FormGenerator(manager, model);
      
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