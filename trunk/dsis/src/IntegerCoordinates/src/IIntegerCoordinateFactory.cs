using DSIS.Core.System;

namespace DSIS.IntegerCoordinates
{
  public interface IIntegerCoordinateFactory
  {
    IIntegerCoordinateSystemInfo Create(ISystemSpace space, long[] subd);
  }
}