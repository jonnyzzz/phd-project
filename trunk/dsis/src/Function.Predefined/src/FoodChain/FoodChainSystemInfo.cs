using System;
using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring;

namespace DSIS.Function.Predefined.FoodChain
{
  public class FoodChainSystemInfo : DoubleSystemInfoBase
  {
    public FoodChainSystemInfo() : base(3)
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