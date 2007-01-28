using DSIS.Graph.Abstract;
using DSIS.IntegerCoordinates;
using NUnit.Framework;

namespace DSIS.Graph.Test
{
  [TestFixture]
  public class StrongComponentStrongComponentManager2Test : StrongComponentGraphTest
  {
    protected override IGraphWithStrongComponent<IntegerCoordinate> CreateGraph()
    {
      return new StrongComponentGraph<IntegerCoordinate>(mySystem, new StrongComponentInfoManager2());
    }
  }
}