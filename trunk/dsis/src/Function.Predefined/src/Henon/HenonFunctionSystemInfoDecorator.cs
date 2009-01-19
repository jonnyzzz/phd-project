using System.Globalization;
using DSIS.Core.System;

namespace DSIS.Function.Predefined.Henon
{
  public class HenonFunctionSystemInfoDecorator : DoubleDescreteSystemInfoBase
  {
    private readonly double myA;
    
    public HenonFunctionSystemInfoDecorator(double a) : base(2)
    {
      myA = a;
    }

    public override string PresentableName
    {
      get { return string.Format("Henon a={0}", myA.ToString(CultureInfo.InvariantCulture)); }
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new HenonFunction(myA);
    }

    protected override IFunction<double> GetFunctionDerivateInternal()
    {
      return new HenonFunctionDerivate(myA);
    }

    private class HenonFunction : Function<double>, IFunction<double>, IDetDiffFunction<double>
    {
      protected readonly double myA;

      public HenonFunction(double a)
        : base(2)
      {
        myA = a;
      }

      public void Evaluate()
      {
        var x = Input[0];
        var y = Input[1];
        Output[0] = 1 - myA * x * x + 0.3 * y;
        Output[1] = x;
      }

      public double Evaluate(double[] data)
      {
        /*
        double x = data[0];
        double y = data[1];

        var fxx = -myA*2*x;
        var fxy = 0.3;
        var fyx = 1;
        var fyy = 0;
        */
        return -0.3;
      }
    }

    private class HenonFunctionDerivate : Function<double>, IFunction<double>
    {
      private readonly double myA;

      public HenonFunctionDerivate(double a)
        : base(2, new FunctionIO<double>(2), new FunctionIO<double>(2))
      {
        myA = a;
      }

      public void Evaluate()
      {
        Output[0] = 1 - myA * Input[0] * Input[0] + 0.3 * Input[1];
        Output[1] = Input[0];

        Derivates[0].Output[0] = -2 * myA * Input[0];
        Derivates[0].Output[1] = 0.3;
        Derivates[1].Output[0] = 1;
        Derivates[1].Output[1] = 0;
      }
    }
  }
}