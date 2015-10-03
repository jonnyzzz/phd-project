using DSIS.Core.System;

namespace DSIS.Function.Predefined.Logistics
{
  public class LogisticFunction2d : Function<double>, IFunction<double>
  {
    public LogisticFunction2d() : base(2)
    {
    }

    public void Evaluate()
    {
      Output[0] = Input[1]*Input[0]*(1 - Input[0]);
      Output[1] = Input[1];
    }
  }
}