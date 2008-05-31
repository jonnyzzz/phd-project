using System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring;

namespace DSIS.Function.Predefined.Henon
{
  [UsedBySpring]
  public class HenonFactory : DoubleParametersSystemInfoFactoryBase
  {
    public HenonFactory(DoubleArrayParser parser, SystemInfoFactory factory)
      : base(2,SystemType.Descrete, "Henon", 1, paramz => new HenonFunctionSystemInfoDecorator(paramz[0]), parser, factory)
    {
    }

    public override Type OptionsObjectType
    {
      get { return typeof (HenonOptions); }
    }
  }
}