using System.Collections.Generic;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Util
{
  public class Vector<T>
  {
    protected readonly Dictionary<T, double> myValues;

    public Vector() : this(new Dictionary<T, double>(EqualityComparerFactory<T>.GetComparer()))
    {      
    }

    public Vector(Dictionary<T, double> values)
    {
      myValues = values;
    }

    public double Add(T key, double value)
    {
      double tmp;
      if (myValues.TryGetValue(key, out tmp))
      {
        value += tmp;        
      }
      return myValues[key] = value;
    }
    
    public double Div(T key, double value)
    {
      double tmp;
      if (myValues.TryGetValue(key, out tmp))
      {
        value /= tmp;
        return myValues[key] = value;
      }
      return 0;
    }

    public double this[T data]
    {
      get
      {
        double tmp;
        return myValues.TryGetValue(data, out tmp) ? tmp : 0;
      }
      set
      {
        myValues[data] = value;
      }
    }

    public int Count
    {
      get { return myValues.Count; }
    }

    public Dictionary<T, double> Dictionary
    {
      get { return myValues; }
    }
  }
}