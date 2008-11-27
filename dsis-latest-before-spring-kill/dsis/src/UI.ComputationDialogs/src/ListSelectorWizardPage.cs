using System;
using System.Collections.Generic;
using DSIS.UI.Wizard;
using DSIS.UI.Wizard.ListSelector;
using DSIS.Utils;

namespace DSIS.UI.ComputationDialogs
{
  public class ListSelectorWizardPage<Q> : 
    WizardPageBase<ListSelector<ListInfo<Q>, Q>>
    where Q : class
  {
    public ListSelectorWizardPage(IListSelectorFactory factory, IEnumerable<Q> factories, Func<Q, string> names)
    {
      ControlInternal = factory.Create<ListInfo<Q>, Q>(
        factories.Map(
          x => ListInfo.Create(
                 names(x),
                 "",
                 true,
                 x)));
      Title = "Select Cell Image building method";
    }

    public Q SelectedItem
    {
      get { return ControlInternal.SelectedValue; }
    }

    public override bool Validate()
    {
      return SelectedItem != null;
    }
  }
}