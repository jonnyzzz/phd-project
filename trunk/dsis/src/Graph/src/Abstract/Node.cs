using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Abstract
{
  [EqualityComparer(typeof(NodeEqualityComparer<,>))]
  public abstract class Node<TInh, TCell> : INode<TCell>, INodeInternal<TCell>
    where TCell : ICellCoordinate
    where TInh : Node<TInh, TCell>
  {
    private static readonly IEqualityComparer<TCell> CellComparer = EqualityComparerFactory<TCell>.GetComparer();
    private static readonly NodeSetFactory<TInh, TCell> NodeFactory = new NodeSetFactory<TInh, TCell>();

    public readonly TCell Coordinate;
    private INodeSetState<TInh, TCell> myEdges;
    internal readonly int HashCodeInternal;
    private object myUserValue;

    protected Node(TCell coordinate)
    {
      Coordinate = coordinate;
      myEdges = NodeFactory.Create();
      HashCodeInternal = NodeHashCode(coordinate);
    }

    internal static int NodeHashCode(TCell coordinate)
    {
      return CellComparer.GetHashCode(coordinate) & 0x7fffffff;
    }

    TCell INode<TCell>.Coordinate
    {
      get { return Coordinate; }
    }

    public void SetUserData<T>(T data)
    {
      myUserValue = data;
    }

    public T GetUserData<T>(Lazy<T> def)
    {
      if (myUserValue is T)
        return (T)myUserValue;

      T newValue = def();
      myUserValue = newValue;
      return newValue;
    }

    public bool HasUserData<T>()
    {
      return myUserValue is T;
    }

    public override sealed bool Equals(object obj)
    {
      if (!(obj is Node<TInh, TCell>))
        return false;
      var node = (Node<TInh, TCell>) obj;

      return CellComparer.Equals(Coordinate, node.Coordinate);
    }

    public override sealed int GetHashCode()
    {
      return HashCodeInternal;
    }

    internal bool AddEdgeTo(TInh node)
    {
      bool wasAdded;
      myEdges = myEdges.AddIfNotReplace(ref node, out wasAdded);
      return wasAdded;
    }

    internal IEnumerable<INode<TCell>> Edges
    {
      get { return myEdges.ValuesUpcasted; }
    }

    IEnumerable<INode<TCell>> INodeInternal<TCell>.Edges
    {
      get { return Edges; }
    }

    internal IEnumerable<TInh> EdgesInternal
    {
      get { return myEdges.Values; }
    }

    public override string ToString()
    {
      return string.Format("[Node: {0}]", Coordinate);
    }
  }
}