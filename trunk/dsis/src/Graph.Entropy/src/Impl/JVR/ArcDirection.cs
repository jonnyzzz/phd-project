using System;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.JVR
{
  public abstract class ArcDirection<T>
    where T : ICellCoordinate
  {
    private readonly HashHolder<T> myHash;
    private readonly MultiDictionary<T, JVRPair<T>> myIndex = new MultiDictionary<T, JVRPair<T>>(EqualityComparerFactory<T>.GetComparer());

    protected ArcDirection(HashHolder<T> hash)
    {
      myHash = hash;
    }

    protected abstract T GetStart(JVRPair<T> pair);

    public void Add(JVRPair<T> node)
    {      
      myIndex.AddValue(GetStart(node), node);
    }
    
    public double ComputeWeight(T node)
    {
      double w = 0;
      var values = myIndex.GetValues(node);

      if (values.Count == 0)
      {
        throw new Exception("Failed to find edges for " + node);
      }
      foreach (JVRPair<T> edge in values)
      {
        w += myHash.GetItem(edge);
      }
      return w;
    }

    public void MultiplyWeight(ItemUpdateCookie<T> cookie, T node, double factor) 
    {
      foreach (var edge in myIndex[node])
      {
        cookie.SetItem(edge, myHash.GetItem(edge)*factor);        
      }
    }
  }
}