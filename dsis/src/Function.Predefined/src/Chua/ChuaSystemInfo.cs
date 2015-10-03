using DSIS.Core.System;

namespace DSIS.Function.Predefined.Chua
{
  public class ChuaSystemInfo : DoubleContiniousSystemInfoBase
  {
    private readonly ChuaOptions myOptions;

    public ChuaSystemInfo(ChuaOptions options)
        : base(3)
      {
        myOptions = options;
      }

      public override string PresentableName
      {
        get { return string.Format("Chua[p1={0},p2={1},p3={2},p4={3}]", myOptions.P1, myOptions.P2, myOptions.P3, myOptions.P4); }
      }

      protected override IFunction<double> GetFunctionInternal()
      {
        return new ChuaFunction(myOptions.P1, myOptions.P2, myOptions.P3, myOptions.P4);
      }
    }
}