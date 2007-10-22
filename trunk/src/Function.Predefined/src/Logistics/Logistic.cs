using System;
using DSIS.Core.System;

namespace DSIS.Function.Predefined.Logistics
{
  public class LogisticFunction : Function<double>, IFunction<double>
  {
    private readonly double myA;

    public LogisticFunction(double a)
      : base(1)
    {
      myA = a;
    }

    public void Evaluate()
    {
      Output[0] = myA * Input[0] * (1 - Input[0]);
    }
  }

  public class LogisticSystemInfo : DoubleSystemInfoBase
  {
    private readonly double myA;

    public LogisticSystemInfo(ISystemSpace systemSpace, double a)
      : base(systemSpace)
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
