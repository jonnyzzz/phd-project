using System.Collections.Generic;

namespace DSIS.UI.Wizard.ListSelector
{
  public static class ListSelector
  {
    public static ListSelector<T,Q> Create<T,Q>(IEnumerable<T> enu)
      where T : class, IListInfo<Q>
      where Q : class
    {
      return new ListSelector<T, Q>(enu);
    }

    public static ListSelector<ListInfo<Q>,Q> Create<Q>(IEnumerable<ListInfo<Q>> qs)
      where Q : class
    {
      return Create<ListInfo<Q>,Q>(qs);    
    }
  }
}