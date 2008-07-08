using DSIS.Core.System;

namespace DSIS.IntegerCoordinates
{
  public interface IIntegerCoordinateFactory
  {
    IIntegerCoordinateSystem Create(ISystemSpace space, long[] subd);
  }
}