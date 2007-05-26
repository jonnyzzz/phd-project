using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph
{
  public class NodeEqualityComparer<T> : IEqualityComparer<INode<T>> where T :ICellCoordinate<T>
  {
    private static readonly IEqualityComparer<T> COMPARER = EqualityComparerFactory<T>.GetComparer();
    public static readonly IEqualityComparer<INode<T>> INSTANCE = new NodeEqualityComparer<T>();

    public bool Equals(INode<T> x, INode<T> y)
    {
      return COMPARER.Equals(x.Coordinate, y.Coordinate);
    }

    public int GetHashCode(INode<T> obj)
    {
      return COMPARER.GetHashCode(obj.Coordinate);
    }
  }

  public class NodeReferenceEqualityComparer<T> : IEqualityComparer<INode<T>> where T : ICellCoordinate<T>
  {
    public static readonly IEqualityComparer<INode<T>> INSTANCE = new NodeReferenceEqualityComparer<T>();
    
    public bool Equals(INode<T> x, INode<T> y)
    {
      return ReferenceEquals(x, y);
    }

    public int GetHashCode(INode<T> obj)
    {
      //todo: Eliminate GetHashCode from INode<T> implementations
      return obj.GetHashCode();
    }
  }
}