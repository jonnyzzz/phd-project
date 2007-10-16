using System;

namespace DSIS.Utils
{
  public class BinTreePriorityQueueEx<T,Q> where Q : IComparable<Q>
  {
    protected Node myMin = null;
    private int myCount = 0;
    
    public object AddNode(Q value, T data)
    {
      Node node = new Node(data, value);

      if (myMin == null)
      {
        myMin = node;
        node.Sibling = node.PrevSibling = node;
      }
      else
      {
        Node prev = myMin.PrevSibling;

        node.Sibling = myMin;
        myMin.PrevSibling = node;

        node.PrevSibling = prev;
        prev.Sibling = node;

        if (value.CompareTo(myMin.Value) < 0)
          myMin = node;
      }

      myCount++;
      return node;
    }

    public Pair<T,Q> ExtractMin()
    {
      if (myMin == null)
        throw new ArgumentException();

      Node node = myMin;

      if (myMin.PrevSibling == myMin)
        myMin = null;
      else
      {
        node.PrevSibling.Sibling = node.Sibling;
        node.Sibling.PrevSibling = node.PrevSibling;
        myMin = node.Sibling;
        Consolidate();
      }

      myCount--;
      return new Pair<T, Q>(node.Data, node.Value);
    }

    protected void Consolidate()
    {
      
    }


    protected Node[] Group()
    {
      Node[] A = new Node[Count+1];

      Node next = null;
      for (Node node = myMin; next == null || node != myMin; node = next)
      {
        Node x = node;
        next = x.Sibling;

        int d = node.Degree;
        while (A[d] != null)
        {
          Node y = A[d];
          if (x.Value.CompareTo(y.Value) > 0)
            Swap(ref x, ref y);

          if (y.PrevSibling == y)
          {
            throw new ArgumentException();
          } else
          {
            y.PrevSibling.Sibling = y.Sibling;
            y.Sibling.PrevSibling = y.PrevSibling;
          }


          if (x.Child == null)
          {
            x.Child = y;            
          } else
          {
            y.Sibling = x.Child;
            x.Child.PrevSibling = y;

            y.PrevSibling = x.Child.PrevSibling;
            x.Child.PrevSibling.Sibling = y;            
          }

          y.Parent = x;
          y.Degree = x.Degree + 1;
        }
      }
      return A;
    }

    public int Count
    {
      get { return myCount; }
    }

    private static void Swap<T>(ref T a, ref T b)
    {
      T c = a;
      a = b;
      b = c;
    }

    protected class Node
    {
      public Node Parent;
      public Node Child;
      public Node Sibling;
      public Node PrevSibling;
      public int Degree;
      public bool Mark;
      public readonly T Data;
      public readonly Q Value;

      public Node(T data, Q value)
      {
        Data = data;
        Value = value;
      }
    }
  }
}