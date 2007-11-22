using System;
using DSIS.Core.System;

namespace DSIS.Function.Predefined.VanDerPol
{
  public class VanDerPolSystemInfo : DoubleSystemInfoBase
  {
    private readonly double myA;

    public VanDerPolSystemInfo(ISystemSpace systemSpace, double a)
      : base(systemSpace)
    {
      myA = a;
    }

    public override string PresentableName
    {
      get { return "Van-der-Pol"; }
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new VanDerPolFunction(myA);
    }

    protected override IFunction<double> GetFunctionDerivateInternal()
    {
      throw new NotImplementedException();
    }
  }
}
