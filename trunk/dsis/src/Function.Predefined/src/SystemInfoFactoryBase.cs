using System;
using System.Xml;
using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined
{
  public abstract class SystemInfoFactoryBase : ISystemInfoFactory
  {
    private readonly string myFactoryName;
    private readonly int myDimension;
    private readonly SystemType myType;

    protected SystemInfoFactoryBase(int dimension, SystemType type, string factoryName)
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

    public virtual Type OptionsObjectType
    {
       get { return null; }
    }

    public ISystemInfo Parse(XmlElement element)
    {
      throw new NotImplementedException();
    }

    public abstract ISystemInfo Create(ISystemInfoParameters parameters);
  }
}