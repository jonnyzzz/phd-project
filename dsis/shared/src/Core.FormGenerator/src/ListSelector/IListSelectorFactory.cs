using System.Collections.Generic;
using EugenePetrenko.Core.FormGenerator.ListSelector;

namespace EugenePetrenko.Core.FormGenerator.ListSelector
{
  public interface IListSelectorFactory
  {
    ListSelector<T, Q> Create<T, Q>(IEnumerable<T> elements)
      where T : class, IListInfo<Q>
      where Q : class;
  }
}