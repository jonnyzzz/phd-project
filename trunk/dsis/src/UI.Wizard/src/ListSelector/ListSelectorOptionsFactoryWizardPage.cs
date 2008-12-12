using System;
using System.Collections.Generic;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.UI.Wizard.ListSelector
{
  public class ListSelectorOptionsFactoryWizardPage<Q> : ListSelectorWizardPage<Q>
    where Q : class, IOptionsBasedFactory
  {
    public ListSelectorOptionsFactoryWizardPage(IListSelectorFactory factory, IEnumerable<Q> factories) 
      : base(factory, factories, x=>x.FactoryName)
    {
    }

    public ListSelectorOptionsFactoryWizardPage(IListSelectorFactory factory, IEnumerable<Q> factories, Func<Q, bool> enabled) 
      : base(factory, factories, x=>x.FactoryName, enabled)
    {
    }
  }
}