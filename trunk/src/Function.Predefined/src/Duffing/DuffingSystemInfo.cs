using System;
using DSIS.Core.System;

namespace DSIS.Function.Predefined.Duffing
{
  public class DuffingSystemInfo : DoubleSystemInfoBase
  {
    private readonly double myAlpha;
    private readonly double myBeta;
    private readonly double myK;

    public DuffingSystemInfo(ISystemSpace systemSpace, double alpha, double beta, double k) : base(systemSpace)
    {
      myAlpha = alpha;
      myK = k;
      myBeta = beta;
    }

    public override string PresentableName
    {
      get { return "Duffing"; }
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new DuffingFunction(myAlpha, myBeta, myK);
    }

    protected override IFunction<double> GetFunctionDerivateInternal()
    {
      throw new NotImplementedException();
    }
  }
}