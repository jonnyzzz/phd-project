using System;
using System.Linq;
using DSIS.Core.Ioc;
using DSIS.Core.System;
namespace DSIS.IntegerCoordinates.Generated
{
  [ComponentImplementation]
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

      IIntegerCoordinateFactoryEx system = myManager.CreateSystem(space.Dimension, GetDataType(subd.Max()));
      return system.Create(space, subd);
    }

    private static string GetDataType(long maxValue)
    {
      if (maxValue < short.MaxValue/2)
      {
        return "short";
      }
      if (maxValue < int.MaxValue / 2)
      {
        return "int";
      }
      return "long";
    }

    public enum ValuesType { Short, Int, Long}


    public IIntegerCoordinateFactory ForType(ValuesType type)
    {
      return new SysFactory(myManager, type.ToString().ToLower());
    }

    private class SysFactory : IIntegerCoordinateFactory
    {
      private readonly GeneratedIntegerCoordinateSystemManager myManager;
      private readonly string myType;

      public SysFactory(GeneratedIntegerCoordinateSystemManager manager, string type)
      {
        myManager = manager;
        myType = type;
      }

      public IIntegerCoordinateSystem Create(ISystemSpace space, long[] subd)
      {
        if (subd.Length != space.Dimension)
          throw new ArgumentException("Dimensions of arguments shoulb be the same");

        IIntegerCoordinateFactoryEx system = myManager.CreateSystem(space.Dimension, myType);
        return system.Create(space, subd);
      }
    }
  }
}