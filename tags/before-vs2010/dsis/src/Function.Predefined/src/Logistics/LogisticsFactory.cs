using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.Logistics
{
  [SystemInfoComponent]
  public class LogisticsFactory : DoubleParametersSystemInfoFactoryBase<LogisticsParameters>
  {
    public LogisticsFactory()
      : base(1,SystemType.Discrete, "Logistics")
    {
    }

    protected override ISystemInfo CreateInfo(LogisticsParameters paramz)
    {
      return new LogisticSystemInfo(paramz.A);
    }
  }
}