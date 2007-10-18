using System;
using System.Collections.Generic;

namespace DSIS.Utils
{
  public class BinTreePriorityQueueEx<T,Q> where Q : IComparable<Q>
  {
    protected Node myMin;
    private int myCount;
    
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
          for(Node q = n.Sibling; q != n; q = q.Sibling)
          {
            q.Parent = null;
          }

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
          {
            tmp.Parent = null;
          }

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

    protected void Consolidate()
    {
      if (myMin != null)
        Join(Group());     
    }

    private List<Node> Nodes()
    {
      List<Node> nodes = new List<Node>();
      if (myMin == null)
        return nodes;

      nodes.Add(myMin);

      for(Node node = myMin.Sibling; node != myMin; node = node.Sibling)
        nodes.Add(node);

      return nodes;
    }

    private void Join(Node[] nodes)
    {
      myMin = null;

      foreach (Node node in nodes)
      {
        if (node == null)
          continue;

        if (myMin == null)
        {
          myMin = node;
          node.Sibling = node.PrevSibling = node;
        }
        else
        {
          Node mBegin = myMin;
          Node mEnd = myMin.Sibling;

          mBegin.Sibling = node;
          node.PrevSibling = mBegin;

          mEnd.PrevSibling = node;
          node.Sibling = mEnd;

          if (myMin.Value.CompareTo(node.Value) > 0)
          {
            myMin = node;
          }
        }
      }
    }

    protected Node[] Group()
    {
      if (myMin == null)
        return null;
      
      Node[] A = new Node[Count+1];

      foreach (Node node in Nodes())
      {
        if (node.Parent != null)
          continue;

        Node x = node;

        int d = node.Degree;
        while (A[d] != null)
        {
          Node y = A[d];
          if (x.Value.CompareTo(y.Value) > 0)
            Swap(ref x, ref y);
          
          if (x.Child == null)
          {
            x.Child = y;
            y.Sibling = y.PrevSibling = y;
          } else
          {
            Node xBegin = x.Child;
            Node xEnd = x.Child.Sibling;

            xBegin.Sibling = y;
            y.Sibling = xEnd;

            xEnd.PrevSibling = y;
            y.PrevSibling = xBegin;           
          }

          y.Parent = x;
          x.Degree++;
          
          A[d++] = null;
        }
        A[d] = x;
      }
      return A;
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