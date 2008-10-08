using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring.Attributes;

namespace DSIS.Function.Predefined.Brusselator
{
  [SpringBean]
  public class BrusselatorFactory : DoubleParametersSystemInfoFactoryBase<BrusselatorOptions>
  {
    public BrusselatorFactory(DoubleArrayParser parser, SystemInfoFactory factory)
      : base(
        2,
        SystemType.Continious,
        "Brusselator",
        2,
        paramz => new BrusselatorSystemInfo(new BrusselatorOptions {P1 = paramz[0], P2 = paramz[1]}),
        parser,
        factory)
    {
    }

    protected override ISystemInfo CreateInfo(BrusselatorOptions paramz)
    {
      return new BrusselatorSystemInfo(paramz);
    }
  }
}