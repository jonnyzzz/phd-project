using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.IntegerCoordinates.Impl;
using DSIS.Utils;
using NUnit.Framework;

namespace DSIS.Graph.Tests
{
  [TestFixture]
  public class GraphProjectorTest : GraphTestBase<TarjanGraph<IntegerCoordinate>, TarjanNode<IntegerCoordinate>>
  {
    protected override TarjanGraph<IntegerCoordinate> CreateGraph(IntegerCoordinateSystem ics)
    {
      return new TarjanGraph<IntegerCoordinate>(ics);
    }

    private ICellCoordinateSystemProjector<IntegerCoordinate> myProjector;

    public override void SetUp()
    {
      base.SetUp();
      myProjector = myGraph.CoordinateSystem.Project(2L.Fill(myGraph.CoordinateSystem.Dimension));
    }

    [Test]
    public void Test_01()
    {
      n(1);
      var proj = (TarjanGraph<IntegerCoordinate>)myGraph.Project(myProjector);
      an(proj, 0);
    }

    [Test]
    public void Test_02()
    {
      n(1, 8);
      var proj = (TarjanGraph<IntegerCoordinate>)myGraph.Project(myProjector);
      an(proj, 0);
      an(proj, 4);
      an(proj, 0, 4);
    }
    
    [Test]
    public void Test_03()
    {
      n(3,2);
      var proj = (TarjanGraph<IntegerCoordinate>)myGraph.Project(myProjector);
      an(proj, 1);
      an(proj, 1, 1);
    }
  }
}