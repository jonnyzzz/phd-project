using System;
using DSIS.Core.System;

namespace DSIS.Function.Predefined
{
  public class FoodChainFunction : FunctionBase<double>
  {
    public FoodChainFunction() : base(3)
    {
    }

    public override void Evaluate()
    {
      double x = Input[0];
      double y = Input[1];
      double z = Input[2];

      double kz = (1 - Math.Exp(-z))/z;
      double ky = (1 - Math.Exp(-y))/y;
      double u = 4*y*z;
      double ku = (1 - Math.Exp(-u))/u;
      Output[0] = 4.522*x*Math.Exp(-y)/(1 + x*Math.Max(Math.Exp(-y), kz*ky));
      Output[1] = ky*x*y*Math.Exp(-z)*ku;
      Output[2] = 4*y*z;
    }
  }
}