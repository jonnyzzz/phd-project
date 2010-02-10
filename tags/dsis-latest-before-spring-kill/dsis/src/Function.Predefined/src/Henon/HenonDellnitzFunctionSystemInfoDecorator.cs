using System;
using DSIS.Core.System;

namespace DSIS.Function.Predefined.Henon
{
  public class HenonDellnitzFunctionSystemInfoDecorator : DoubleSystemInfoBase
  {
    private readonly double myA;
    private readonly double myB;

    public HenonDellnitzFunctionSystemInfoDecorator(double a, double b)
      : base(2)
    {
      myA = a;
      myB = b;
    }

    public override string PresentableName
    {
      get { return string.Format("Henon_Dellnitz a={0}, b={1}", myA, myB); }
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new HenonFunction(myA, myB);
    }

    protected override IFunction<double> GetFunctionDerivateInternal()
    {
      throw new NotImplementedException();
    }

    private class HenonFunction : Function<double>, IFunction<double>
    {
      protected readonly double myA;
      protected readonly double myB;

      public HenonFunction(double a, double b)
        : base(2)
      {
        myA = a;
        myB = b;
      }

      public void Evaluate()
      {
        Output[0] = 1 - myA * Input[0] * Input[0] + Input[1] / 5;
        Output[1] = 5 * myB * Input[0];
      }
    }
  }
}