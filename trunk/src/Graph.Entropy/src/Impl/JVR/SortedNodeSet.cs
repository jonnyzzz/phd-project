using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.JVR
{
  public class SortedNodeSet<T> where T : ICellCoordinate<T>
  {
    private static readonly IEqualityComparer<T> COMPARER = EqualityComparerFactory<T>.GetComparer();

    private readonly Dictionary<T, double> myValues = new Dictionary<T, double>(COMPARER);

    private void AddValue(T node, double value)
    {
      double v;
      if (myValues.TryGetValue(node, out v))
        value += v;

      myValues[node] = value;      
    }

    public void Add(JVRPair<T> pair, double v)
    {
      AddValue(pair.From, -v);
      AddValue(pair.To, v);
    }

    public T NextNode()
    {
      T max = default(T);
      double? v = null;
      foreach (KeyValuePair<T, double> pair in myValues)
      {
        double q = Math.Abs(pair.Value);
        if (v == null || v.Value < q)
        {
          max = pair.Key;
          v = q;
        }
      }
      return max;
    }
  }
}