using System.Collections.Generic;
using DSIS.Core.Ioc;

namespace DSIS.UI.Wizard.ListSelector
{
  [ComponentImplementation]
  public class ListSelectorFactoryImpl : IListSelectorFactory
  {
    public ListSelector<T, Q> Create<T, Q>(IEnumerable<T> elements)
      where T : class, IListInfo<Q>
      where Q : class 
    {
      return new ListSelector<T, Q>(elements);
    }
  }
}