using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Abstract
{
  public class ArrayNodeSet<TNode, TCell> : INodeSetState<TNode, TCell>
    where TCell : ICellCoordinate
    where TNode : Node<TNode, TCell>
  {
    private static readonly IEqualityComparer<TCell> COMPARER = EqualityComparerFactory<TCell>.GetComparer();
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

    public INodeSetState<TNode, TCell> AddIfNotReplace(ref TNode t, out bool wasAdded)
    {     
      for (int i = 0; i < myNodes.Length; i++)
      {
        TNode node = myNodes[i];
        if (node != null)
        {
          if (COMPARER.Equals(node.Coordinate, t.Coordinate))
          {
            t = node;
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
      get {
        for (int i = 0; i < myNodes.Length; i++)
        {
          TNode node = myNodes[i];
          if (node != null)
            yield return node;
          else
            break;
        }
      }
    }

    public IEnumerable<INode<TCell>> ValuesUpcasted
    {
      get { return new UpcastedEnumerable<IEnumerable<TNode>, TNode, INode<TCell>>(Values); }
    }    
  }
}