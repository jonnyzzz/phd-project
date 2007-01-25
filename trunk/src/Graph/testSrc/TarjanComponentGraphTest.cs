using System;
using System.Collections.Generic;
using DSIS.Graph.Abstract;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Tests;
using NUnit.Framework;

namespace DSIS.Graph.Test
{
  [TestFixture]
  public class FakeTest
  {
    [Test]
    public void Test()
    {
      IntegerCoordinateSystem cs = new IntegerCoordinateSystem(new MockSystemSpace(1, 0, 1, 1000));
      new SimpleGraph<IntegerCoordinate, object>(cs);
    }
  }
  [TestFixture]
  public class TarjanComponentGraphTest : ComponentGraphTestBase
  {
    private new TarjanGraph<IntegerCoordinate, int> myGraph;
    public override void SetUp()
    {
      base.SetUp();
      myGraph = (TarjanGraph<IntegerCoordinate, int>) base.myGraph;
    }

    protected override IGraphWithStrongComponent<IntegerCoordinate, int> CreateGraph()
    {
      return new TarjanGraph<IntegerCoordinate, int>(mySystem);
    }


    [Test]
    public void Test_01()
    {
      ComputeComponents();
      Assert.AreEqual(0, myComponents.ComponentCount);
    }

    [Test]
    public void Test_02()
    {
      myGraph.AddNode(new IntegerCoordinate(1));
      ComputeComponents();
      Assert.AreEqual(0, myComponents.ComponentCount);
    }

    [Test]
    public void Test_03()
    {
      ComputeComponents();

      foreach (INode<IntegerCoordinate, int> node in myComponents.GetNodes(new List<IStrongComponentInfo>()))
      {
        Assert.Fail("No node is expected");
      }
    }

    [Test]
    public void Test_04()
    {
      myGraph.AddNode(new IntegerCoordinate(1));
      ComputeComponents();
      Assert.AreEqual(0, myComponents.ComponentCount);
    }


    [Test]
    public void Test_05()
    {
      INode<IntegerCoordinate, int> n1 = myGraph.AddNode(new IntegerCoordinate(1));
      INode<IntegerCoordinate, int> n2 = myGraph.AddNode(new IntegerCoordinate(1));
      Assert.AreEqual(n1, n2);
      Assert.AreSame(n1, n2);
      ComputeComponents();
      Assert.AreEqual(1, myGraph.NodesCount);
      Assert.AreEqual(0, myComponents.ComponentCount);
    }

    [Test]
    public void Test_06()
    {
      myGraph.AddNode(new IntegerCoordinate(1));
      myGraph.AddNode(new IntegerCoordinate(2));
      ComputeComponents();
      Assert.AreEqual(0, myComponents.ComponentCount);
    }

    [Test]
    public void Test_07()
    {
      INode<IntegerCoordinate, int> n1 = myGraph.AddNode(new IntegerCoordinate(1));
      INode<IntegerCoordinate, int> n2 = myGraph.AddNode(new IntegerCoordinate(2));

      myGraph.AddEdgeToNode(n1, n2);
      ComputeComponents();
      Assert.AreEqual(0, myComponents.ComponentCount);
    }

    [Test]
    public void Test_08_2CellsInLoop()
    {
      DoTest(delegate
               {
                 INode<IntegerCoordinate, int> n1 = myGraph.AddNode(new IntegerCoordinate(1));
                 INode<IntegerCoordinate, int> n2 = myGraph.AddNode(new IntegerCoordinate(2));
                 myGraph.AddEdgeToNode(n1, n2);
                 myGraph.AddEdgeToNode(n2, n1);
                 ComputeComponents();
                 Assert.AreEqual(1, myComponents.ComponentCount);
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

    [Test]
    public void Test_Circle_2_000()
    {
      DoCircleTest(2000);
    }

    [Test]
    public void Test_Circle_20_000()
    {
      DoCircleTest(20000);
    }

    [Test]
    public void Test_2Circle_100()
    {
      DoTest(delegate
               {
                 BuildCircle(0, 1, 100);
                 BuildCircle(206, 1, 100);

                 ComputeComponents();

                 Assert.AreEqual(2, myComponents.ComponentCount);

                 foreach (IStrongComponentInfo info in myComponents.Components)
                 {
                   List<IStrongComponentInfo> infos = new List<IStrongComponentInfo>();
                   infos.Add(info);
                   Console.Out.WriteLine("info = {0}", info);
                   int count = new List<INode<IntegerCoordinate, int>>(myComponents.GetNodes(infos)).Count;
                   Assert.AreEqual(100, count);
                 }
               });
    }

    [Test]
    public void Test_2Circle_200()
    {
      DoTest(delegate
               {
                 BuildCircle(0, 3, 100);
                 BuildCircle(2, 2, 100);

                 ComputeComponents();

                 Assert.AreEqual(2, myComponents.ComponentCount);
                 foreach (IStrongComponentInfo info in myComponents.Components)
                 {
                   List<IStrongComponentInfo> infos = new List<IStrongComponentInfo>();
                   infos.Add(info);
                   Console.Out.WriteLine(info);
                   Assert.AreEqual(100, new List<INode<IntegerCoordinate, int>>(myComponents.GetNodes(infos)).Count);
                 }
               });
    }

    public const uint COMPONENT_ID_TEST = 1 << 20 - 1;

    [Test]
    public void TestTarjanNode_01()
    {
      TarjanNode<IntegerCoordinate, int> node = new TarjanNode<IntegerCoordinate, int>(new IntegerCoordinate(3), 0);
      node.ComponentId = COMPONENT_ID_TEST;
      Assert.AreEqual(COMPONENT_ID_TEST, node.ComponentId);
    }

    [Test]
    public void TestTarjanNode_02()
    {
      TarjanNode<IntegerCoordinate, int> node = new TarjanNode<IntegerCoordinate, int>(new IntegerCoordinate(3), 0);
      node.SetFlag(TarjanNodeFlags.ROUTE, true);
      node.ComponentId = COMPONENT_ID_TEST;
      Assert.AreEqual(COMPONENT_ID_TEST, node.ComponentId);
    }

    [Test]
    public void TestTarjanNode_03()
    {
      TarjanNode<IntegerCoordinate, int> node = new TarjanNode<IntegerCoordinate, int>(new IntegerCoordinate(3), 0);
      node.ComponentId = COMPONENT_ID_TEST;
      node.SetFlag(TarjanNodeFlags.ROUTE, true);      
      Assert.AreEqual(COMPONENT_ID_TEST, node.ComponentId);
    }

    [Test]
    public void TestTarjanNode_04()
    {
      TarjanNode<IntegerCoordinate, int> node = new TarjanNode<IntegerCoordinate, int>(new IntegerCoordinate(3), 0);
      node.ComponentId = COMPONENT_ID_TEST;
      node.SetFlag(TarjanNodeFlags.ROUTE, true);
      node.SetFlag(TarjanNodeFlags.STACK, false);
      Assert.AreEqual(COMPONENT_ID_TEST, node.ComponentId);
    }
  }
}