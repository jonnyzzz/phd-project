using System.Collections.Generic;

namespace DSIS.UI.Wizard.ListSelector
{
  public interface IListSelectorFactory
  {
    ListSelector<T, Q> Create<T, Q>(IEnumerable<T> elements)
      where T : class, IListInfo<Q>
      where Q : class;
  }
}