using DSIS.Core.System;

namespace DSIS.Function.Predefined.HomoLinear
{
  public class HomoLinearSystemInfo : DoubleContiniousSystemInfoBase
  {
    private readonly double myA;

    public HomoLinearSystemInfo(double a) : base(2)
    {
      myA = a;
    }

    public override string PresentableName
    {
      get { return "Homoclinic linear, a=" + myA; }
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new HomoclinicFunction(myA);
    }

    private class HomoclinicFunction : Function<double>, IFunction<double>
    {
      private readonly double myA;

      public HomoclinicFunction(double a)
        : base(2)
      {
        myA = a;
      }

      public void Evaluate()
      {
        var x = Input[0];
        var y = Input[1];

        var logLike = myA * x * (1- x);        
        Output[0] = x + y + logLike;
        Output[1] = y + logLike;
      }
    }
  }
}