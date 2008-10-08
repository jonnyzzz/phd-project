using DSIS.Core.System;

namespace DSIS.Function.Predefined.Brusselator
{
  public class BrusselatorFunction : Function<double>, IFunction<double>
  {
    private readonly double myP1;
    private readonly double myP2;

    public BrusselatorFunction(double p1, double p2)
      : base(2)
    {
      myP1 = p1;
      myP2 = p2;
    }

    public void Evaluate()
    {
      var x = Input[0];
      var y = Input[1];
      var x2 = x*x;

      Output[0] = myP1 - myP2*x + x2*y - x;
      Output[1] = myP2*x - x2*y;
    }
  }
}