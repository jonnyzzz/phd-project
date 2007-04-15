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
      IIntegerCoordinateSystem<IntegerCoordinate> cs = IntegerCoordinateSystemFactory.Create(new MockSystemSpace(1, 0, 1, 1000));
      new SimpleGraph<IntegerCoordinate>(cs);
    }
  }

  [TestFixture]
  public class TarjanComponentGraphTest : ComponentGraphTestBase
  {
    public const uint COMPONENT_ID_TEST = 1 << 20 - 1;
    private new TarjanGraph<IntegerCoordinate> myGraph;

    public override void SetUp()
    {
      base.SetUp();
      myGraph = (TarjanGraph<IntegerCoordinate>) base.myGraph;
    }

    protected override IGraphWithStrongComponent<IntegerCoordinate> CreateGraph()
    {
      return new TarjanGraph<IntegerCoordinate>(mySystem);
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
      myGraph.AddNode(mySystem.Create(1));
      ComputeComponents();
      Assert.AreEqual(0, myComponents.ComponentCount);
    }

    [Test]
    public void Test_03()
    {
      ComputeComponents();

      List<INode<IntegerCoordinate>> l
        = new List<INode<IntegerCoordinate>>(myComponents.GetNodes(new List<IStrongComponentInfo>()));
      Assert.AreEqual(0, l.Count);
    }

    [Test]
    public void Test_04()
    {
      myGraph.AddNode(mySystem.Create(1));
      ComputeComponents();
      Assert.AreEqual(0, myComponents.ComponentCount);
    }


    [Test]
    public void Test_05()
    {
      INode<IntegerCoordinate> n1 = myGraph.AddNode(mySystem.Create(1));
      INode<IntegerCoordinate> n2 = myGraph.AddNode(mySystem.Create(1));
      Assert.AreEqual(n1, n2);
      Assert.AreSame(n1, n2);
      ComputeComponents();
      Assert.AreEqual(1, myGraph.NodesCount);
      Assert.AreEqual(0, myComponents.ComponentCount);
    }

    [Test]
    public void Test_06()
    {
      myGraph.AddNode(mySystem.Create(1));
      myGraph.AddNode(mySystem.Create(2));
      ComputeComponents();
      Assert.AreEqual(0, myComponents.ComponentCount);
    }

    [Test]
    public void Test_07()
    {
      INode<IntegerCoordinate> n1 = myGraph.AddNode(mySystem.Create(1));
      INode<IntegerCoordinate> n2 = myGraph.AddNode(mySystem.Create(2));

      myGraph.AddEdgeToNode(n1, n2);
      ComputeComponents();
      Assert.AreEqual(0, myComponents.ComponentCount);
    }

    [Test]
    public void Test_08_2CellsInLoop()
    {
      DoTest(delegate
               {
                 INode<IntegerCoordinate> n1 = myGraph.AddNode(mySystem.Create(1));
                 INode<IntegerCoordinate> n2 = myGraph.AddNode(mySystem.Create(2));
                 myGraph.AddEdgeToNode(n1, n2);
                 myGraph.AddEdgeToNode(n2, n1);
                 ComputeComponents();
                 Assert.AreEqual(1, myComponents.ComponentCount);
                 Assert.AreEqual(2, OneComponent[0].NodesCount);
               });
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
                   int count = new List<INode<IntegerCoordinate>>(myComponents.GetNodes(infos)).Count;
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
                 BuildCircle(200, 2, 100);

                 ComputeComponents();

                 Assert.AreEqual(1, myComponents.ComponentCount);
                 foreach (IStrongComponentInfo info in myComponents.Components)
                 {
                   List<IStrongComponentInfo> infos = new List<IStrongComponentInfo>();
                   infos.Add(info);
                   Console.Out.WriteLine(info);
                   Assert.AreEqual(183, new List<INode<IntegerCoordinate>>(myComponents.GetNodes(infos)).Count);
                 }
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
    public void Test_Circle_918()
    {
      DoCircleTest(918);
    }

    [Test]
    public void TestTarjanNode_01()
    {
      TarjanNode<IntegerCoordinate> node = new TarjanNode<IntegerCoordinate>(mySystem.Create(3));
      node.ComponentId = COMPONENT_ID_TEST;
      Assert.AreEqual(COMPONENT_ID_TEST, node.ComponentId);
    }

    [Test]
    public void TestTarjanNode_02()
    {
      TarjanNode<IntegerCoordinate> node = new TarjanNode<IntegerCoordinate>(mySystem.Create(3));
      node.SetFlag(TarjanNodeFlags.ROUTE, true);
      node.ComponentId = COMPONENT_ID_TEST;
      Assert.AreEqual(COMPONENT_ID_TEST, node.ComponentId);
    }

    [Test]
    public void TestTarjanNode_03()
    {
      TarjanNode<IntegerCoordinate> node = new TarjanNode<IntegerCoordinate>(mySystem.Create(3));
      node.ComponentId = COMPONENT_ID_TEST;
      node.SetFlag(TarjanNodeFlags.ROUTE, true);
      Assert.AreEqual(COMPONENT_ID_TEST, node.ComponentId);
    }

    [Test]
    public void TestTarjanNode_04()
    {
      TarjanNode<IntegerCoordinate> node = new TarjanNode<IntegerCoordinate>(mySystem.Create(3));
      node.ComponentId = COMPONENT_ID_TEST;
      node.SetFlag(TarjanNodeFlags.ROUTE, true);
      node.SetFlag(TarjanNodeFlags.STACK, false);
      Assert.AreEqual(COMPONENT_ID_TEST, node.ComponentId);
    }
  }
}