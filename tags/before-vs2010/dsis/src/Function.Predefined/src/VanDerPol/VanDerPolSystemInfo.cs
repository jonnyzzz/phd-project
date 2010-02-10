using System;
using DSIS.Core.System;

namespace DSIS.Function.Predefined.VanDerPol
{
  public class VanDerPolSystemInfo : DoubleContiniousSystemInfoBase
  {
    private readonly double myA;

    public VanDerPolSystemInfo(double a)
      : base(2)
    {
      myA = a;
    }

    public override string PresentableName
    {
      get { return string.Format("Van-der-Pol[gamma={0}]", myA); }
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new VanDerPolFunction(myA);
    }
  }
}
