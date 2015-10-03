using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring;

namespace DSIS.Function.Predefined.FoodChain
{
  [UsedBySpring]
  public class FoodChainSystemFactory : NoParameterSystemInfoFactoryBase
  {
    public FoodChainSystemFactory(SystemInfoFactory factory)
      : base(factory, "FoodChain", delegate { return new FoodChainSystemInfo(); })
    {
    }
  }
}