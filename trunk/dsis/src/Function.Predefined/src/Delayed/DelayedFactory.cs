using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring;

namespace DSIS.Function.Predefined.Delayed
{
  [UsedBySpring]
  public class DelayedFactory : DoubleParametersSystemInfoFactoryBase
  {
    public DelayedFactory(DoubleArrayParser parser, SystemInfoFactory factory)
      : base(2,SystemType.Descrete, "Delayed", 1, paramz => new DelayedFunctionSystemInfo(paramz[0]), parser, factory)
    {
    }
  }
}