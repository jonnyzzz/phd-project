using DSIS.Graph.Generic;
using DSIS.IntegerCoordinates.Generated;
using NUnit.Framework;

namespace DSIS.Graph.Generated
{
  [TestFixture]
  public class StrongComponentStrongComponentManager2dTest :
    StrongComponentStrongComponentManagerBaseTest<IntegerCoordinateSystem2d, IntegerCoordinate2d>
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