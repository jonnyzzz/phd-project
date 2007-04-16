using System;
using DSIS.Core.System;
using DSIS.IntegerCoordinates.Generated;
using DSIS.IntegerCoordinates.Impl;

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


    public static T CreateCoordinateSystem<T, Q>(ISystemSpace ss)
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate<Q>
    {
      if (typeof(T) == typeof(IntegerCoordinateSystem)) {
        return (T)(object)new IntegerCoordinateSystem(ss);
      } else if (typeof(T) == typeof(IntegerCoordinateSystem2d)) {
        return (T) (object) new IntegerCoordinateSystem2d(ss);
      } else
      {
        throw new ArgumentException("Unexpected type");
      }
    }

  }
}