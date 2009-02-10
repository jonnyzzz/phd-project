using System.Collections.Generic;
using System.Linq;
using DSIS.Core.Ioc;
using DSIS.UI.Wizard;
using DSIS.UI.Wizard.ListSelector;
using DSIS.Utils;

namespace DSIS.UI.FunctionDialog
{
  [TypeInstanciable]
  public class SelectSystemInfoProviderWizard : SimpleWizard, IWizardPack<ISystemInfoFactoryProvider>
  {
    private readonly IListSelectorWizardPage<ISystemInfoFactoryProvider> myPage;

    [Used]
    public SelectSystemInfoProviderWizard(IListSelectorWizardPageFactory factory, IEnumerable<ISystemInfoFactoryProvider> provs) 
      : this(factory.Create(provs, x=>new ItemDescr(x.Name, x.Description), x=>x.Enabled))
    {
      Title = "Select Type of the System";      
      myPage.SelectedItem = provs.Where(x => x.Enabled).FirstOrDefault();
    }

    private SelectSystemInfoProviderWizard(IListSelectorWizardPage<ISystemInfoFactoryProvider> page) : base(new[] {page})
    {
      myPage = page;
    }

    public IWizardPack Controller
    {
      get { return this; }
    }

    public ISystemInfoFactoryProvider GetResult()
    {
      return myPage.SelectedItem;
    }

    public void Dispose()
    {
      //TODO:
    }
  }
}