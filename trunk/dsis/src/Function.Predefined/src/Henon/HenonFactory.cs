using System;
using DSIS.Core.Ioc;
using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring;

namespace DSIS.Function.Predefined.Henon
{
  [UsedBySpring, ComponentCollection]
  public class HenonFactory : DoubleParametersSystemInfoFactoryBase<HenonOptions>
  {
    public HenonFactory(DoubleArrayParser parser, SystemInfoFactory factory)
      : base(2,SystemType.Descrete, "Henon", 1, paramz => new HenonFunctionSystemInfoDecorator(paramz[0]), parser, factory)
    {
    }

    protected override ISystemInfo CreateInfo(HenonOptions paramz)
    {
      return new HenonFunctionSystemInfoDecorator(paramz.A);
    }
  }
}