using System.Collections;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Abstract
{
  //todo: Implement IList to have indexer and to be able to replace it with List<T>
  public class GraphNodeHashList<TNode, TCell> : INodeSet<TNode, TCell>
    where TCell : ICellCoordinate
    where TNode : Node<TNode, TCell>
  {
    private static readonly IEqualityComparer<TCell> COMPARER = EqualityComparerFactory<TCell>.GetComparer();
    private readonly Item[] myItems;
    private int myCount = 0;    
    private readonly int myHashMax;

    public GraphNodeHashList(int capacity)
    {
      myHashMax = capacity;
      myItems = new Item[myHashMax];
    }

    public GraphNodeHashList(int capacity, TNode node, params TNode[] nodes) : this(capacity)
    {
      foreach (TNode tNode in nodes)
      {
        AddNodeNoCheck(tNode);
      }
      AddNodeNoCheck(node);
    }

    private void AddNodeNoCheck(TNode t)
    {
      int tHashCode = t.HashCodeInternal;

      int index = tHashCode % myHashMax;
      myCount++;

      var it = new Item(t) { NextItem = myItems[index] };
      myItems[index] = it;
    }

    public TNode AddIfNotReplace(TCell cell, IGraphNodeFactory<TNode, TCell> ext, out bool wasAdded)
    {
      var node = Find(cell);
      if (node != null)
      {
        wasAdded = false;
        return node;
      }

      node = ext.CreateNode(cell);
      AddNodeNoCheck(node);
      wasAdded = true;
      return node;      
    }

    public bool Contains(TCell node)
    {
      return FindItem(node) != null;
    }
    
    public TNode Find(TCell node)
    {
      var find = FindItem(node);
      return find != null ? find.Value : null;
    }

    //todo: Create FindItem(TNode) no use cached hashcodes
    private Item FindItem(TCell node)
    {
      int hashCode = Node<TNode, TCell>.NodeHashCode(node);
      int index = hashCode % myHashMax;

      Item it = myItems[index];
      while (it != null)
      {
        var value = it.Value;
        if (value.HashCodeInternal == hashCode && COMPARER.Equals(value.Coordinate, node))
        {
          return it;
        }
        it = it.NextItem;
      }
      return null;
    }

    public IEnumerable<TNode> Values
    {
      get { return new NodeEnumerableTNode(myItems); }
    }

    public IEnumerable<INode<TCell>> ValuesUpcasted
    {
      get { return new NodeEnumerableINode(myItems); }
    }

    private sealed class Item
    {
      public readonly TNode Value;
      public Item NextItem = null;

      public Item(TNode value)
      {
        Value = value;
      }
    }

    private class NodeEnumerable
    {
      protected readonly Item[] myData;

      public NodeEnumerable(Item[] data)
      {
        myData = data;
      }
    }

    private class NodeEnumerableTNode : NodeEnumerable, IEnumerable<TNode>
    {
      public NodeEnumerableTNode(Item[] data)
        : base(data)
      {
      }

      IEnumerator<TNode> IEnumerable<TNode>.GetEnumerator()
      {
        return Create();
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
        return Create();
      }

      private NodeEnumeratorTNode Create()
      {
        return new NodeEnumeratorTNode(myData);
      }
    }

    private class NodeEnumerableINode : NodeEnumerable, IEnumerable<INode<TCell>>
    {
      public NodeEnumerableINode(Item[] data) : base(data)
      {
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
        return Create();
      }

      private NodeEnumeratorINode Create()
      {
        return new NodeEnumeratorINode(myData);
      }

      IEnumerator<INode<TCell>> IEnumerable<INode<TCell>>.GetEnumerator()
      {
        return Create();
      }
    }

    private class NodeEnumerator : IEnumerator
    {
      private readonly Item[] myData;

      private Item myCurrent;
      private int myCnt;


      public NodeEnumerator(Item[] data)
      {
        myData = data;
        Reset();
      }

      public void Dispose()
      {
      }

      public bool MoveNext()
      {
        while (myCnt < myData.Length)
        {
          if (myCurrent != null)
          {
            myCurrent = myCurrent.NextItem;
          }
          else if (myCnt + 1 < myData.Length)
          {
            myCurrent = myData[++myCnt];
          }
          else
          {
            myCnt++;
            myCurrent = null;
            return false;
          }

          if (myCurrent != null)
            return true;
        }
        return false;
      }

      public void Reset()
      {
        myCurrent = null;
        myCnt = -1;
      }

      object IEnumerator.Current
      {
        get { return Current; }
      }

      public TNode Current
      {
        get { return myCurrent.Value; }
      }
    }

    private class NodeEnumeratorTNode : NodeEnumerator, IEnumerator<TNode>
    {
      public NodeEnumeratorTNode(Item[] data) : base(data)
      {
      }

      TNode IEnumerator<TNode>.Current
      {
        get { return Current; }
      }
    }

    private class NodeEnumeratorINode : NodeEnumerator, IEnumerator<INode<TCell>>
    {
      public NodeEnumeratorINode(Item[] data) : base(data)
      {
      }

      INode<TCell> IEnumerator<INode<TCell>>.Current
      {
        get { return Current; }
      }
    }
  }
}