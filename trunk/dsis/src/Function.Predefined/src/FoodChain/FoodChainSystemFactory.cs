using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring;

namespace DSIS.Function.Predefined.FoodChain
{
  [UsedBySpring]
  public class FoodChainSystemFactory : DoubleParametersSystemInfoFactoryBase<FoodChainOptions>
  {
    public FoodChainSystemFactory(DoubleArrayParser parser, SystemInfoFactory factory)
      : base(3, SystemType.Descrete, "FoodChain", 3, paramz => new FoodChainSystemInfo(paramz[0], paramz[1], paramz[2]), parser, factory)
    {
    }

    protected override ISystemInfo CreateInfo(FoodChainOptions paramz)
    {
      return new FoodChainSystemInfo(paramz.Mu0, paramz.Mu1, paramz.Mu2);
    }
  }
}