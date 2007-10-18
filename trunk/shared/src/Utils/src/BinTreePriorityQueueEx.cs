using System;
using System.Collections.Generic;

namespace DSIS.Utils
{
  public class BinTreePriorityQueueEx<T, Q>
  {
    private readonly IComparer<Q> myComparer;

    private Q myMinValue = default(Q);
    protected Node myMin;
    private int myCount;

    public BinTreePriorityQueueEx(IComparer<Q> comparer)
    {
      myComparer = comparer;
    }

    public object AddNode(Q value, T data)
    {
      Node node = new Node(data, value);

      if (myMin == null)
      {
        myMinValue = value;
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

        if (myComparer.Compare(value, myMinValue) < 0)
        {
          myMinValue = value;
          myMin = node;
        }
      }

      myCount++;
      return node;
    }

    public Pair<T, Q> ExtractMin()
    {
      if (myMin == null)
        throw new ArgumentException("No elemets");

      Node node = myMin;
      if (myMin.PrevSibling == myMin)
      {
        if (myMin.Child == null)
        {
          myMin = null;
        }
        else
        {
          Node n = myMin.Child;
          n.Parent = null;
          for (Node q = n.Sibling; q != n; q = q.Sibling)
            q.Parent = null;

          myMin = myMin.Child;
          myMinValue = myMin.Value;
        }
      }
      else
      {
        Node mBegin = myMin.PrevSibling;
        Node mEnd = myMin.Sibling;

        if (myMin.Child == null)
        {
          mBegin.Sibling = mEnd;
          mEnd.PrevSibling = mBegin;
        }
        else
        {
          Node cBegin = myMin.Child;
          Node cEnd = myMin.Child.PrevSibling;

          cEnd.Sibling = null;
          for (Node tmp = cBegin; tmp != null; tmp = tmp.Sibling)
            tmp.Parent = null;

          mBegin.Sibling = cBegin;
          cBegin.PrevSibling = mBegin;

          cEnd.Sibling = mEnd;
          mEnd.PrevSibling = cEnd;
        }

        myMin = mEnd;
        myMinValue = myMin.Value;
      }

      Consolidate();

      myCount--;
      return new Pair<T, Q>(node.Data, node.Value);
    }

    protected void Consolidate()
    {
      if (myMin != null)
        Join(Group());
    }

    private void Join(Node[] nodes)
    {
      myMin = null;
      Q minValue = default(Q);
      for (int i = 0; i < nodes.Length; i++)
      {
        Node node = nodes[i];
        if (node == null)
          continue;

        if (myMin == null)
        {
          myMin = node;
          node.Sibling = node.PrevSibling = node;
          minValue = node.Value;
        }
        else
        {
          Node mBegin = myMin;
          Node mEnd = myMin.Sibling;

          mBegin.Sibling = node;
          node.PrevSibling = mBegin;

          mEnd.PrevSibling = node;
          node.Sibling = mEnd;

          if (myComparer.Compare(minValue, node.Value) > 0)
          {
            minValue = node.Value;
            myMin = node;
          }
        }
      }
      myMinValue = minValue;
    }

    protected Node[] Group()
    {
      if (myMin == null)
        return null;

      Node[] A = new Node[Log2Helper.Nearest(Count)];

      myMin.PrevSibling.Sibling = null;
      Node next;
      for (Node node = myMin; node != null; node = next)
      {
        next = node.Sibling;
        if (node.Parent != null)
          continue;

        ConsolidateNode(node, A);
      }
      return A;
    }

    private void ConsolidateNode(Node x, Node[] A)
    {
      int d = x.Degree;
      while (A[d] != null)
      {
        Node y = A[d];
        if (myComparer.Compare(x.Value, y.Value) > 0)
          Swap(ref x, ref y);

        if (x.Child == null)
        {
          x.Child = y;
          y.Sibling = y.PrevSibling = y;
        }
        else
        {
          Node xBegin = x.Child;
          Node xEnd = x.Child.Sibling;

          xBegin.Sibling = y;
          y.Sibling = xEnd;

          xEnd.PrevSibling = y;
          y.PrevSibling = xBegin;
        }

        y.Mark = false;
        y.Parent = x;
        x.Degree++;

        A[d++] = null;
      }
      A[d] = x;
    }

    protected void Remove(Node node)
    {
      if (node.Parent == null && node.Child == null)
      {
        if (myMin == null && node.Sibling == node)
          myMin = null;
        else
        {
          Node nBegin = node.PrevSibling;
          Node nEnd = node.Sibling;

          nBegin.Sibling = nEnd;
          nEnd.PrevSibling = nBegin;
        }
      }
      else
      {
        if (node.Parent != null)
          RemoveAndAdd(node);
        else
          RemoveAndAddRoot(node);
      }

      Consolidate();
    }

    private void RemoveAndAdd(Node node)
    {
      Node parent = node.Parent;

      if (node.Sibling == node)
      {
        parent.Child = null;
      }
      else
      {
        Node lC = node.PrevSibling;
        Node rC = node.Sibling;

        lC.Sibling = rC;
        rC.PrevSibling = lC;
      }

      if (node.Child == null)
        return;

      Node l = node.Child.Sibling;
      Node r = node.Child;

      r.Sibling = null;
      for (Node n = l; n != null; n = n.Sibling)
        n.Parent = null;

      Node minL = myMin;
      Node minR = myMin.Sibling;

      minL.Sibling = l;
      l.PrevSibling = minL;

      r.Sibling = minR;
      minR.PrevSibling = r;

      parent.Degree--;

      if (!parent.Mark)
        parent.Mark = true;
      else
        MoveToTop(parent);
    }
    
    private void RemoveAndAddRoot(Node node)
    {
      if (node.Sibling == node)
      {
        myMin = node.Child;
      }
      else
      {
        Node lC = node.PrevSibling;
        Node rC = node.Sibling;

        lC.Sibling = rC;
        rC.PrevSibling = lC;
      }

      if (node.Child == null)
        return;

      Node l = node.Child.Sibling;
      Node r = node.Child;

      r.Sibling = null;
      for (Node n = l; n != null; n = n.Sibling)
        n.Parent = null;

      Node minL = myMin;
      Node minR = myMin.Sibling;

      minL.Sibling = l;
      l.PrevSibling = minL;

      r.Sibling = minR;
      minR.PrevSibling = r;     
    }

    private void MoveToTop(Node node)
    {
      Node parent = node.Parent;
      while (parent != null)
      {
        Node l = myMin;
        Node r = myMin.Sibling;

        node.Parent = null;
        l.Sibling = node;
        node.PrevSibling = l;

        node.Sibling = r;
        r.PrevSibling = node;

        if (parent.Mark)
        {
          node = parent;
          parent = node.Parent;
        }
        else
        {
          parent.Mark = true;
          break;
        }
      }
    }

    public int Count
    {
      get { return myCount; }
    }

    private static void Swap<W>(ref W a, ref W b)
    {
      W c = a;
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


      public override string ToString()
      {
        return string.Format("{0}({1})", Data, Value);
      }
    }
  }
}