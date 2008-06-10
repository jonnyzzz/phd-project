using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring;

namespace DSIS.Function.Predefined.Duffing
{
  [UsedBySpring]
  public class DuffingFactory : DoubleParametersSystemInfoFactoryBase<DuffingOptions>
  {
    public DuffingFactory(DoubleArrayParser parser, SystemInfoFactory factory)
      : base(2, SystemType.Descrete, "Duffing", 3, paramz => new DuffingSystemInfo(paramz[0], paramz[1], paramz[2]), parser, factory)
    {
    }

    protected override ISystemInfo CreateInfo(DuffingOptions paramz)
    {
      return new DuffingSystemInfo(paramz.Alpha, paramz.Beta, paramz.K);
    }
  }
}