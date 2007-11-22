using DSIS.Core.Coordinates;
using DSIS.Graph.Util;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.JVR
{
  public abstract class ArcDirection<T>
    where T : ICellCoordinate<T>
  {
    protected readonly HashHolder<T> myHash;
    protected readonly MultiDictionary<T, JVRPair<T>> myIndex = new MultiDictionary<T, JVRPair<T>>(EqualityComparerFactory<T>.GetComparer());

    public ArcDirection(HashHolder<T> hash)
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
      
      foreach (JVRPair<T> edge in myIndex[node])
      {        
        w += myHash.GetItem(edge);
      }
      return w;
    }

    public void MultiplyWeight(ItemUpdateCookie<T> cookie, T node, double factor) 
    {
      foreach (JVRPair<T> edge in myIndex[node])
      {
        cookie.SetItem(edge, myHash.GetItem(edge)*factor);        
      }
    }
  }
}