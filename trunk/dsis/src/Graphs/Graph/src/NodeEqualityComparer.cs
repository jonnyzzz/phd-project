using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph
{
  public class NodeEqualityComparer<T> : IEqualityComparer<INode<T>> where T : ICellCoordinate
  {
    private static readonly IEqualityComparer<T> COMPARER = EqualityComparerFactory<T>.GetComparer();

    public bool Equals(INode<T> x, INode<T> y)
    {
      return COMPARER.Equals(x.Coordinate, y.Coordinate);
    }

    public int GetHashCode(INode<T> obj)
    {
      return COMPARER.GetHashCode(obj.Coordinate);
    }
  }
}