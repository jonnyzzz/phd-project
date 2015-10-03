using System.Collections;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Abstract.NodeSets
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

    protected GraphNodeHashList(int capacity, TNode node, params TNode[] nodes) : this(capacity)
    {
      foreach (TNode tNode in nodes)
      {
        AddNodeNoCheck(tNode);
      }
      AddNodeNoCheck(node);
    }

    protected void AddNodeNoCheck(TNode t)
    {
      var tHashCode = t.HashCodeInternal;
      var index = tHashCode % myHashMax;
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

    public bool Contains(TNode node)
    {
      return FindItem(node) != null;
    }
    
    public TNode Find(TCell node)
    {
      var find = FindItem(node);
      return find != null ? find.Value : null;
    }

    private Item FindItem(TCell cell)
    {
      return FindCellInternal(cell, Node<TNode, TCell>.NodeHashCode(cell));
    }

    private Item FindCellInternal(TCell cell, int hashCode)
    {
      var index = hashCode % myHashMax;

      Item it = myItems[index];
      while (it != null)
      {
        var value = it.Value;
        if (value.HashCodeInternal == hashCode && COMPARER.Equals(value.Coordinate, cell))
        {
          return it;
        }
        it = it.NextItem;
      }
      return null;
    }

    private Item FindItem(TNode node)
    {
      return FindCellInternal(node.Coordinate, node.HashCodeInternal);      
    }

    public IEnumerable<TNode> Values
    {
      get { return new NodeEnumerableTNode(myItems); }
    }

    private sealed class Item
    {
      public readonly TNode Value;
      public Item NextItem;

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
  }
}