/*
 * Created by: 
 * Created: 5 ÿםגאנÿ 2007 ד.
 */

using DSIS.Core.System;

namespace DSIS.Function.Predefined.Henon
{
  public class HenonFunction : Function<double>, IFunction<double>
  {
    protected readonly double myA;

    public HenonFunction(double a) : base(2)
    {
      myA = a;
    }

    public void Evaluate()
    {
      Output[0] = 1 - myA*Input[0]*Input[0] + 0.3*Input[1];
      Output[1] = Input[0];
    }
  }
}