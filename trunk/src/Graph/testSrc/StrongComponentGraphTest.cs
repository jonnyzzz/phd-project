using System;
using System.Collections.Generic;
using DSIS.Graph.Abstract;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Impl;
using NUnit.Framework;

namespace DSIS.Graph.Test
{
  public abstract class StrongComponentGraphTest<T,Q> : ComponentGraphTestBase<T,Q, StrongComponentGraph<Q>>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {
    [SetUp]
    public override void SetUp()
    {
      base.SetUp();
      ComputeComponents();
    }

    [Test]
    public void Test_01()
    {
      Assert.AreEqual(0, myGraph.ComponentCount);
    }

    [Test]
    public void Test_02()
    {
      CreateNode();
      Assert.AreEqual(1, myGraph.ComponentCount);
    }

    [Test]
    public void Test_03()
    {
      IEnumerable<INode<Q>> enumerable = myGraph.GetNodes(new List<IStrongComponentInfo>());
      Assert.IsFalse(enumerable.GetEnumerator().MoveNext(), "No node is expected");
    }

    [Test]
    public void Test_04()
    {
      INode<Q> node = CreateNode();
      Assert.AreEqual(1, myGraph.ComponentCount);

      foreach (INode<Q> n in myGraph.GetNodes(OneComponent))
      {
        Assert.AreEqual(node, n);
        Assert.AreSame(node, n);
      }

      Assert.AreEqual(1, new List<INode<Q>>(myGraph.GetNodes(OneComponent)).Count);
    }


    [Test]
    public void Test_05()
    {
      INode<Q> n1 = myGraph.AddNode(CreateCoordinate(1));
      Assert.AreEqual(1, myGraph.ComponentCount);
      INode<Q> n2 = myGraph.AddNode(CreateCoordinate(1));

      Assert.AreEqual(n1, n2);
      Assert.AreSame(n1, n2);
      Assert.AreEqual(1, myGraph.NodesCount);
      Assert.AreEqual(1, myGraph.ComponentCount);
    }

    [Test]
    public void Test_06()
    {
      CreateNode();
      Assert.AreEqual(1, myGraph.ComponentCount);
      CreateNode();
      Assert.AreEqual(2, myGraph.ComponentCount);
    }

    [Test]
    public void Test_07()
    {
      INode<Q> n1 = CreateNode();
      Assert.AreEqual(1, myGraph.ComponentCount);
      INode<Q> n2 = CreateNode();
      Assert.AreEqual(2, myGraph.ComponentCount);

      myGraph.AddEdgeToNode(n1, n2);
      Assert.AreEqual(2, myGraph.ComponentCount);
    }

    [Test]
    public void Test_08_2CellsInLoop()
    {
      DoTest(delegate
               {
                 INode<Q> n1 = CreateNode();
                 Assert.AreEqual(1, myGraph.ComponentCount);
                 INode<Q> n2 = CreateNode();
                 Assert.AreEqual(2, myGraph.ComponentCount);

                 myGraph.AddEdgeToNode(n1, n2);
                 Assert.AreEqual(2, myGraph.ComponentCount);

                 myGraph.AddEdgeToNode(n2, n1);
                 Assert.AreEqual(1, myGraph.ComponentCount);
                 Assert.AreEqual(2, OneComponent[0].NodesCount);
               });
    }

    [Test]
    public void Test_Circle_002()
    {
      DoCircleTest(2);
    }

    [Test]
    public void Test_Circle_003()
    {
      DoCircleTest(3);
    }

    [Test]
    public void Test_Circle_012()
    {
      DoCircleTest(12);
    }

    [Test]
    public void Test_Circle_013()
    {
      DoCircleTest(13);
    }

    [Test]
    public void Test_Circle_018()
    {
      DoCircleTest(18);
    }

    [Test]
    public void Test_Circle_918()
    {
      DoCircleTest(918);
    }

    [Test, Ignore("Too slow")]
    public void Test_Circle_2_000()
    {
      DoCircleTest(2000);
    }

    [Test]
    public void Test_StrongComponentMerge()
    {
      INode<Q> n1 = CreateNode();
      INode<Q> n2 = CreateNode();
      INode<Q> n3 = CreateNode();
      INode<Q> n4 = CreateNode();
      INode<Q> n5 = CreateNode();

      myGraph.AddEdgeToNode(n1, n2);
      myGraph.AddEdgeToNode(n3, n2);
      myGraph.AddEdgeToNode(n4, n3);
      myGraph.AddEdgeToNode(n4, n5);
      myGraph.AddEdgeToNode(n5, n1);

      Dump();

      Assert.AreEqual(5, myComponents.ComponentCount, "Components count");

      myGraph.AddEdgeToNode(n2, n4);

      Dump();

      Assert.AreEqual(1, myComponents.ComponentCount);
    }

    [Test]
    [Ignore()]
    public void Test_StrongComponentMerge_02()
    {
      INode<Q> n1 = CreateNode();
      INode<Q> n2 = CreateNode();
      INode<Q> n3 = CreateNode();
      INode<Q> n4 = CreateNode();
      INode<Q> n5 = CreateNode();

      myGraph.AddEdgeToNode(n1, n2);
      myGraph.AddEdgeToNode(n3, n2);
      myGraph.AddEdgeToNode(n4, n3);
      myGraph.AddEdgeToNode(n4, n5);


      Dump();

      Assert.AreEqual(5, myComponents.ComponentCount, "Components count");

      myGraph.AddEdgeToNode(n2, n4);

      Dump();

      Assert.AreEqual(3, myComponents.ComponentCount);

      myGraph.AddEdgeToNode(n5, n1);
      Dump();

      Assert.AreEqual(1, myComponents.ComponentCount);
    }
  }
}