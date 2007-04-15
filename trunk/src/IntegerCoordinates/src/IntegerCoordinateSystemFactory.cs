using DSIS.Core.System;

namespace DSIS.IntegerCoordinates
{
  public static class IntegerCoordinateSystemFactory
  {
    public static IIntegerCoordinateSystem<IntegerCoordinate> Create(ISystemSpace systemSpace, long[] subdivision)
    {
      return new IntegerCoordinateSystem(systemSpace, subdivision);
    }

    public static IIntegerCoordinateSystem<IntegerCoordinate> Create(ISystemSpace systemSpace)
    {
      return new IntegerCoordinateSystem(systemSpace);
    }

  }
}