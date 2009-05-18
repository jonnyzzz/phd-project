using DSIS.Core.System;

namespace DSIS.IntegerCoordinates
{
  public interface IIntegerCoordinateFactory
  {
    IIntegerCoordinateSystem Create(ISystemSpace space, long[] subd);
  }

  public interface IIntegerCoordinateFactory<T, Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate
  {
    T CreateEx(ISystemSpace space, long[] subd);
  }
}