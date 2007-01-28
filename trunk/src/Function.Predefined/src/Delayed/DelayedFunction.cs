/*
 * Created by: 
 * Created: 26 ÿםגאנÿ 2007 ד.
 */

namespace DSIS.Function.Predefined.Delayed
{
  public class DelayedFunction : FunctionBase<double>
  {
    private double myA;

    public DelayedFunction(double a) : base(2)
    {
      myA = a;
    }

    public override void Evaluate()
    {
      Output[0] = Input[1];
      Output[1] = myA * Input[1] * (1 - Input[0]);
    }
  }
}