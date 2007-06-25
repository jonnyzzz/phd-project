using System;
using DSIS.Core.System;

namespace DSIS.Function.Predefined.Lorentz
{
  public class LorentzSystemInfo : DoubleSystemInfoBase
  {
    private readonly double mySigma;
    private readonly double myRho;
    private readonly double myBeta;

    public LorentzSystemInfo(ISystemSpace systemSpace, double beta, double rho, double sigma)
      : base(systemSpace)
    {
      myBeta = beta;
      mySigma = sigma;
      myRho = rho;
    }

    public override string PresentableName
    {
      get { return "Van-der-Pol"; }
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new LorentzFunction(myBeta, myRho, mySigma);
    }

    protected override IFunction<double> GetFunctionDerivateInternal()
    {
      throw new NotImplementedException();
    }
  }
}
