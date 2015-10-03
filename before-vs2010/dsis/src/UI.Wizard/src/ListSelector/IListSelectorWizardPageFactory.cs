using System;
using System.Collections.Generic;

namespace DSIS.UI.Wizard.ListSelector
{
  public interface IListSelectorWizardPageFactory
  {
    IListSelectorWizardPage<Q> Create<Q>(IEnumerable<Q> elements, Func<Q, string> names, Func<Q, bool> enabled)
      where Q : class;

    IListSelectorWizardPage<Q> Create<Q>(IEnumerable<Q> elements, Func<Q, ItemDescr> names, Func<Q, bool> enabled)
      where Q : class;
  }
}