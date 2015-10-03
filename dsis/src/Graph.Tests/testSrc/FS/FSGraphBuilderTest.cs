using System.Linq;
using DSIS.Graph.FS;
using DSIS.IntegerCoordinates.Impl;
using DSIS.IntegerCoordinates.Tests;
using NUnit.Framework;

namespace DSIS.Graph.Tests.FS
{
  [TestFixture]
  public class FSGraphBuilderTest
  {
    [Test]
    public void TestEmptyGraph()
    {
      var system = new IntegerCoordinateSystem(new MockSystemSpace(1, 0, 1, 1000));
      var g = new FSGraphBuilder<IntegerCoordinate>(
        system,
        system,
        new FSGraphObjectManagerImpl(new MemoryFSGraphResourceManagerImpl())
        );

      g.Dispose();

      var finished = g.BuildFinished();

      Assert.AreEqual(0, finished.Nodes.Count());
    }

    public void TestOneNode()
    {
      //TODO: Create abstract DoTest method to try graph with different ICS.
    }
  }
}