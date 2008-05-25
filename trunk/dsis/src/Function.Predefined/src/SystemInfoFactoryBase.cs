using System.Xml;
using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring.Util;

namespace DSIS.Function.Predefined
{
  public abstract class SystemInfoFactoryBase : Registrar<ISystemInfoFactory, SystemInfoFactory>, ISystemInfoFactory
  {
    private readonly string myFactoryName;
    private readonly int myDimension;
    private readonly SystemType myType;

    protected SystemInfoFactoryBase(int dimension, SystemType type, string factoryName, SystemInfoFactory factory)
      : base(factory)
    {
      myFactoryName = factoryName;
      myDimension = dimension;
      myType = type;
    }

    public string FactoryName
    {
      get { return myFactoryName; }
    }

    public int Dimension
    {
      get { return myDimension; }
    }

    public SystemType Type
    {
      get { return myType; }
    }

    public abstract ISystemInfo Parse(XmlElement element);
  }
}