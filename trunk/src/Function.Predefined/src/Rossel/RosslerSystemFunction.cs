using DSIS.Core.System;

namespace DSIS.Function.Predefined.Rossel
{
  public class RosslerSystemFunction : Function<double>, IFunction<double>
  {
    private readonly double myA;
    private readonly double myB;
    private readonly double myC;

    public RosslerSystemFunction(double a, double b, double c)
      : base(3)
    {
      myA = a;
      myC = c;
      myB = b;
    }

    public void Evaluate()
    {
      Output[0] = - Input[1] - Input[2];
      Output[1] = Input[0] + myA*Input[1];
      Output[2] = myB + Input[2] * (Input[0] - myC);
    }
  }
}