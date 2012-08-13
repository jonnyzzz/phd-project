using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Utils;
using System.Linq;

namespace DSIS.Graph.Entropy.Impl.JVR
{
  public class HashHolder<T> : IHashholderController<T>
    where T : ICellCoordinate
  {
    const double EPS = 1e-8;
    private static readonly IEqualityComparer<JVRPair<T>> COMPARER = EqualityComparerFactory<JVRPair<T>>.GetComparer();
    private readonly ICellCoordinateSystem<T> mySystem;
    private double? myCachedNorm;

    private Dictionary<JVRPair<T>, double> myHash = CreateHash();
    private SortedNodeSet<T> mySet = CreateSet();

    public HashHolder(ICellCoordinateSystem<T> system)
    {
      mySystem = system;
    }

    private static Dictionary<JVRPair<T>, double> CreateHash()
    {
      return new Dictionary<JVRPair<T>, double>(COMPARER);
    }
    
    private static SortedNodeSet<T> CreateSet()
    {
      return new SortedNodeSet<T>();
    }

    public int PriorityQueueNodes
    {
      get { return mySet.Count; }
    }

    private void Divide(double div)
    {
      Dictionary<JVRPair<T>, double> current = myHash;

      myHash = CreateHash();      
      mySet = CreateSet();
      
      using (ItemRebuildCookie<T> cookie = RebuildCookie())
      {
        foreach (KeyValuePair<JVRPair<T>, double> pair in current)
        {
          double value = pair.Value/div;
          JVRPair<T> key = pair.Key;
          cookie.SetItem(key, value);
        }
      }
    }

    private double Norm()
    {
      if (myCachedNorm == null)
      {
        double v = myHash.Values.Sum();
        myCachedNorm = v;
        return v;
      }
      return myCachedNorm.Value;
    }

    public void Normalize()
    {
      double myNorm = Norm();
      
      if (Math.Abs(myNorm - 1.0) < EPS)
        return;

      Divide(myNorm);

      myCachedNorm = 1;
    }

    public ItemUpdateCookie<T> UpdateCookie(ArcDirection<T> strait, ArcDirection<T> back)
    {
      return new ItemUpdateCookie<T>(this, strait, back);
    }

    public ItemRebuildCookie<T> RebuildCookie()
    {
      return new ItemRebuildCookie<T>(this);
    }
    
    void IHashholderController<T>.SetItem(JVRPair<T> pair, double value)
    {
      myCachedNorm = null;
      myHash[pair] = value;     
    }

    double IHashholderController<T>.SetItem(T node, double output, double input)
    {
      myCachedNorm = null;
      return mySet.SetValue(node, output, input);
    }

    public double GetItem(JVRPair<T> pair)
    {      
      return myHash[pair];
    }

    public IGraphMeasure<T> CreateEvaluator()
    {
      return new GraphMeasure<T, JVRPair<T>>("JVR", myHash, EqualityComparerFactory<T>.GetComparer(), Norm(), mySystem);
    }

    public IGraphMeasure<T> CreateEvaluatorCopy()
    {
      return new GraphMeasure<T, JVRPair<T>>("JVR", new Dictionary<JVRPair<T>, double>(myHash), EqualityComparerFactory<T>.GetComparer(), Norm(), mySystem);
    }
    
    public T NextNode()
    {
      return mySet.NextNode();
    }   

    public double SummaryError
    {
      get
      {
        return mySet.SummaryError / Norm();
      }
    }
  }      
}