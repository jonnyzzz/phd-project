using DSIS.Core.System;

namespace DSIS.Function.Predefined.Lorentz
{
  public class LorenzFunction : Function<double>, IFunction<double>
  {
    private readonly double mySigma;
    private readonly double myRho;
    private readonly double myBeta;

    public LorenzFunction(double beta, double rho, double sigma)
      : base(3)
    {
      myBeta = beta;
      mySigma = sigma;
      myRho = rho;
    }

    public void Evaluate()
    {
      var z = Input[2];
      var y = Input[1];
      var x = Input[0];
      Output[0] = mySigma * (y - x);
      Output[1] = x*(myRho - z) - y;
      Output[2] = x*y - myBeta*z;
    }
  }
}