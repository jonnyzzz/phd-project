using System;
using DSIS.Core.System;

namespace DSIS.Function.Predefined.Logistics
{
  public class LogisticFunction : Function<double>, IFunction<double>, IDetDiffFunction<double>
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

    public double Evaluate(double[] data)
    {
      return myA*(1 - 2*data[0]);
    }
  }
}