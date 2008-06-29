using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  public class TarjanNodeStack<TCell> 
    where TCell : ICellCoordinate
  {
    private readonly Stack<TarjanNode<TCell>> myStack = new Stack<TarjanNode<TCell>>();
    private readonly NodeFlag myMask;

    public TarjanNodeStack(NodeFlag mask)
    {
      myMask = mask;
    }

    public void Push(TarjanNode<TCell> node)
    {
      myStack.Push(node);
      ((Node) node).SetFlag(myMask, true);
    }

    public TarjanNode<TCell> Pop()
    {
      TarjanNode<TCell> node = myStack.Pop();
      ((Node) node).SetFlag(myMask, false);
      return node;
    }

    public TarjanNode<TCell> Peek()
    {
      return myStack.Peek();
    }

    public bool IsEmpty()
    {
      return myStack.Count == 0;
    }

    public bool Contains(TarjanNode<TCell> node)
    {
      return ((Node) node).GetFlag(myMask);
    }
  }
}