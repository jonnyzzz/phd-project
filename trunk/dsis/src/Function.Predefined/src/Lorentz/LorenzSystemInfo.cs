using System;
using DSIS.Core.System;

namespace DSIS.Function.Predefined.Lorentz
{
  public class LorenzSystemInfo : DoubleSystemInfoBase
  {
    private readonly double mySigma;
    private readonly double myRho;
    private readonly double myBeta;

    public LorenzSystemInfo(double beta, double rho, double sigma)
      : base(3)
    {
      myBeta = beta;
      mySigma = sigma;
      myRho = rho;
    }

    public override string PresentableName
    {
      get { return string.Format("Lorenz[Beta={0},Sigma={1},Rho={2}]", myBeta, mySigma, myRho); }
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new LorenzFunction(myBeta, myRho, mySigma);
    }

    protected override IFunction<double> GetFunctionDerivateInternal()
    {
      throw new NotImplementedException();
    }
  }
}
