using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.JVR
{
  public class HashHolder<T> 
    where T : ICellCoordinate<T>
  {
    const double EPS = 1e-4;
    private static readonly IEqualityComparer<JVRPair<T>> COMPARER = EqualityComparerFactory<JVRPair<T>>.GetComparer();

    private Dictionary<JVRPair<T>, double> myHash = CreateHash();
    private SortedNodeSet<T> mySet = CreateSet();    
    
    private static Dictionary<JVRPair<T>, double> CreateHash()
    {
      return new Dictionary<JVRPair<T>, double>(COMPARER);
    }
    
    private static SortedNodeSet<T> CreateSet()
    {
      return new SortedNodeSet<T>();
    }

    private void Divide(double div)
    {
      Dictionary<JVRPair<T>, double> ret = CreateHash();
      SortedNodeSet<T> set = CreateSet();
      foreach (KeyValuePair<JVRPair<T>, double> pair in myHash)
      {
        double value = pair.Value / div;
        JVRPair<T> key = pair.Key;
        ret.Add(key, value);
        set.Add(key, value);
      }
      myHash = ret;
      mySet = set;
    }

    private double Norm()
    {
      double v = 0;
      foreach (double d in myHash.Values)
      {
        v += d;
      }
      return v;
    }

    public void Normalize()
    {
      double myNorm = Norm();
      
      if (Math.Abs(myNorm - 1.0) < EPS)
        return;

      Divide(myNorm);
    }

    public void Add(JVRPair<T> pair, double v)
    {
      myHash.Add(pair, v);
      mySet.Add(pair, v);
    }

    public void SetItem(JVRPair<T> pair, double value)
    {
      double t = myHash[pair];
      myHash[pair] = value;
      mySet.Add(pair, value - t);
    }

    public double GetItem(JVRPair<T> pair)
    {
      return myHash[pair];
    }

    public EntropyEvaluator<T, JVRPair<T>> CreateEvaluator()
    {
      return new EntropyEvaluator<T, JVRPair<T>>(myHash, Norm(), EqualityComparerFactory<T>.GetComparer());
    }
    
    public T NextNode()
    {
      return mySet.NextNode();
    }
  }
}