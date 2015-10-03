using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Linq;

namespace DSIS.Utils.Tests
{
  [TestFixture]
  public class BinTreePriorityQueueExEventsTest
  {
    private MyQueue q;

    [SetUp]
    public void SetUp()
    {
      q = new MyQueue();
    }

    [TearDown]
    public void TearDown()
    {
      q = null;
    }

    [Test]
    public void Test_ExtractMin()
    {
      q.Enqueue(10);
      q.Enqueue(112);

      q.GetLog();

      q.ExtractMin();

      AssertLog("Node 10. Removed");
    }

    [Test]
    public void Test_Added()
    {
      q.Enqueue(10);
      
      AssertLog("Node 10. Added");
    }

    [Test]
    public void Test_Removed()
    {
      q.Enqueue(10);
      q.GetLog();
      q.RemoveLastAdded();
      
      AssertLog("Node 10. Removed");
    }

    private void AssertLog(string log)
    {
      Func<string, string> Prepare =
        s =>
        s.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
        .Select(x => x.Trim())
        .Where(x => x.Length > 0)
        .JoinString(Environment.NewLine);

      string actual = Prepare(q.GetLog());
      string expected = Prepare(log);

      try
      {
        Assert.AreEqual(expected, actual);
      } catch
      {
        Console.Out.WriteLine("actual = {0}", actual);
        throw;
      }
    }

    private class MyQueue : BinTreePriorityQueueEx<int, int>
    {
      private StringBuilder myBuilder = new StringBuilder();
      private Node myLastAddedNode;

      public MyQueue() : base(Comparer<int>.Default)
      {
      }

      public void Enqueue(int v)
      {
        AddNode(v,v);
      }

      public void RemoveLastAdded()
      {
        Assert.That(myLastAddedNode, Is.Not.Null);
        Remove(myLastAddedNode);
      }

      protected override void NodeAdded(Node node)
      {
        myLastAddedNode = node;
        base.NodeAdded(node);
        myBuilder.AppendFormat("Node {0}. Added", node.Value);
        myBuilder.AppendLine();
      }

      protected override void NodeRemoved(Node node)
      {
        myLastAddedNode = null;
        base.NodeRemoved(node);
        myBuilder.AppendFormat("Node {0}. Removed", node.Value);
        myBuilder.AppendLine();
      }

      public string GetLog()
      {
        var s = myBuilder.ToString();
        myBuilder = new StringBuilder();
        return s;
      }
    }
  }
}