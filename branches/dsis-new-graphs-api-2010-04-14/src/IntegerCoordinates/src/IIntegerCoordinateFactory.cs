using DSIS.Core.System;
using DSIS.Utils;

namespace DSIS.IntegerCoordinates
{
  public interface IIntegerCoordinateFactory
  {
    IIntegerCoordinateSystem Create(ISystemSpace space, long[] subd);
  }

  [Used]
  public interface IIntegerCoordinateFactory<T, Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate
  {
    T CreateEx(ISystemSpace space, long[] subd);
  }
}