using System;
using DSIS.Core.System;

namespace DSIS.Function.Predefined.Duffing
{
  public class DuffingFunction : Function<double>, IFunctionWithTime<double>
  {
    private readonly double myA;
    private readonly double myB;
    private readonly double myW;

    public DuffingFunction(double a, double b, double w) : base(2)
    {
      myA = a;
      myB = b;
      myW = w;
    }

    public void Evaluate(double time)
    {
      Output[0] = Input[1];
      Output[1] = Input[0] - Input[0] * Input[0] * Input[0] - myA * Input[1] + myB * Math.Cos(myW * time);
    }
  }
}
