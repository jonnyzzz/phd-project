using DSIS.Core.System;

namespace DSIS.Function.Predefined.Logistics
{
  public class Logistic2dSystemInfo : DoubleDescreteSystemInfoBase
  {
    public Logistic2dSystemInfo()
      : base(2)
    {
    }

    public override string PresentableName
    {
      get { return string.Format("Logistic 2d"); }
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new LogisticFunction2d();
    }
  }
}