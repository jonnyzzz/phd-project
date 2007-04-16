using DSIS.IntegerCoordinates.Generated;
using DSIS.IntegerCoordinates.Impl;
using NUnit.Framework;

namespace DSIS.Graph
{
  [TestFixture]
  public class TarjanComponentGraphTest : TarjanComponentGraphBaseTest<IntegerCoordinateSystem, IntegerCoordinate>
  {
    
  }

  [TestFixture]
  public class TarjanComponentGraph2dTest : TarjanComponentGraphBaseTest<IntegerCoordinateSystem2d, IntegerCoordinate2d>
  {
    protected override int Dimension
    {
      get { return 2; }
    }

    protected override IntegerCoordinate2d CreateCoordinate(long nodeId, IntegerCoordinateSystem2d t)
    {
      return t.Create(nodeId, nodeId);
    }
  }
}