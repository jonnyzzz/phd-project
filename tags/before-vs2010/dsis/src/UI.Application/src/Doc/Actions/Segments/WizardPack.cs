using DSIS.Core.Ioc;
using DSIS.UI.Wizard;
using DSIS.UI.Wizard.FormsGenerator;

namespace DSIS.UI.Application.Doc.Actions.Segments
{
  [TypeInstanciable]
  public class WizardPack<T> : IWizardPack<T> where T: class, new()
  {
    private readonly IWizardPage myPage;
    private readonly SimpleWizard myWizard;
    private readonly T myOptions = new T();

    public WizardPack(IFormGeneratorWizardPageFactory factory)
    {
      myPage = factory.CreatePage("Next segment iteration", myOptions);
      myWizard = new SimpleWizard(myPage);
    }
    public void Dispose()
    {
    }

    public IWizardPack Controller
    {
      get { return myWizard; }
    }

    public T GetResult()
    {
      return myOptions;
    }
  }
}