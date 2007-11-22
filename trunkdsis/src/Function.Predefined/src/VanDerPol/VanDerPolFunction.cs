using DSIS.Core.System;

namespace DSIS.Function.Predefined.VanDerPol
{
  public class VanDerPolFunction : Function<double>, IFunction<double>
  {
    private readonly double myA;

    public VanDerPolFunction(double a)
      : base(2)
    {
      myA = a;
    }

    public void Evaluate()
    {
      Output[0] = Input[1];
      Output[1] = myA * (1 - Input[0] * Input[0]) * Input[1] - Input[0];
    }
  }
}