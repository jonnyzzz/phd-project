using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring;

namespace DSIS.Function.Predefined.FoodChain
{
  [UsedBySpring]
  public class FoodChainSystemFactory : NoParameterSystemInfoFactoryBase
  {
    public FoodChainSystemFactory(SystemInfoFactory factory)
      : base(3,SystemType.Descrete, factory, "FoodChain", () => new FoodChainSystemInfo())
    {
    }
  }
}