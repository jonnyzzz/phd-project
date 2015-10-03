using System;
using DSIS.Core.System;

namespace DSIS.Function.Predefined.Rossel
{  
  public class RosslerSystemInfo : DoubleSystemInfoBase
  {
    private readonly double myC;
    private readonly double myB;
    private readonly double myA;

    public RosslerSystemInfo(ISystemSpace systemSpace, double a, double b, double c)
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

    protected override IFunction<double> GetFunctionDerivateInternal()
    {
      throw new NotImplementedException();
    }
  }
}
