using DSIS.UI.UI;
using DSIS.UI.Wizard.FieldInfos;

namespace DSIS.UI.Wizard.FormsGenerator
{
  public class FormGeneratorWizardPage : WizardPageBase<FormGenerator>
  {
    private readonly IErrorProvider<bool> myErrors;

    public FormGeneratorWizardPage(string title, object model, IFieldInfoManager manager, IOptionPageLayout layout)
    {
      myErrors = model as IErrorProvider<bool>;
      ControlInternal = new FormGenerator(manager, model, layout);
      
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