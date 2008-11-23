using DSIS.Core.Ioc;

namespace DSIS.UI.Wizard.FormsGenerator
{
  [ComponentImplementation]
  public class FormGeneratorWizardPageFactoryImpl : IFormGeneratorWizardPageFactory
  {
    private readonly IFieldInfoManager myManager;

    public FormGeneratorWizardPageFactoryImpl(IFieldInfoManager manager)
    {
      myManager = manager;
    }

    public IWizardPage CreatePage(string title, object obj)
    {
      return new FormGeneratorWizardPage(title, obj, myManager);
    }
  }
}