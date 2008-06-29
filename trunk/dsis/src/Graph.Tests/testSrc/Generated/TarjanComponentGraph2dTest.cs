using DSIS.Graph.Tests.Generic;
using DSIS.IntegerCoordinates.Generated;
using NUnit.Framework;

namespace DSIS.Graph.Tests.Generated
{
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