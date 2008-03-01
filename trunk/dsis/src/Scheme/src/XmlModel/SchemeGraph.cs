using System.Collections.Generic;

namespace DSIS.Scheme.XmlModel
{
  public class SchemeArc<T>
  {
    public readonly IConnectionPoint<T> From;
    public readonly List<IConnectionPoint<T>> To;

    public SchemeArc(IConnectionPoint<T> from)
    {
      From = from;
      From.OnDataReady += DataReady;
    }

    private void DataReady(T data)
    {
      foreach (IConnectionPoint<T> point in To)
      {
        
      }
    }

    public void AddTo(IConnectionPoint<T> pt)
    {
      To.Add(pt);
    }
  }

  public class SchemeGraph
  {
    private SchemeNodeFactory myFactory;

    
  }
}