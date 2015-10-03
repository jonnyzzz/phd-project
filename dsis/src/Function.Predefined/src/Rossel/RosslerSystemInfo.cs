using System;
using DSIS.Core.System;

namespace DSIS.Function.Predefined.Rossel
{
  public class RosslerSystemInfo : DoubleContiniousSystemInfoBase
  {
    private readonly double myC;
    private readonly double myB;
    private readonly double myA;

    public RosslerSystemInfo(double a, double b, double c)
      : base(3)
    {
      myA = a;
      myC = c;
      myB = b;
    }

    public override string PresentableName
    {
      get { return "Rossler"; }
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new RosslerSystemFunction(myA, myB, myC);
    }
  }
}
