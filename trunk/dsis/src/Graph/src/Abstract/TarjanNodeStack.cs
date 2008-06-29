using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  public class TarjanNodeStack<TCell, TNode> 
    where TCell : ICellCoordinate
    where TNode : Node<TNode, TCell>
  {
    private readonly Stack<TNode> myStack = new Stack<TNode>();
    private readonly NodeFlag myMask;

    public TarjanNodeStack(NodeFlag mask)
    {
      myMask = mask;
    }

    public void Push(TNode node)
    {
      myStack.Push(node);
      node.SetFlag(myMask, true);
    }

    public TNode Pop()
    {
      var node = myStack.Pop();
      node.SetFlag(myMask, false);
      return node;
    }

    public TNode Peek()
    {
      return myStack.Peek();
    }

    public bool IsEmpty()
    {
      return myStack.Count == 0;
    }

    public bool Contains(TNode node)
    {
      return node.GetFlag(myMask);
    }

    public void Clear()
    {
      myStack.Clear();
    }    
  }
}