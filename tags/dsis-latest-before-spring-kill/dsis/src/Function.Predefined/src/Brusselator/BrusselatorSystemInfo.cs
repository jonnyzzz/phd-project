using DSIS.Core.System;

namespace DSIS.Function.Predefined.Brusselator
{
  public class BrusselatorSystemInfo : DoubleSystemInfoBase
  {
    private readonly BrusselatorOptions myOptions;

    public BrusselatorSystemInfo(BrusselatorOptions options) : base(2)
    {
      myOptions = options;
    }

    public override string PresentableName
    {
      get { return string.Format("Brusselator[p1={0},p2={1}]", myOptions.P1, myOptions.P2); }
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new BrusselatorFunction(myOptions.P1, myOptions.P2);
    }
  }
}