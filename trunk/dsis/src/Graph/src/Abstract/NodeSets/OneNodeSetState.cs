using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Abstract.NodeSets
{
  public class OneNodeSetState<TNode, TCell> : INodeSetState<TNode, TCell>
    where TCell : ICellCoordinate
    where TNode : Node<TNode, TCell>
  {
    private static readonly IEqualityComparer<TNode> COMPARER = EqualityComparerFactory<TNode>.GetComparer();
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
      get { return new[] {myNode}; }
    }

    public INodeSetState<TNode, TCell> AddIfNotReplace(TNode t, out bool wasAdded)
    {
      if (COMPARER.Equals(myNode, t))
      {
        wasAdded = false;
        return this;
      }
      wasAdded = true;
      return myNext(myNode, t);
    }
  }
}