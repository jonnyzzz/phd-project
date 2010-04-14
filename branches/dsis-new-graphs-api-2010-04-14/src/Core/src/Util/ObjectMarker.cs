using System.Collections.Generic;
using DSIS.Utils;

namespace DSIS.Core.Util
{
  public class ObjectMarker<T>
  {
    private readonly Dictionary<T, int> myObjects = new Dictionary<T, int>(EqualityComparerFactory<T>.GetComparer());
    private int myCount = 0;

    public string Id(T t)
    {
      int v;
      if (myObjects.TryGetValue(t, out v))
        return v.ToString();

      v = ++myCount;
      myObjects[t] = v;

      return v.ToString();
    }
  }
}

