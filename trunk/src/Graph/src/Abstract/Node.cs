using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Util;

namespace DSIS.Graph.Abstract
{ 
  public abstract class Node<TInh, TCell, TValue> : INode<TCell, TValue> 
    where TCell : ICellCoordinate<TCell>
    where TInh : Node<TInh, TCell, TValue>
  {
    private readonly TCell myCoordinate;
    private TValue myValue;
    private readonly Hashset<TInh, INode<TCell, TValue>> myEdges;
    private int myHashcode;

    internal Node(TCell coordinate, TValue value)
    {
      myCoordinate = coordinate;
      myValue = value;
      myEdges = new Hashset<TInh, INode<TCell, TValue>>(NodeEqualityComparer<TInh, TCell, TValue>.INSTANCE);
      myHashcode = myCoordinate.GetHashCode();
    }

    public TCell Coordinate
    {
      get { return myCoordinate; }
    }

    public TValue Value
    {
      get { return myValue; }
      set { myValue = value; }
    }

    public override bool Equals(object obj)
    {
      if (!(obj is Node<TInh, TCell, TValue>)) 
        return false;
      Node<TInh, TCell, TValue> node = (Node<TInh, TCell, TValue>) obj;
      return Equals(myCoordinate, node.myCoordinate);
    }

    public override int GetHashCode()
    {
      return myHashcode;
    }

    internal bool AddEdgeTo(TInh node)
    {
      return myEdges.AddIfNotReplace(ref node);
    }

    internal IEnumerable<INode<TCell, TValue>> Edges
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

  internal class NodeEqualityComparer<TNode, TCell, TValue> : IEqualityComparer<TNode>
    where TNode : Node<TNode, TCell, TValue>
    where TCell : ICellCoordinate<TCell>
  {
    public static NodeEqualityComparer<TNode, TCell, TValue> INSTANCE = new NodeEqualityComparer<TNode, TCell, TValue>();

    public bool Equals(TNode x, TNode y)
    {
      return x.EqualsInternal(y);
    }

    public int GetHashCode(TNode obj)
    {
      return obj.HashCodeInternal;
    }
  }
}