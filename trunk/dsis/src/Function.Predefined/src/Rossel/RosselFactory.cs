using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring;

namespace DSIS.Function.Predefined.Rossel
{
  [UsedBySpring]
  public class RosselFactory : DoubleParametersSystemInfoFactoryBase
  {
    //todo: Provide continious system converter
    public RosselFactory(DoubleArrayParser parser, SystemInfoFactory factory)
      : base(3, SystemType.Continious, "Rossel", 3, paramz => new RosslerSystemInfo(paramz[0], paramz[1], paramz[3]), parser, factory)
    {
    }
  }
}