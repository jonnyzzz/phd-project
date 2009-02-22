using DSIS.Core.System;

namespace DSIS.Function.Predefined.Chua
{
  public class ChuaSystemInfo2 : DoubleContiniousSystemInfoBase
  {
    private readonly ChuaOptions2 myOptions;

    public ChuaSystemInfo2(ChuaOptions2 options)
      : base(3)
    {
      myOptions = options;
    }

    public override string PresentableName
    {
      get { return string.Format("Chua2[A={0},B={1},m0={2},m1={3}]", myOptions.A, myOptions.B, myOptions.M0, myOptions.M1); }
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new ChuaFunction2(myOptions);
    }
  }
}