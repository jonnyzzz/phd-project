using DSIS.Graph.Abstract;
using DSIS.IntegerCoordinates;

namespace DSIS.Graph.Generic
{
  public abstract class StrongComponentStrongComponentManagerBaseTest<T,Q> : StrongComponentGraphBaseTest<T,Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {
    protected override StrongComponentGraph<Q> CreateGraph(T system)
    {
      return new StrongComponentGraph<Q>(system, new StrongComponentInfoManager());
    }
  }
}