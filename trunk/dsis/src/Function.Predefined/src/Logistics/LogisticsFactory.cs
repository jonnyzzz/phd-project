using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring;

namespace DSIS.Function.Predefined.Logistics
{
  [UsedBySpring]
  public class LogisticsFactory : DoubleParametersSystemInfoFactoryBase
  {
    public LogisticsFactory(DoubleArrayParser parser, SystemInfoFactory factory)
      : base(1,SystemType.Descrete, "Logistics", 1, paramz => new LogisticSystemInfo(paramz[0]), parser, factory)
    {
    }
  }
}