using DSIS.UI.Wizard.FieldInfos;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.UI.Wizard.FormsGenerator
{
  [ComponentImplementation]
  public class FormGeneratorWizardPageFactoryImpl : IFormGeneratorWizardPageFactory
  {
    private readonly IFieldInfoManager myManager;
    private readonly IOptionPageLayout myLayout;

    public FormGeneratorWizardPageFactoryImpl(IFieldInfoManager manager, IOptionPageLayout layout)
    {
      myManager = manager;
      myLayout = layout;
    }

    public IWizardPage CreatePage(string title, object obj)
    {
      return new FormGeneratorWizardPage(title, obj, myManager, myLayout);
    }
  }
}