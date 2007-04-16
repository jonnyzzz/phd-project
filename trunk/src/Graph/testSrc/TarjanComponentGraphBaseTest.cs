using System;
using System.Collections.Generic;
using DSIS.Graph.Abstract;
using DSIS.IntegerCoordinates;
using NUnit.Framework;

namespace DSIS.Graph
{
  public abstract class TarjanComponentGraphBaseTest<T,Q> : ComponentGraphTestBase<T,Q, TarjanGraph<Q>>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {
    public const uint COMPONENT_ID_TEST = 1 << 20 - 1;

    protected override TarjanGraph<Q> CreateGraph(T system)
    {
      return new TarjanGraph<Q>(system);
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
      CreateNode();
      ComputeComponents();
      Assert.AreEqual(0, myComponents.ComponentCount);
    }

    [Test]
    public void Test_03()
    {
      ComputeComponents();

      List<INode<Q>> l
        = new List<INode<Q>>(myComponents.GetNodes(new List<IStrongComponentInfo>()));
      Assert.AreEqual(0, l.Count);
    }

    [Test]
    public void Test_04()
    {
      CreateNode();
      ComputeComponents();
      Assert.AreEqual(0, myComponents.ComponentCount);
    }


    [Test]
    public void Test_05()
    {
      INode<Q> n1 = myGraph.AddNode(CreateCoordinate(1));
      INode<Q> n2 = myGraph.AddNode(CreateCoordinate(1));
      Assert.AreEqual(n1, n2);
      Assert.AreSame(n1, n2);
      ComputeComponents();
      Assert.AreEqual(1, myGraph.NodesCount);
      Assert.AreEqual(0, myComponents.ComponentCount);
    }

    [Test]
    public void Test_06()
    {
      CreateNode();
      CreateNode();
      ComputeComponents();
      Assert.AreEqual(0, myComponents.ComponentCount);
    }

    [Test]
    public void Test_07()
    {
      INode<Q> n1 = CreateNode();
      INode<Q> n2 = CreateNode();

      myGraph.AddEdgeToNode(n1, n2);
      ComputeComponents();
      Assert.AreEqual(0, myComponents.ComponentCount);
    }

    [Test]
    public void Test_08_2CellsInLoop()
    {
      DoTest(delegate
               {
                 INode<Q> n1 = CreateNode();
                 INode<Q> n2 = CreateNode();
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
                   int count = new List<INode<Q>>(myComponents.GetNodes(infos)).Count;
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
                   Assert.AreEqual(183, new List<INode<Q>>(myComponents.GetNodes(infos)).Count);
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
      TarjanNode<Q> node = (TarjanNode<Q>) CreateNode();
      node.ComponentId = COMPONENT_ID_TEST;
      Assert.AreEqual(COMPONENT_ID_TEST, node.ComponentId);
    }

    [Test]
    public void TestTarjanNode_02()
    {
      TarjanNode<Q> node = (TarjanNode<Q>) CreateNode();
      node.SetFlag(TarjanNodeFlags.ROUTE, true);
      node.ComponentId = COMPONENT_ID_TEST;
      Assert.AreEqual(COMPONENT_ID_TEST, node.ComponentId);
    }

    [Test]
    public void TestTarjanNode_03()
    {
      TarjanNode<Q> node = (TarjanNode<Q>) CreateNode();
      node.ComponentId = COMPONENT_ID_TEST;
      node.SetFlag(TarjanNodeFlags.ROUTE, true);
      Assert.AreEqual(COMPONENT_ID_TEST, node.ComponentId);
    }

    [Test]
    public void TestTarjanNode_04()
    {
      TarjanNode<Q> node = (TarjanNode<Q>) CreateNode();
      node.ComponentId = COMPONENT_ID_TEST;
      node.SetFlag(TarjanNodeFlags.ROUTE, true);
      node.SetFlag(TarjanNodeFlags.STACK, false);
      Assert.AreEqual(COMPONENT_ID_TEST, node.ComponentId);
    }
  }
}