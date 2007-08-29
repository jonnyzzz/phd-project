using DSIS.Core.Coordinates;
using DSIS.Graph.Util;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.JVR
{
  public abstract class ArcDirection<T>
    where T : ICellCoordinate<T>
  {
    protected readonly HashHolder<T> myHash;
    protected readonly MultiDictionary<T, JVRPair<T>> myIndex = new MultiDictionary<T, JVRPair<T>>(EqualityComparerFactory<T>.GetReferenceComparer());

    public ArcDirection(HashHolder<T> hash)
    {
      myHash = hash;
    }

    protected abstract T GetStart(JVRPair<T> pair);

    public void Add(JVRPair<T> node)
    {      
      myIndex.AddValue(GetStart(node), node);
    }
    
    public double ComputeWeight(INode<T> node)
    {
      double w = 0;
      T nodeCoordinates = node.Coordinate;

      foreach (JVRPair<T> edge in myIndex[nodeCoordinates])
      {        
        w += myHash[edge];
      }
      return w;

    }

    public void MultiplyWeight(INode<T> node, double factor) 
    {
      T nodeCoordinates = node.Coordinate;

      foreach (JVRPair<T> edge in myIndex[nodeCoordinates])
      {
        myHash[edge] *= factor;        
      }
    }
  }
}