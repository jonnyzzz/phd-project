using System;

namespace DSIS.Utils
{
  public class BinTreePriorityQueue<T, Q>
    where Q : IComparable<Q>
  {
    private const int AUTO_CONSOLIDATE = 1023;

    protected Node myMin;
    private int mySize = 0;
    private int myNonConsolidatedSize = 0;

    public void Enqueue(Pair<T, Q> data)
    {
      Node node = new Node(data.Second, data.First);
      Add(node);
      mySize++;
      myNonConsolidatedSize++;
      if (myNonConsolidatedSize >= AUTO_CONSOLIDATE)
      {
        myNonConsolidatedSize = 0;
        Consolidate();
      }
    }

    public Pair<T, Q> Dequeue()
    {
      if (myMin == null)
        throw new IndexOutOfRangeException("Collection is empty");

      Node min = myMin;
      myMin = myMin.Sibling;
      mySize--;

      for (Node child = min.Child; child != null;)
      {
        Node t = child.Sibling;
        child.Sibling = myMin;
        myMin = child;
        child = t;
      }

      Consolidate();

      return min.Pair;
    }


    private static void Swap<TT>(ref TT a, ref TT b)
    {
      TT c = a;
      a = b;
      b = c;
    }

    private static void ProcessNode(Node[] A, Node cur)
    {
      uint d = cur.Degree;
      while (A[d] != null)
      {
        Node child = A[d];
        A[d] = null;

        if (child.CompareTo(cur) < 0)
          Swap(ref child, ref cur);

        cur.AddChild(child);
        d++;
      }
      A[d] = cur;
    }

    protected void Consolidate()
    {
      myNonConsolidatedSize = 0;

      if (myMin == null || myMin.Sibling == myMin)
        return;

      var A = new Node[Log2Helper.Nearest(mySize) + 2];

      for (Node cur = myMin; cur != null;)
      {
        Node curNext = cur.Sibling;
        ProcessNode(A, cur);
        cur = curNext;
      }

      myMin = null;
      Node preMin = null;
      Node leaf = null;
      Node prev = null;
      foreach (Node node in A)
      {
        if (node == null)
          continue;

        node.Sibling = null;
        if (prev != null)
          prev.Sibling = node;
        else
          leaf = node;

        if (myMin == null)
        {
          preMin = prev;
          myMin = node;
        }
        else if (myMin.CompareTo(node) > 0)
        {
          preMin = prev;
          myMin = node;
        }

        prev = node;
      }

      if (preMin != null)
      {
        preMin.Sibling = null;
        prev.Sibling = leaf;
      }
    }

    private void Add(Node node)
    {
      if (myMin == null)
      {
        myMin = node;
      }
      else if (node.CompareTo(myMin) < 0)
      {
        node.Sibling = myMin;
        myMin = node;
      }
      else
      {
        node.Sibling = myMin.Sibling;
        myMin.Sibling = node;
      }
    }

    protected class Node : IComparable<Node>
    {
      private readonly Q myValue;
      private readonly T myData;

      public Node Child;
      public Node Sibling;
      public uint Degree;

      public Node(Q value, T data)
      {
        myValue = value;
        myData = data;
      }

      public Pair<T, Q> Pair
      {
        get { return new Pair<T, Q>(myData, myValue); }
      }

      public int CompareTo(Node other)
      {
        return myValue.CompareTo(other.myValue);
      }

      public override string ToString()
      {
        return string.Format("{0}({1}) ", myValue, myData);
      }

      public void AddChild(Node child)
      {
        child.Sibling = Child;
        Child = child;
        Degree++;
      }
    }
  }
}