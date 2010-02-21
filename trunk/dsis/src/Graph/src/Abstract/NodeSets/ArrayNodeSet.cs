using System;
using System.Collections;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Abstract.NodeSets
{
  public class ArrayNodeSet<TNode, TCell> : INodeSetState<TNode, TCell>, IEnumerable<TNode>
    where TCell : ICellCoordinate
    where TNode : Node<TNode, TCell>
  {
    private static readonly IEqualityComparer<TNode> COMPARER = EqualityComparerFactory<TNode>.GetComparer();
    private readonly TNode[] myNodes;
    private readonly DelegateAddOnOverflow myNext;

    public delegate INodeSetState<TNode, TCell> DelegateAddOnOverflow(TNode[] nodes, TNode t);

    public ArrayNodeSet(int size, DelegateAddOnOverflow next, TNode node, params TNode[] nodes)
    {
      myNodes = new TNode[size];
      myNext = next;
      Array.Copy(nodes, 0, myNodes, 0, nodes.Length);
      myNodes[nodes.Length] = node;
    }    

    public INodeSetState<TNode, TCell> AddIfNotReplace(TNode t, out bool wasAdded)
    {     
      for (int i = 0; i < myNodes.Length; i++)
      {
        TNode node = myNodes[i];
        if (node != null)
        {
          if (COMPARER.Equals(node, t))
          {
            wasAdded = false;
            return this;
          }
        } else
        {
          myNodes[i] = t;
          wasAdded = true;
          return this;
        }
      }
      wasAdded = true;
      return myNext(myNodes, t);
    }    
    
    public IEnumerable<TNode> Values
    {
      get { return this; }
    }
      
    private class NodesEmunerator : IEnumerator<TNode>
    {
      private readonly TNode[] myNodes;
      private int myIndex;

      public NodesEmunerator(TNode[] nodes)
      {
        Reset();
        myNodes = nodes;
      }

      public TNode Current
      {
        get { return myNodes[myIndex]; }
      }

      public void Dispose()
      {        
      }

      public bool MoveNext()
      {
        return ++myIndex < myNodes.Length && myNodes[myIndex] != null;
      }

      public void Reset()
      {
        myIndex = -1;
      }

      object IEnumerator.Current
      {
        get { return Current; }
      }
    }

    IEnumerator<TNode> IEnumerable<TNode>.GetEnumerator()
    {
      return new NodesEmunerator(myNodes);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return ((IEnumerable<TNode>) this).GetEnumerator();
    }
  }
}