using System;
using DSIS.Core.System;

namespace DSIS.Function.Predefined.Duffing
{
  public class DuffingSystemInfo : DoubleContiniousSystemInfoBase
  {
    private readonly double myA;
    private readonly double myB;
    private readonly double myW;

    public DuffingSystemInfo(ISystemSpace systemSpace, double a, double b, double w) : base(systemSpace)
    {
      myA = a;
      myB = b;
      myW = w;
    }

    public override string PresentableName
    {
      get { return "Duffing"; }
    }

    protected override IFunctionWithTime<double> GetFunctionInternal()
    {
      return new DuffingFunction(myA, myB, myW);
    }

    protected override IFunctionWithTime<double> GetFunctionDerivateInternal()
    {
      throw new NotImplementedException();
    }
  }
}