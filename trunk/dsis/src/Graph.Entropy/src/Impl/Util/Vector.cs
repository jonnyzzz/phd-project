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

    public void Add(T key, double value)
    {
      double tmp;
      if (myValues.TryGetValue(key, out tmp))
      {
        value += tmp;        
      }
      myValues[key] = value;
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