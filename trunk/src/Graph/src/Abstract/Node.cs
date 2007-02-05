using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Util;

namespace DSIS.Graph.Abstract
{ 
  public abstract class Node<TInh, TCell> : INode<TCell> 
    where TCell : ICellCoordinate<TCell>
    where TInh : Node<TInh, TCell>
  {
    private readonly TCell myCoordinate;
    private readonly Hashset<TInh, INode<TCell>> myEdges;
    private int myHashcode;

    internal Node(TCell coordinate)
    {
      myCoordinate = coordinate;
      myEdges = new Hashset<TInh, INode<TCell>>(NodeEqualityComparer<TInh, TCell>.INSTANCE);
      myHashcode = myCoordinate.GetHashCode();
    }

    public TCell Coordinate
    {
      get { return myCoordinate; }
    }

    public sealed override bool Equals(object obj)
    {
      if (!(obj is Node<TInh, TCell>)) 
        return false;
      Node<TInh, TCell> node = (Node<TInh, TCell>) obj;
      return Equals(myCoordinate, node.myCoordinate);
    }

    public sealed override int GetHashCode()
    {
      return myHashcode;
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

    internal bool EqualsInternal(TInh node)
    {
      return myCoordinate.Equals(node.myCoordinate);
    }

    internal int HashCodeInternal
    {
      get { return myHashcode; }
    }
  }
}