using DSIS.Core.Ioc;
using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring;

namespace DSIS.Function.Predefined.Linear
{
  [UsedBySpring, ComponentCollection]
  public class Linear1DFactory : DoubleParametersSystemInfoFactoryBase<Linear1dParameters>
  {
    public Linear1DFactory(DoubleArrayParser parser, SystemInfoFactory factory)
      : base(1,SystemType.Descrete, "Linear1D", 2, paramz => new Linear1DSystemInfo(paramz[0], paramz[1]), parser, factory)
    {
    }

    protected override ISystemInfo CreateInfo(Linear1dParameters paramz)
    {
      return new Linear1DSystemInfo(paramz.A, paramz.B);
    }
  }
}