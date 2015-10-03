using System.Collections.Generic;
using System.Linq;
using EugenePetrenko.Shared.Core.Ioc.Api;
using DSIS.UI.Controls;

namespace DSIS.UI.Wizard.ListSelector
{
  [ComponentImplementation]
  public class ListSelectorFactoryImpl : IListSelectorFactory
  {
    private readonly IDockLayout myLayout;

    public ListSelectorFactoryImpl(IDockLayout layout)
    {
      myLayout = layout;
    }

    public ListSelector<T, Q> Create<T, Q>(IEnumerable<T> elements)
      where T : class, IListInfo<Q>
      where Q : class 
    {
      return new ListSelector<T, Q>(elements.ToArray(), myLayout);
    }
  }
}