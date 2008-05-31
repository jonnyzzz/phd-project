using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring;

namespace DSIS.Function.Predefined.Linear
{
  [UsedBySpring]
  public class Linear1DFactory : DoubleParametersSystemInfoFactoryBase
  {
    public Linear1DFactory(DoubleArrayParser parser, SystemInfoFactory factory)
      : base(1,SystemType.Descrete, "Linear1D", 2, paramz => new Linear1DSystemInfo(paramz[0], paramz[1]), parser, factory)
    {
    }
  }
}