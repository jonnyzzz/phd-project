/*
 * Created by: 
 * Created: 26 ÿםגאנÿ 2007 ד.
 */

using DSIS.Core.System;

namespace DSIS.Function.Predefined.Delayed
{
  public class DelayedFunction : Function<double>, IFunction<double>
  {
    private readonly double myA;

    public DelayedFunction(double a) : base(2)
    {
      myA = a;
    }

    public void Evaluate()
    {
      Output[0] = Input[1];
      Output[1] = myA*Input[1]*(1 - Input[0]);
    }
  }
}