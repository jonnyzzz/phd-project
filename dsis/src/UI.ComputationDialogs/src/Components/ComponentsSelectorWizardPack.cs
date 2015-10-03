using System.Collections.Generic;
using DSIS.Graph;
using DSIS.UI.Wizard;

namespace DSIS.UI.ComputationDialogs.Components
{
  [ComponentsComponentImplementation]
  public class ComponentsSelectorWizardPack : SimpleWizard, IWizardPack<ICollection<IStrongComponentInfo>>
  {
    private readonly ComponentsWizardPage myPage;

    public ComponentsSelectorWizardPack(ComponentsWizardPage page) : base(page)
    {
      myPage = page;
      Title = "Select Symbolic Image Components";
    }

    public void Dispose()
    {      
    }

    public IWizardPack Controller
    {
      get { return this; }
    }

    public ICollection<IStrongComponentInfo> GetResult()
    {
      return myPage.GetSelectedComponents();
    }
  }
}