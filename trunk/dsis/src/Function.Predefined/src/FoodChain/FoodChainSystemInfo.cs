using System;
using DSIS.Core.System;

namespace DSIS.Function.Predefined.FoodChain
{
  public class FoodChainSystemInfo : DoubleSystemInfoBase
  {
    private readonly double myMu0;
    private readonly double myMu1;
    private readonly double myMu2;

    public FoodChainSystemInfo(double mu0, double mu1, double mu2) : base(3)
    {
      myMu0 = mu0;
      myMu1 = mu1;
      myMu2 = mu2;
    }

    public override string PresentableName
    {
      get { return string.Format("Food Chain[m0={0},m1={1},m2={2}]", myMu0, myMu1, myMu2); }
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new FoodChainFunction(myMu0, myMu1, myMu2);
    }
  }
}