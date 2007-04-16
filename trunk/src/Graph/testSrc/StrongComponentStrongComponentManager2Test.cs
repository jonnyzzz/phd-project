using DSIS.Graph.Abstract;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Generated;
using DSIS.IntegerCoordinates.Impl;
using NUnit.Framework;

namespace DSIS.Graph.Test
{
  public abstract class StrongComponentStrongComponentManager2Test<T,Q> : StrongComponentGraphTest<T,Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {
    protected override StrongComponentGraph<Q> CreateGraph(T system)
    {
      return new StrongComponentGraph<Q>(system, new StrongComponentInfoManager2());
    }
  }

  [TestFixture]
  public class StrongComponentStrongComponentManager2Test : 
    StrongComponentStrongComponentManager2Test<IntegerCoordinateSystem, IntegerCoordinate>
  {

  }

  [TestFixture]
  public class StrongComponentStrongComponentManager22dTest : 
    StrongComponentStrongComponentManager2Test<IntegerCoordinateSystem2d, IntegerCoordinate2d>
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