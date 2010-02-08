using System;

namespace DSIS.IntegerCoordinates
{
  public interface IIntegerCoordinateFactoryEx : IIntegerCoordinateFactory
  {
    Type System { get; }
    Type Coordinate { get; }
  }
}