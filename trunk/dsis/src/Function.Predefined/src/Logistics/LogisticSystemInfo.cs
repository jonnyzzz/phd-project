using System;
using DSIS.Core.System;

namespace DSIS.Function.Predefined.Logistics
{
  public class LogisticSystemInfo : DoubleDescreteSystemInfoBase
  {
    private readonly double myA;

    public LogisticSystemInfo(double a)
      : base(1)
    {
      myA = a;
    }

    public override string PresentableName
    {
      get { return string.Format("Logistic {0}", myA); }
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new LogisticFunction(myA);
    }

    protected override IFunction<double> GetFunctionDerivateInternal()
    {
      throw new NotImplementedException();
    }
  }
}