using DSIS.Graph.Abstract;
using DSIS.Graph.Tests.Generic;
using DSIS.IntegerCoordinates;

namespace DSIS.Graph.Tests.Generic
{
  public abstract class StrongComponentStrongComponentManagerBaseTest<T,Q> : StrongComponentGraphBaseTest<T,Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate
  {
    protected override StrongComponentGraph<Q> CreateGraph(T system)
    {
      return new StrongComponentGraph<Q>(system, new StrongComponentInfoManager());
    }
  }
}