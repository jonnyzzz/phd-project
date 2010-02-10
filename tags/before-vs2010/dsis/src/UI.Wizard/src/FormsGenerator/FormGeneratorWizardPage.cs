using DSIS.UI.UI;
using DSIS.UI.Wizard.FieldInfos;

namespace DSIS.UI.Wizard.FormsGenerator
{
  public class FormGeneratorWizardPage : WizardPageBase<FormGenerator>, ILazyValidate
  {
    private readonly IErrorProvider<bool> myErrors;
    private readonly ILazyValidate myLazy;

    public FormGeneratorWizardPage(string title, object model, IFieldInfoManager manager, IOptionPageLayout layout)
    {
      myErrors = model as IErrorProvider<bool>;
      myLazy = model as ILazyValidate;
      ControlInternal = new FormGenerator(manager, model, layout);
      
      Title = title;
    }

    public override bool Validate()
    {
      if (myErrors != null && !myErrors.Validate())
        return false;

      return base.Validate();
    }

    public bool ValidateLazy()
    {
      return myLazy == null || myLazy.ValidateLazy();
    }
  }
}