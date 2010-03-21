using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Tarjan
{
  public class TarjanNodeStack<TCell, TNode> : IDisposable
    where TCell : ICellCoordinate
    where TNode : class, INode<TCell>
  {
    private readonly Stack<TNode> myStack = new Stack<TNode>();
    private readonly IGraphDataHoler<bool, TNode> myMask;

    public TarjanNodeStack(IGraphDataHoler<bool,TNode> mask)
    {
      myMask = mask;
    }

    public void Push(TNode node)
    {
      myStack.Push(node);
      myMask.SetData(node, true);
    }

    public TNode Pop()
    {
      var node = myStack.Pop();
      myMask.SetData(node, false);
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
      return myMask.GetData(node);
    }

    public void Dispose()
    {
      myStack.Clear();
      myMask.Dispose();
    }
  }
}