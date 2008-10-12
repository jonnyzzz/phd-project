using DSIS.Core.Ioc;
using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring;

namespace DSIS.Function.Predefined.Logistics
{
  [UsedBySpring, ComponentCollection]
  public class LogisticsFactory : DoubleParametersSystemInfoFactoryBase<LogisticsParameters>
  {
    public LogisticsFactory(DoubleArrayParser parser, SystemInfoFactory factory)
      : base(1,SystemType.Descrete, "Logistics", 1, paramz => new LogisticSystemInfo(paramz[0]), parser, factory)
    {
    }

    protected override ISystemInfo CreateInfo(LogisticsParameters paramz)
    {
      return new LogisticSystemInfo(paramz.A);
    }
  }
}