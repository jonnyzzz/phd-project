using System;
using DSIS.Core.System;

namespace DSIS.Function.Predefined.Chua
{
  public class ChuaFunction : Function<double>, IFunction<double>
  {
    private readonly double myP1;
    private readonly double myP2;
    private readonly double myP3;
    private readonly double myP4;

    public ChuaFunction(double p1, double p2, double p3, double p4)
      : base(3)
    {
      myP1 = p1;
      myP4 = p4;
      myP3 = p3;
      myP2 = p2;
    }

    public void Evaluate()
    {
      var x = Input[0];
      var y = Input[1];
      var z = Input[2];

      Output[0] = myP1 *( y - myP4*x - (myP3-myP4)*(Math.Abs(x+1) - Math.Abs(x-1)));
      Output[1] = x - y  + z;
      Output[1] = - myP2 * y;
    }
  }
}