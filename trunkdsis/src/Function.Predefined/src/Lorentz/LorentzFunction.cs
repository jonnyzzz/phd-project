using DSIS.Core.System;

namespace DSIS.Function.Predefined.Lorentz
{
  public class LorentzFunction : Function<double>, IFunction<double>
  {
    private readonly double mySigma;
    private readonly double myRho;
    private readonly double myBeta;

    public LorentzFunction(double beta, double rho, double sigma)
      : base(3)
    {
      myBeta = beta;
      mySigma = sigma;
      myRho = rho;
    }

    public void Evaluate()
    {
      Output[0] = mySigma * (Input[1] - Input[0]);
      Output[1] = myRho * Input[0] - Input[0] * Input[2] - Input[1];
      Output[2] = Input[0]*Input[1] - myBeta*Input[2];
    }
  }
}