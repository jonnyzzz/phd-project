using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring;

namespace DSIS.Function.Predefined.Lorentz
{
  [UsedBySpring]
  public class LorentzSystemInfoFactory : DoubleParametersSystemInfoFactoryBase
  {
    public LorentzSystemInfoFactory(DoubleArrayParser parser, SystemInfoFactory factory)
      : base(3, SystemType.Descrete, "Lorentz", 3, paramz => new LorentzSystemInfo(paramz[0], paramz[1], paramz[2]), parser, factory)
    {
    }
  }
}