using System;
using System.Collections.Generic;
using DSIS.Core.Ioc;
using DSIS.UI.Controls;

namespace DSIS.UI.Wizard.ListSelector
{
  [ComponentImplementation]
  public class ListSelectorWizardPageFactory : IListSelectorWizardPageFactory
  {
    [Autowire]
    private IListSelectorFactory Factory { get; set; }

    [Autowire]
    private IDockLayout DockLayout { get; set; }

    public IListSelectorWizardPage<Q> Create<Q>(IEnumerable<Q> elements, Func<Q, string> names, Func<Q, bool> enabled) where Q : class
    {
      return new ListSelectorWizardPage<Q>(Factory, elements, names, enabled);
    }

    public IListSelectorWizardPage<Q> Create<Q>(IEnumerable<Q> elements, Func<Q, ItemDescr> names, Func<Q, bool> enabled) where Q : class
    {
      return new ListSelectorWizardPage<Q>(Factory, elements, names, enabled);
    }
  }
}