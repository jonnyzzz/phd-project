using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  public class TarjanNodeStack<TCell, TValue> where TCell : ICellCoordinate<TCell>
  {
    private readonly Stack<TarjanNode<TCell, TValue>> myStack = new Stack<TarjanNode<TCell, TValue>>();
    private readonly TarjanNodeFlags myMask;

    public TarjanNodeStack(TarjanNodeFlags mask)
    {
      myMask = mask;
    }

    public void Push(TarjanNode<TCell, TValue> node)
    {
      myStack.Push(node);
      node.SetFlag(myMask, true);
    }

    public TarjanNode<TCell, TValue> Pop()
    {
        TarjanNode<TCell, TValue> node = myStack.Pop();
        node.SetFlag(myMask, false);
        return node;
    }

    public TarjanNode<TCell, TValue> Peek()
    {
      return myStack.Peek();
    }

    public bool IsEmpty()
    {
      return myStack.Count == 0;
    }

    public bool Contains(TarjanNode<TCell, TValue> node)
    {
      return node.GetFlag(myMask);
    }
  }
}