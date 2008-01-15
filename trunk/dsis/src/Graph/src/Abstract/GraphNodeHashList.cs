using System.Collections;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Abstract
{
  public class GraphNodeHashList<TNode, TCell>
    where TCell : ICellCoordinate<TCell>
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

    public bool Contains(TNode node)
    {
      int index = node.HashCodeInternal % myHashMax;

      Item it = myItems[index];
      while (it != null)
      {
        if (it.Value.HashCodeInternal == node.HashCodeInternal 
          && COMPARER.Equals(it.Value.Coordinate, node.Coordinate))
        {
          return true;
        }
        it = it.NextItem;
      }
      return false;
    }

    public IEnumerable<TNode> Values
    {
      get{return new NodeEnumerable(myItems);}
    }

    public IEnumerable<INode<TCell>> ValuesUpcasted
    {
      get { return new NodeEnumerableUpcatsed(myItems); }
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

    private sealed class NodeEnumerable : IEnumerable<TNode>
    {
      private readonly Item[] myData;

      public NodeEnumerable(Item[] data)
      {
        myData = data;
      }

      IEnumerator<TNode> IEnumerable<TNode>.GetEnumerator()
      {
        return Create();
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
        return Create();
      }

      private NodeEnumerator Create()
      {
        return new NodeEnumerator(myData);
      }
    }
    
    private sealed class NodeEnumerableUpcatsed : IEnumerable<INode<TCell>>
    {
      private readonly Item[] myData;

      public NodeEnumerableUpcatsed(Item[] data)
      {
        myData = data;
      }

      IEnumerator<INode<TCell>> IEnumerable<INode<TCell>>.GetEnumerator()
      {
        return new UpcastedEnumerator<NodeEnumerator, TNode, INode<TCell>>(new NodeEnumerator(myData));
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
        return new NodeEnumerator(myData);
      }
    }

    private sealed class NodeEnumerator : IEnumerator<TNode>
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
          } else
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
  }
}