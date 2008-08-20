using System;
using DSIS.IntegerCoordinates.Generated;

namespace DSIS.IntegerCoordinates
{
  public interface IIntegerCoordinateFactoryEx : IIntegerCoordinateFactory
  {
    [Obsolete("Use IIntegerCoordinateSystem.DoWith")]
    void WithIntegerCoordinateSystem(IIntegerCoordinateCallback cb);

    Type System { get; }
    Type Coordinate { get; }
  }
}