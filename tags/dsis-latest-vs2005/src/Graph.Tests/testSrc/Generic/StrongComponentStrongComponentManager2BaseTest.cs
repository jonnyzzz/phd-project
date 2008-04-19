using DSIS.Graph.Abstract;
using DSIS.IntegerCoordinates;

namespace DSIS.Graph.Tests.Generic
{
  public abstract class StrongComponentStrongComponentManager2BaseTest<T,Q> : StrongComponentGraphBaseTest<T,Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate
  {
    protected override StrongComponentGraph<Q> CreateGraph(T system)
    {
      return new StrongComponentGraph<Q>(system, new StrongComponentInfoManager2());
    }
  }
}