using DSIS.Graph.Abstract;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Tests;
using NUnit.Framework;

namespace DSIS.Graph.Tests.Generic
{
  public abstract class SimpleGraphTestBase<T,Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate
  {
    protected SimpleGraph<Q> myGraph;
    protected T mySystem;

    [SetUp]
    public void SetUp()
    {
      MockSystemSpace space = new MockSystemSpace(Dimension, 0, 1, 100);
      mySystem = IntegerCoordinateSystemFactory.CreateCoordinateSystem<T,Q>(space);
      myGraph = new SimpleGraph<Q>(mySystem);
    }

    protected abstract int Dimension { get;}

    [TearDown]
    public void TearDown()
    {
      myGraph = null;
    }

    [Test]
    public void Test_01()
    {
      Assert.AreEqual("Graph [Nodes: 0, Edges: 0]\r\nFinished!\r\n\r\n", myGraph.Dump());
    }

    [Test]
    public void Test_02()
    {
      Assert.AreEqual("Graph [Nodes: 0, Edges: 0]", myGraph.ToString());
    }
  }
}