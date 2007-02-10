using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph;
using DSIS.Util;

namespace DSIS.Graph.Abstract
{ 
  public abstract class Node<TInh, TCell> : INode<TCell> 
    where TCell : ICellCoordinate<TCell>
    where TInh : Node<TInh, TCell>
  {
    private static IEqualityComparer<TCell> CellComparer = EqualityComparerFactory<TCell>.GetComparer();

    public readonly TCell Coordinate;
    private readonly Hashset<TInh, INode<TCell>> myEdges;
    internal int HashCodeInternal;

    internal Node(TCell coordinate)
    {
      Coordinate = coordinate;
      myEdges = new Hashset<TInh, INode<TCell>>(NodeEqualityComparer<TInh, TCell>.INSTANCE);
      HashCodeInternal = CellComparer.GetHashCode(Coordinate);
    }

   public sealed override bool Equals(object obj)
    {
      if (!(obj is Node<TInh, TCell>)) 
        return false;
      Node<TInh, TCell> node = (Node<TInh, TCell>) obj;

      return Equals(Coordinate, node.Coordinate);
    }

    public sealed override int GetHashCode()
    {
      return HashCodeInternal;
    }

    internal bool AddEdgeTo(TInh node)
    {
      return myEdges.AddIfNotReplace(ref node);
    }

    internal IEnumerable<INode<TCell>> Edges
    {
      get { return myEdges.ValuesUpcasted; }
    }

    internal IEnumerable<TInh> EdgesInternal
    {
      get { return myEdges.Values; }
    }

    TCell INode<TCell>.Coordinate
    {
      get { return Coordinate; }
    }
  }
}