using System.Collections.Generic;
using DSIS.Scheme.Objects.Systemx;
using DSIS.UI.Wizard.ListSelector;

namespace DSIS.UI.ComputationDialogs
{
  public class ListSelectorOptionsFactoryWizardPage<Q> : ListSelectorWizardPage<Q>
    where Q : class, IOptionsBasedFactory
  {
    public ListSelectorOptionsFactoryWizardPage(IListSelectorFactory factory, IEnumerable<Q> factories) 
      : base(factory, factories, x=>x.FactoryName)
    {
    }
  }
}