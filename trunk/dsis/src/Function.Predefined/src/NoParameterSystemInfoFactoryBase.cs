using System.Xml;
using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined
{
  public class NoParameterSystemInfoFactoryBase : SystemInfoFactoryBase {
    private readonly CreateDelegate myFactory;

    protected NoParameterSystemInfoFactoryBase(int dimension, SystemType type, SystemInfoFactory systemFactory, string factoryName, CreateDelegate factory) : 
      base(dimension, type, factoryName, systemFactory)
    {
      myFactory = factory;
    }

    protected delegate ISystemInfo CreateDelegate();

    public override ISystemInfo Parse(XmlElement element)
    {
      return myFactory();
    }
  }
}