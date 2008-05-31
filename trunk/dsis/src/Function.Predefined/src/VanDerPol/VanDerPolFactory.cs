using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring;

namespace DSIS.Function.Predefined.VanDerPol
{
  [UsedBySpring]
  public class VanDerPolFactory : DoubleParametersSystemInfoFactoryBase
  {
    //todo: Provide continious system converter
    public VanDerPolFactory(DoubleArrayParser parser, SystemInfoFactory factory)
      : base(2, SystemType.Continious, "Van-der-Pol", 1, paramz => new VanDerPolSystemInfo(paramz[0]), parser,factory)
    {
    }
  }
}