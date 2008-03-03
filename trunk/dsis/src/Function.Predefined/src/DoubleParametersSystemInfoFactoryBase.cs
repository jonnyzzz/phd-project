using System.Xml;
using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring.Util;

namespace DSIS.Function.Predefined
{
  public class DoubleParametersSystemInfoFactoryBase : Registrar<ISystemInfoFactory, SystemInfoFactory>, ISystemInfoFactory
  {
    private readonly string myFactoryName;
    private readonly CreateDelegate myFactory;
    private readonly DoubleArrayParser myParser;
    
    private readonly int myParamsCount;
    protected delegate ISystemInfo CreateDelegate(double[] paramz);

    protected DoubleParametersSystemInfoFactoryBase(string factoryName, int paramsCount, CreateDelegate factory, DoubleArrayParser parser, SystemInfoFactory systemFactory)
      : base(systemFactory)
    {
      myFactoryName = factoryName;
      myParser = parser;
      myParamsCount = paramsCount;
      myFactory = factory;
    }
    
    public string FactoryName
    {
      get { return myFactoryName; }
    }

    public ISystemInfo Parse(XmlElement element)
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