using System;
using System.Collections.Generic;
using DSIS.UI.Wizard;
using DSIS.UI.Wizard.ListSelector;
using DSIS.Utils;

namespace DSIS.UI.FunctionDialog
{
  [SystemFunctionComponent]
  public class SelectSystemInfoProviderWizard : SimpleWizard, IWizardPack<ISystemInfoFactoryProvider>
  {
    private readonly IListSelectorWizardPage<ISystemInfoFactoryProvider> myPage;

    [Used]
    public SelectSystemInfoProviderWizard(IListSelectorWizardPageFactory factory, IEnumerable<ISystemInfoFactoryProvider> provs) : this(factory.Create(provs, x=>new ItemDescr(x.Name, x.Description), x=>x.Enabled))
    {
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
  }
}