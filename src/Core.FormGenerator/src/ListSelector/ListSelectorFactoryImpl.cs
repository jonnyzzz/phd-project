using System.Collections.Generic;
using System.Linq;
using EugenePetrenko.Core.FormGenerator.Layout;
using EugenePetrenko.Core.FormGenerator.ListSelector;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace EugenePetrenko.Core.FormGenerator.ListSelector
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