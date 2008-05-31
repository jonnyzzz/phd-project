using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring;

namespace DSIS.Function.Predefined.Duffing
{
  [UsedBySpring]
  public class DuffingFactory : DoubleParametersSystemInfoFactoryBase
  {
    public DuffingFactory(DoubleArrayParser parser, SystemInfoFactory factory)
      : base(2, SystemType.Descrete, "Duffing", 3, paramz => new DuffingSystemInfo(paramz[0], paramz[1], paramz[2]), parser, factory)
    {
    }
  }
}