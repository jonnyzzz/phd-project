using System.Collections.Generic;
using System.IO;

namespace DSIS.Utils
{
  public abstract class BinTreePriorityQueueExDebugDouble<T> : BinTreePriorityQueueExDebug<T,double>
  {
    protected BinTreePriorityQueueExDebugDouble(IComparer<double> comparer) : base(comparer)
    {
    }

    protected override string ToStringQ(double q)
    {
      return q.ToString("G");
    }
  }

  public abstract class BinTreePriorityQueueExDebug<T,Q> : BinTreePriorityQueueEx<T,Q>
  {
    private static int myIndex;
    private readonly TextWriter Out;
    private int myCount;

    protected BinTreePriorityQueueExDebug(IComparer<Q> comparer) : base(comparer)
    {
      Out = File.CreateText(string.Format("e:\\dump_{0}.txt", myIndex++));
    }

    protected virtual string ToStringQ(Q q)
    {
      return q.ToString();      
    }
    
    protected virtual string ToStringT(T t)
    {
      return t.ToString();      
    }

    protected new void AddNode(Q value, T data)
    {
      Out.WriteLine("{1,3}.Add {0} |{2}", data, myCount++, value);
      Out.Flush();  
      base.AddNode(value, data);
    }

    protected new void Remove(Node node)
    {
      Out.WriteLine("{1,3}.Rem {0} |{2}", node.Data, myCount++, node.Value);
      Out.Flush();
      base.Remove(node);
    }

    public new Pair<T,Q> ExtractMin()
    {
      Out.Write("{0,3}.Max ", myCount++);
      Out.Flush();
      try
      {
        Pair<T, Q> min = base.ExtractMin();
        Out.Write("{0} |{1}", min.First, min.Second);
        return min;
      }
      finally
      {
        Out.WriteLine();
        Out.Flush();
      }
    }
  }
}