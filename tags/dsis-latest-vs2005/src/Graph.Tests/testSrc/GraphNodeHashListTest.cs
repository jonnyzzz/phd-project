using System.Collections.Generic;
using DSIS.Graph.Abstract;
using DSIS.IntegerCoordinates.Impl;
using NUnit.Framework;

namespace DSIS.Graph
{
  [TestFixture]
  public class GraphNodeHashListTest
  {
    [Test]
    public void Test_1000_10()
    {
      doTest(10, 1000);
    }
    
    [Test]
    public void Test_1000_1()
    {
      doTest(1, 1000);
    }

    [Test]
    public void Test_1000_1000()
    {
      doTest(1000, 1000);
    }

    [Test]
    public void Test_1_10000()
    {
      doTest(1000, 1);
    }
        
    private static void doTest(int hash, int N)
    {
      GraphList list = new GraphList(hash);      
      List<long> data = new List<long>();
      for(int i = 0; i < N; i++)
      {
        data.Add(i);
        FakeNode node = new FakeNode(i);
        Assert.IsTrue(list.AddIfNotReplace(ref node));
      }

      List<FakeNode> fakeNodes = new List<FakeNode>(list.Values);
      List<long> nodes = fakeNodes.ConvertAll<long>(delegate(FakeNode node)
                                                                            {
                                                                              return node.Coordinate.GetCoordinate(0);
                                                                            });

      nodes.Sort();
      data.Sort();

      Assert.AreEqual(data.Count, nodes.Count);

      for(int i=0; i<data.Count; i++)
      {
        Assert.AreEqual(data[i], nodes[i]);
      }
    }


    private class GraphList : GraphNodeHashList<FakeNode, IntegerCoordinate>
    {
      public GraphList(int capacity) : base(capacity)
      {
      }
    }

    private class FakeNode : Node<FakeNode, IntegerCoordinate>
    {
      public FakeNode(long coordinate) : base(new IntegerCoordinate(coordinate))
      {
      }
    }
  }
}
