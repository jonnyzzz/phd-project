using System.Xml;
using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined
{
  public abstract class DoubleParametersSystemInfoFactoryBase : SystemInfoFactoryBase  {
    private readonly CreateDelegate myFactory;
    private readonly DoubleArrayParser myParser;
    
    private readonly int myParamsCount;
    protected delegate ISystemInfo CreateDelegate(double[] paramz);

    protected DoubleParametersSystemInfoFactoryBase(int dim, SystemType type, string factoryName, int paramsCount, CreateDelegate factory, DoubleArrayParser parser, SystemInfoFactory systemFactory)
      : base(dim, type, factoryName, systemFactory)
    {
      myParser = parser;
      myParamsCount = paramsCount;
      myFactory = factory;
    }
    
    public override ISystemInfo Parse(XmlElement element)
    {
      double[] parz = myParser.Parse(element);
      if (parz == null)
        return null;

      if (parz.Length != myParamsCount)
        return null;

      return myFactory(parz);      
    }    
  }
}