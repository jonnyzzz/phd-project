using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.FoodChain
{
  [SystemInfoComponent]
  public class FoodChainSystemFactory : DoubleParametersSystemInfoFactoryBase<FoodChainOptions>
  {
    public FoodChainSystemFactory()
      : base(3, SystemType.Discrete, "FoodChain")
    {
    }

    protected override ISystemInfo CreateInfo(FoodChainOptions paramz)
    {
      return new FoodChainSystemInfo(paramz.Mu0, paramz.Mu1, paramz.Mu2);
    }
  }
}