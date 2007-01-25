/*
 * Created by: 
 * Created: 5 ÿםגאנÿ 2007 ד.
 */

namespace DSIS.Function.Predefined.Henon
{
  public class HenonFunction : FunctionBase<double>
  {
    protected readonly double myA;

    public HenonFunction(double a) : base(2)
    {
      myA = a;
    }

    public override void Evaluate()
    {
      Output[0] = 1 - myA*Input[0]*Input[0] + 0.3*Input[1];
      Output[1] = Input[0];
    }
  }
}