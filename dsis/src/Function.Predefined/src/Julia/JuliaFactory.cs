using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring;

namespace DSIS.Function.Predefined.Julia
{
  [UsedBySpring]
  public class JuliaFactory : NoParameterSystemInfoFactoryBase
  {
    public JuliaFactory(SystemInfoFactory factory)
      : base(2, SystemType.Descrete, factory, "Julia", () => new JuliaFuctionSystemInfoDecorator())
    {
    }
  }
}