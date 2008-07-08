using System;
using DSIS.Core.System;

namespace DSIS.IntegerCoordinates.Generated
{
  public class IntegerCoordinateSystem2dFactory : IIntegerCoordinateFactoryEx
  {    
    public void WithIntegerCoordinateSystem(IIntegerCoordinateCallback cb)
    {
      cb.Do<IntegerCoordinateSystem2d, IntegerCoordinate2d>(
        delegate(ISystemSpace ss, long[] subd) { return new IntegerCoordinateSystem2d(ss,subd);
        });
    }

    public Type System
    {
      get { return typeof(IntegerCoordinateSystem2d); }
    }

    public Type Coordinate
    {
      get { return typeof (IntegerCoordinate2d); }
    }

    public IIntegerCoordinateSystem Create(ISystemSpace space, long[] subd)
    {
      return new IntegerCoordinateSystem2d(space, subd);
    }
  }
}