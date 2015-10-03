using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring;

namespace DSIS.Function.Predefined.Ikeda
{
  [UsedBySpring]
  public class IkeadFactory : NoParameterSystemInfoFactoryBase
  {
    public IkeadFactory(SystemInfoFactory factory)
      : base(2,SystemType.Descrete, factory, "Ikeda", () => new IkedaFunctionSystemInfoDecorator())
    {
    }
  }
}