using System;
using DSIS.Core.System;

namespace DSIS.Function.Predefined
{
  public class FoodChainSystemInfo : DoubleSystemInfoBase
  {
    public FoodChainSystemInfo(ISystemSpace systemSpace) : base(systemSpace)
    {
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new FoodChainFunction();
    }

    protected override IFunction<double> GetFunctionDerivateInternal()
    {
      throw new NotImplementedException();
    }
  }
}