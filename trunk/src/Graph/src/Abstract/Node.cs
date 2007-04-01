using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Abstract
{
  public abstract class Node<TInh, TCell> : INode<TCell>
    where TCell : ICellCoordinate<TCell>
    where TInh : Node<TInh, TCell>
  {
    private static IEqualityComparer<TCell> CellComparer = EqualityComparerFactory<TCell>.GetComparer();

    public readonly TCell Coordinate;
    private readonly GraphNodeHashList<TInh, TCell> myEdges;
    internal int HashCodeInternal;

    internal Node(TCell coordinate)
    {
      Coordinate = coordinate;
      myEdges = new GraphNodeHashList<TInh, TCell>(7);
      HashCodeInternal = CellComparer.GetHashCode(Coordinate) & 0x7fffffff;
    }

    #region INode<TCell> Members

    TCell INode<TCell>.Coordinate
    {
      get { return Coordinate; }
    }

    #endregion

    public override sealed bool Equals(object obj)
    {
      if (!(obj is Node<TInh, TCell>))
        return false;
      Node<TInh, TCell> node = (Node<TInh, TCell>) obj;

      return Equals(Coordinate, node.Coordinate);
    }

    public override sealed int GetHashCode()
    {
      return HashCodeInternal;
    }

    internal bool AddEdgeTo(TInh node)
    {
      return myEdges.AddIfNotReplace(ref node);
    }

    internal IEnumerable<INode<TCell>> Edges
    {
      get { return new UpcastedEnumerable<TInh, INode<TCell>>(myEdges.Values); }
    }

    internal IEnumerable<TInh> EdgesInternal
    {
      get { return myEdges.Values; }
    }
  }
}