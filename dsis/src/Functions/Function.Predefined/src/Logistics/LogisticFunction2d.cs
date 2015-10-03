using System;
using DSIS.Core.System;

namespace DSIS.Function.Predefined.Logistics
{
  public class LogisticFunction2d : Function<double>, IFunction<double>, IDetDiffFunction<double>
  {
    public LogisticFunction2d() : base(2)
    {
    }

    public void Evaluate()
    {
      var x = Input[0]; 
      var y = Input[1];
      
      Output[0] = x*y*(1 - x);
      Output[1] = y;
    }

    public double Evaluate(double[] data)
    {
      // fxx = y(1-2x)
      // fxy = x(1-x)
      // fyx = 0
      // fyy = 1

      return data[1]*(1 - 2*data[0]);
    }
  }
}