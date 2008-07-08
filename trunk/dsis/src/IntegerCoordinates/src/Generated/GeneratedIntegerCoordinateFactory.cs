using System;
using DSIS.Core.System;
using DSIS.Spring;

namespace DSIS.IntegerCoordinates.Generated
{
  [UsedBySpring]
  public class GeneratedIntegerCoordinateFactory : IIntegerCoordinateFactory
  {
    private readonly GeneratedIntegerCoordinateSystemManager myManager;

    public GeneratedIntegerCoordinateFactory(GeneratedIntegerCoordinateSystemManager manager)
    {
      myManager = manager;
    }

    public IIntegerCoordinateSystem Create(ISystemSpace space, long[] subd)
    {
      if (subd.Length != space.Dimension)
        throw new ArgumentException("Dimensions of arguments shoulb be the same");

      IIntegerCoordinateFactoryEx system = myManager.CreateSystem(space.Dimension);
      return system.Create(space, subd);
    }
  }
}