using DSIS.Core.Ioc;
using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring;

namespace DSIS.Function.Predefined.Delayed
{
  [UsedBySpring, ComponentCollection]
  public class DelayedFactory : DoubleParametersSystemInfoFactoryBase<DelayedOptions>
  {
    public DelayedFactory(DoubleArrayParser parser, SystemInfoFactory factory)
      : base(2,SystemType.Descrete, "Delayed", 1, paramz => new DelayedFunctionSystemInfo(paramz[0]), parser, factory)
    {

    }

    protected override ISystemInfo CreateInfo(DelayedOptions paramz)
    {
      return new DelayedFunctionSystemInfo(paramz.A);
    }
  }
}