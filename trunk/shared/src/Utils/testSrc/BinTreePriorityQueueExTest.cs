using System;
using System.Text;
using NUnit.Framework;

namespace DSIS.Utils
{
  [TestFixture]
  public class BinTreePriorityQueueExTest
  {
    private Queue queue;

    [SetUp]
    public void SetUp()
    {
      queue = new Queue();
    }

    [Test]
    public void Test_01()
    {
      Assert.AreEqual(null, queue.Min);      
    }
    
    [Test]
    public void Test_02()
    {
      queue.AddNode(1, "a");
      Assert.AreEqual("a", queue.Min);      
    }
    
    [Test]
    public void Test_03()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "b");
      Assert.AreEqual("a", queue.Min);      
    }
    
    [Test]
    public void Test_04()
    {
      queue.AddNode(1, "a");
      queue.AddNode(-2, "b");
      Assert.AreEqual("b", queue.Min);      
    }

    [Test]
    public void Test_05()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "b");
      queue.AddNode(3, "c");
      Assert.AreEqual("a", queue.Min);
    }


    [Test]
    public void Test_06()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "b");
      queue.AddNode(-3, "c");
      Assert.AreEqual("c", queue.Min);
    }
    
    [Test]
    public void Test_07()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "b");
      queue.AddNode(-3, "c");
      queue.AddNode(4, "d");
      Assert.AreEqual("c", queue.Min);
    }
    
    [Test]
    public void Test_08()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "b");
      queue.AddNode(-3, "c");
      queue.AddNode(4, "d");
      queue.AddNode(-4, "e");
      Assert.AreEqual("e", queue.Min);
    }

    [Test, ExpectedException(typeof(ArgumentException))]
    public void Test_11()
    {
      queue.ExtractMin();
    }
    
    [Test]
    public void Test_12()
    {
      queue.AddNode(1, "a");
      Assert.AreEqual(1, queue.ExtractMin().Second);
    }

    [Test, ExpectedException(typeof(ArgumentException))]
    public void Test_13()
    {
      queue.AddNode(1, "a");
      Assert.AreEqual(1, queue.ExtractMin().Second);
      queue.ExtractMin();
    }
    
    [Test]
    public void Test_14()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "a");
      Assert.AreEqual(1, queue.ExtractMin().Second);
      queue.ExtractMin();
    }

    [Test, ExpectedException(typeof(ArgumentException))]
    public void Test_15()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "a");
      Assert.AreEqual(1, queue.ExtractMin().Second);
      queue.ExtractMin();
      queue.ExtractMin();
    }

    private class Queue : BinTreePriorityQueueEx<string, int>
    {
      public string Min
      {
        get { return myMin == null ? null : myMin.Data; }
      }

      public void AssertConsolidateGroup(string data)
      {
        
      }

      private static void DumpTree(string so, int offset, Node node, StringBuilder sb)
      {
        sb.AppendFormat("{2}{0, 3}. {1}", offset, node, so);
        sb.AppendFormat("d={0}", node.Degree);
        sb.AppendLine();
        for (Node n = node.Child; n != null; n = n.Sibling)
          DumpTree("  " + so, offset + 1, n, sb);
      }

      internal string Dump()
      {
        StringBuilder sb = new StringBuilder();
        for (Node node = myMin; node != null; node = node.Sibling)
        {
          DumpTree("", 0, node, sb);
        }

        return sb.ToString();
      }

    }
  }
}