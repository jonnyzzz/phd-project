using DSIS.Core.Ioc;
using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring.Attributes;

namespace DSIS.Function.Predefined.Chua
{
  [SpringBean, ComponentCollection]
  public class ChuaFactory : DoubleParametersSystemInfoFactoryBase<ChuaOptions>
  {
    public ChuaFactory(DoubleArrayParser parser, SystemInfoFactory factory)
      : base(
        3,
        SystemType.Continious,
        "Chua",
        4,
        paramz => new ChuaSystemInfo(new ChuaOptions() { P1 = paramz[0], P2 = paramz[1], P3 = paramz[2], P4 = paramz[3] }),
        parser,
        factory)
    {
    }

    protected override ISystemInfo CreateInfo(ChuaOptions paramz)
    {
      return new ChuaSystemInfo(paramz);
    }
  }
}