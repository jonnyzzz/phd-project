using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.JVR
{
  public class HashHolder<T> 
    where T : ICellCoordinate<T>
  {
    private Dictionary<JVRPair<T>, double> myHash = CreateHash();
    const double EPS = 1e-4;
    
    private static Dictionary<JVRPair<T>, double> CreateHash()
    {
      return new Dictionary<JVRPair<T>, double>(EqualityComparerFactory<JVRPair<T>>.GetComparer());
    }

    private void Divide(double div)
    {
      Dictionary<JVRPair<T>, double> ret = CreateHash();
      foreach (KeyValuePair<JVRPair<T>, double> pair in myHash)
      {
        ret.Add(pair.Key, pair.Value / div);
      }
      myHash = ret;
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
    }

    public double this[JVRPair<T> pair]
    {
      get { return myHash[pair];}
      set { myHash[pair] = value; }
    }

    public void ComputeEntropy(IEntropyListener<T> listener)
    {
      EntropyEvaluator<T, JVRPair<T>>.ComputeEntropy(myHash, Norm(), listener);
    }
  }
}