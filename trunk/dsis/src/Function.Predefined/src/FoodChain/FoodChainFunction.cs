using System;
using DSIS.Core.System;

namespace DSIS.Function.Predefined.FoodChain
{
  public class FoodChainFunction : Function<double>, IFunction<double>
  {
    private readonly double myMu0;
    private readonly double myMu1;
    private readonly double myMu2;

    public FoodChainFunction(double mu0, double mu1, double mu2) : base(3)
    {
      myMu0 = mu0;
      myMu1 = mu1;
      myMu2 = mu2;
    }

    private static double phy(double x)
    {
      if (Math.Abs(x) < 1e-7) 
        return 1;
      else 
        return (1 - Math.Exp(-x))/x;
    }

    public void Evaluate()
    {
      double x = Input[0];
      double y = Input[1];
      double z = Input[2];

      double u = myMu2 * y * z;
      double kz = phy(z);
      double ky = phy(y);
      double ku = phy(u);
      
      Output[0] = myMu0*x*Math.Exp(-y)/(1 + x*Math.Max(Math.Exp(-y), kz*ky));
      Output[1] = myMu1*ky*x*y*Math.Exp(-z)*ku;
      Output[2] = u;
    }
  }
}