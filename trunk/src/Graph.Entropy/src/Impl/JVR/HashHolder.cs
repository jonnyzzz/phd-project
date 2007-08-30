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
    private Dictionary<JVRPair<T>, double> myHash = CreateHash();
    private SortedNodeSet<T> mySet = CreateSet();

    const double EPS = 1e-4;
    
    private static Dictionary<JVRPair<T>, double> CreateHash()
    {
      return new Dictionary<JVRPair<T>, double>(EqualityComparerFactory<JVRPair<T>>.GetComparer());
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
        set.AddValue(key.From, -value);
        set.AddValue(key.To, value);
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
      mySet.AddValue(pair.From, -v);
      mySet.AddValue(pair.To, v);
    }

    public double this[JVRPair<T> pair]
    {
      get { return myHash[pair];}
      set
      {
        double t = myHash[pair];
        mySet.AddValue(pair.From, t);
        mySet.AddValue(pair.To, -t);

        myHash[pair] = value;

        mySet.AddValue(pair.From, -value);
        mySet.AddValue(pair.To, value);
      }
    }

    public EntropyEvaluator<T, JVRPair<T>> CreateEvaluator()
    {
      return new EntropyEvaluator<T, JVRPair<T>>(myHash, Norm(), EqualityComparerFactory<T>.GetReferenceComparer());
    }
    
    public T NextNode()
    {
      return mySet.NextNode();
    }
  }
}