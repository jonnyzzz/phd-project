using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Entropy.Impl.JVR
{
  public class SortedNodeSet<T> where T : ICellCoordinate<T>
  {
    private readonly Dictionary<T, double> myValues = new Dictionary<T, double>();

    public void AddValue(T node, double value)
    {
      double v;
      myValues.TryGetValue(node, out v);
      myValues[node] = v + value;      
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