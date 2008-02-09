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

    public readonly TCell Coordinate;
    private readonly GraphNodeHashList<TInh, TCell> myEdges;
    internal int HashCodeInternal;
    private object myUserValue = null;

    public Node(TCell coordinate)
    {
      Coordinate = coordinate;
      myEdges = new GraphNodeHashList<TInh, TCell>(7);
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

    public T GetUserData<T>()
    {
      return (T) myUserValue;
    }

    public override sealed bool Equals(object obj)
    {
      if (!(obj is Node<TInh, TCell>))
        return false;
      Node<TInh, TCell> node = (Node<TInh, TCell>) obj;

      return CellComparer.Equals(Coordinate, node.Coordinate);
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