using DSIS.Graph.Abstract;
using DSIS.IntegerCoordinates;
using NUnit.Framework;

namespace DSIS.Graph.Test
{
  [TestFixture]
  public class StrongComponentStrongComponentManagerTest : StrongComponentGraphTest
  {
    protected override IGraphWithStrongComponent<IntegerCoordinate, int> CreateGraph()
    {
      return new StrongComponentGraph<IntegerCoordinate, int>(mySystem, new StrongComponentInfoManager());
    }
  }
}