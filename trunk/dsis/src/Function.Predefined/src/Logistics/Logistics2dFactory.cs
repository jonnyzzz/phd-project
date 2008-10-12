using DSIS.Core.Ioc;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring;

namespace DSIS.Function.Predefined.Logistics
{
  [UsedBySpring, ComponentCollection]
  public class Logistics2dFactory : NoParameterSystemInfoFactoryBase
  {
    public Logistics2dFactory(SystemInfoFactory systemFactory)
      : base(2,SystemType.Descrete,
             systemFactory,
             "Logistics2d",
             () => new Logistic2dSystemInfo())
    {
    }
  }
}