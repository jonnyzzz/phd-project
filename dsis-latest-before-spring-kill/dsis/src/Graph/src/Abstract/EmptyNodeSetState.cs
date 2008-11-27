using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Abstract
{
  public class EmptyNodeSetState<TNode, TCell> : INodeSetState<TNode, TCell>
    where TCell : ICellCoordinate
    where TNode : Node<TNode, TCell>
  {
    public delegate INodeSetState<TNode, TCell> NextDelegate(TNode t);

    private readonly NextDelegate myNext;

    public EmptyNodeSetState(NextDelegate next)
    {
      myNext = next;
    }

    public IEnumerable<TNode> Values
    {
      get { return EmptyArray<TNode>.Instance; }
    }

    public IEnumerable<INode<TCell>> ValuesUpcasted
    {
      get { return EmptyArray<INode<TCell>>.Instance; }
    }

    public INodeSetState<TNode, TCell> AddIfNotReplace(ref TNode t, out bool wasAdded)
    {
      wasAdded = true;
      return myNext(t);
    }
  }
}