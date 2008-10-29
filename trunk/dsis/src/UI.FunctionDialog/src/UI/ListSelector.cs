using System.Collections.Generic;

namespace DSIS.UI.FunctionDialog.UI
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

  public class ListSelector<T,Q> : ListSelectorBase<T> 
    where T : class, IListInfo<Q>
    where Q : class
  {
    private readonly Dictionary<Q, T> myValueToObj = new Dictionary<Q, T>();
    public ListSelector(IEnumerable<T> factories) : base(factories)
    {
      foreach (var q in factories)
      {
        var value = q.Value;
        if (value != null)
          myValueToObj[value] = q;
      }
    }

    protected override string FactoryName(T factory)
    {
      return factory.Title;
    }

    protected override string FactoryDescription(T factory)
    {
      return factory.Description;
    }

    protected override bool IsFactoryEnabled(T factory)
    {
      return factory.Enabled;
    }

    public Q SelectedValue
    {
      get
      {
        T factory = SelectedFactory;
        return factory != null ? factory.Value : default(Q);
      }
      set
      {
        T factory;
        if (myValueToObj.TryGetValue(value, out factory))
        {
          SelectedFactory = factory;
        }
      }
    }
  }
}