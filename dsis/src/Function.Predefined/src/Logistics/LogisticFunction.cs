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
}