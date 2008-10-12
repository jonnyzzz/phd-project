using DSIS.Core.Ioc;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring;

namespace DSIS.Function.Predefined.Julia
{
  [UsedBySpring, ComponentCollection]
  public class JuliaFactory : NoParameterSystemInfoFactoryBase
  {
    public JuliaFactory(SystemInfoFactory factory)
      : base(2, SystemType.Descrete, factory, "Julia", () => new JuliaFuctionSystemInfoDecorator())
    {
    }
  }
}