using System;
using System.Collections.Generic;

namespace DSIS.Utils
{
  public abstract class BinTreePriorityQueueEx<T, Q>
  {
    protected readonly IComparer<Q> myComparer;

    protected Node myMin;
    private int myCount;
    private bool myConsolidateRequired = false;

    public BinTreePriorityQueueEx(IComparer<Q> comparer)
    {
      myComparer = comparer;
    }

    protected virtual void NodeAdded(Node node)
    {      
    }

    protected virtual void NodeRemoved(Node node)
    {      
    }

    protected void AddNode(Q value, T data)
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
      }

      myCount++;
      Consolidate();

      NodeAdded(node);
    }

    public Pair<T, Q> ExtractMin()
    {
      if (myMin == null)
        throw new ArgumentException("No elemets");

      if (myConsolidateRequired)
        DoConsolidate();

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
      }

      Consolidate();

      myCount--;
      return new Pair<T, Q>(node.Data, node.Value);
    }

    protected void DoConsolidate()
    {
      if (myMin != null)
        Join(Group());
    }

    private void Consolidate()
    {
      myConsolidateRequired = true;
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
    }

    protected Node[] Group()
    {
      if (myMin == null)
        return null;

      var A = new Node[Log2Helper.Nearest(Count)];

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
      myCount--;

      Node parent = node.Parent;
      if (parent == null)
      {
        if (node.Sibling == node)
        {
          myMin = null;
        }
        else
        {
          if (node == myMin)
            myMin = node.Sibling;

          RemoveMe(node);
        }

        if (node.Child != null)
        {
          if (myMin != null)
            AppendList(myMin, node.Child);
          else
          {
            ZeroParent(node.Child);
            myMin = node.Child;
            node.Parent = null;
          }
        }
      }
      else
      {
        if (myMin == null)
          throw new Exception("rotten");

        if (node.Sibling == node)
        {
          parent.Child = null;
        }
        else
        {
          parent.Child = node.Sibling;
          RemoveMe(node);
        }

        if (node.Child != null)
        {
          AppendList(myMin, node.Child);
        }

        node.Parent.Degree--;

        if (node.Parent.Mark)
        {
          Node aParent = node.Parent;
          Remove(aParent);
          AddNode(aParent.Value, aParent.Data);          
        }
        else
          node.Parent.Mark = true;
      }
      
      node.Child = node.Parent = node.Sibling = node.PrevSibling = null;
      node.Degree = -1;

      NodeRemoved(node);
      Consolidate();
    }

    private static void ZeroParent(Node node)
    {
      Node prev = node.PrevSibling;
      prev.Sibling = null;

      for (Node n = node; n != null; n = n.Sibling)
        n.Parent = null;

      prev.Sibling = node;
    }

    private static void AppendList(Node reciever, Node what)
    {
      Node rBegin = reciever.PrevSibling;
      Node rEnd = reciever;

      Node whatBegin = what.PrevSibling;
      Node whatEnd = what;

      whatBegin.Sibling = null;
      for (Node n = whatEnd; n != null; n = n.Sibling)
        n.Parent = null;

      rBegin.Sibling = whatEnd;
      whatEnd.PrevSibling = rBegin;

      whatBegin.Sibling = rEnd;
      rEnd.PrevSibling = whatBegin;
    }

    private static void RemoveMe(Node node)
    {
      Node nBegin = node.PrevSibling;
      Node nEnd = node.Sibling;

      nBegin.Sibling = nEnd;
      nEnd.PrevSibling = nBegin;
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