using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Abstract
{
  public class OneNodeSetState<TNode, TCell> : INodeSetState<TNode, TCell>
    where TCell : ICellCoordinate
    where TNode : Node<TNode, TCell>
  {
    private static readonly IEqualityComparer<TCell> COMPARER = EqualityComparerFactory<TCell>.GetComparer();
    private readonly TNode myNode;
    private readonly NextDelegate myNext;

    public delegate INodeSetState<TNode, TCell> NextDelegate(TNode thisNode, TNode next);

    public OneNodeSetState(TNode node, NextDelegate next)
    {
      myNode = node;
      myNext = next;
    }

    public IEnumerable<TNode> Values
    {
      get { return new TNode[] {myNode}; }
    }

    public IEnumerable<INode<TCell>> ValuesUpcasted
    {
      get { return new INode<TCell>[] {myNode}; }
    }

    public INodeSetState<TNode, TCell> AddIfNotReplace(ref TNode t, out bool wasAdded)
    {
      if (COMPARER.Equals(myNode.Coordinate, t.Coordinate))
      {
        t = myNode;
        wasAdded = false;
        return this;
      }
      wasAdded = true;
      return myNext(myNode, t);
    }
  }
}