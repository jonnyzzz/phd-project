using System.Xml;
using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring.Util;

namespace DSIS.Function.Predefined
{
  public class NoParameterSystemInfoFactoryBase : Registrar<ISystemInfoFactory, SystemInfoFactory>, ISystemInfoFactory
  {
    private readonly string myFactoryName;
    private readonly CreateDelegate myFactory;

    protected NoParameterSystemInfoFactoryBase(SystemInfoFactory systemFactory, string factoryName, CreateDelegate factory) : base(systemFactory)
    {
      myFactoryName = factoryName;
      myFactory = factory;
    }

    protected delegate ISystemInfo CreateDelegate();

    public string FactoryName
    {
      get { return myFactoryName; }
    }

    public ISystemInfo Parse(XmlElement element)
    {
      return myFactory();
    }
  }
}