using System;
using System.Collections.Generic;
using DSIS.Utils;

namespace DSIS.UI.Wizard.ListSelector
{
  public class ListSelectorWizardPage<Q> : 
    WizardPageBase<ListSelector<ListInfo<Q>, Q>>, IListSelectorWizardPage<Q>
    where Q : class
  {

    public ListSelectorWizardPage(IListSelectorFactory factory, IEnumerable<Q> factories, Func<Q, string> names) :
      this(factory, factories, names, x=>true)
    {
    }

    public ListSelectorWizardPage(IListSelectorFactory factory, IEnumerable<Q> factories, Func<Q, string> names, Func<Q, bool> enabled) : this(factory, factories, x=>new ItemDescr(names(x)), enabled)
    {
    }

    public ListSelectorWizardPage(IListSelectorFactory factory, IEnumerable<Q> factories, Func<Q, ItemDescr> names, Func<Q, bool> enabled)
    {
      ControlInternal = factory.Create<ListInfo<Q>, Q>(
        factories.Map(
          x => ListInfo.Create(
                 names(x),
                 enabled(x),
                 x)));
      Title = "Select Cell Image building method";
    }

    public Q SelectedItem
    {
      get { return ControlInternal.SelectedValue; }
      set { ControlInternal.SelectedValue = value; }
    }

    public override bool Validate()
    {
      return SelectedItem != null;
    }
  }
}