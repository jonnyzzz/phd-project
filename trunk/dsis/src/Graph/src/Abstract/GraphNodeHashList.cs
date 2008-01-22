using System.Collections;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Abstract
{
  public class GraphNodeHashList<TNode, TCell>
    where TCell : ICellCoordinate
    where TNode : Node<TNode, TCell>
  {
    private static readonly IEqualityComparer<TCell> COMPARER = EqualityComparerFactory<TCell>.GetComparer();
    private readonly Item[] myItems;
    private readonly int myHashMax;

    public GraphNodeHashList(int capacity)
    {
      myHashMax = capacity;
      myItems = new Item[myHashMax];
    }

    public bool AddIfNotReplace(ref TNode t)
    {
      int index = t.HashCodeInternal%myHashMax;

      Item it = myItems[index];
      while (it != null)
      {
        if (it.Value.HashCodeInternal == t.HashCodeInternal && COMPARER.Equals(it.Value.Coordinate, t.Coordinate))
        {
          t = it.Value;
          return false;
        }
        it = it.NextItem;
      }

      it = new Item(t);
      it.NextItem = myItems[index];
      myItems[index] = it;

      return true;
    }

    public bool Contains(TCell node)
    {
      int hashCode = Node<TNode, TCell>.NodeHashCode(node);
      int index = hashCode%myHashMax;

      Item it = myItems[index];
      while (it != null)
      {
        if (it.Value.HashCodeInternal == hashCode
            && COMPARER.Equals(it.Value.Coordinate, node))
        {
          return true;
        }
        it = it.NextItem;
      }
      return false;
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