using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring;

namespace DSIS.Function.Predefined.Henon
{
  [UsedBySpring]
  public class HenonDellnitzFactory : DoubleParametersSystemInfoFactoryBase<HenonDellnitzOptions>
  {
    public HenonDellnitzFactory(DoubleArrayParser parser, SystemInfoFactory factory)
      : base(2,SystemType.Descrete, "HenonDellnitz", 2, paramz => new HenonDellnitzFunctionSystemInfoDecorator(paramz[0], paramz[1]), parser, factory)
    {
    }

    protected override ISystemInfo CreateInfo(HenonDellnitzOptions paramz)
    {
      return new HenonDellnitzFunctionSystemInfoDecorator(paramz.A, paramz.B);
    }
  }
}