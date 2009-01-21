/*
 * Created by: 
 * Created: 26 ÿםגאנÿ 2007 ד.
 */

using DSIS.Core.System;

namespace DSIS.Function.Predefined.Delayed
{
  public class DelayedFunction : Function<double>, IFunction<double>, IDetDiffFunction<double>
  {
    private readonly double myA;

    public DelayedFunction(double a) : base(2)
    {
      myA = a;
    }

    public void Evaluate()
    {
      var x = Input[0];
      var y = Input[1];

      Output[0] = y;
      Output[1] = myA*y*(1 - x);
    }

    public double Evaluate(double[] data)
    {
//      double x = data[0];
      double y = data[1];

      /*var fxx = 0;
      var fxy = 1;
      var fyx = -myA*y;
      var fyy = myA*(1 - x);
*/
      return myA*y;
    }
  }
}