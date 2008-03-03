using System;
using DSIS.Core.System;

namespace DSIS.Function.Predefined.FoodChain
{
  public class FoodChainSystemInfo : DoubleSystemInfoBase
  {
    public FoodChainSystemInfo(ISystemSpace systemSpace) : base(systemSpace)
    {
    }

    public override string PresentableName
    {
      get { return "Food Chain"; }
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