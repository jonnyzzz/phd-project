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
      Output[1] = Input[0]*(myRho - Input[2]) - Input[1];
      Output[2] = Input[0]*Input[1] - myBeta*Input[2];
    }
  }


}
