using System;
using DSIS.Core.System;

namespace DSIS.Function.Predefined
{
  public class FoodChainSystemInfo : DoubleDescreteSystemInfoBase
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