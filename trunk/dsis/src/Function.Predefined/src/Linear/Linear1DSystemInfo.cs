using DSIS.Core.System;

namespace DSIS.Function.Predefined.Linear
{
  public class Linear1DSystemInfo : DoubleSystemInfoBase
  {
    private readonly double myA;
    private readonly double myB;
    
    public Linear1DSystemInfo(ISystemSpace systemSpace, double a, double b)
      : base(systemSpace)
    {
      myA = a;
      myB = b;
    }

    public override string PresentableName
    {
      get { return string.Format("Linear ({0}*x + {1})", myA, myB); }
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new LinearFunction1D(myA, myB);
    }

    internal class LinearFunction1D : Function<double>, IFunction<double>
    {
      private readonly double myA;
      private readonly double myB;

      public LinearFunction1D(double a, double b)
        : base(1)
      {
        myA = a;
        myB = b;
      }

      public void Evaluate()
      {
        Output[0] = myA * Input[0] + myB;
      }
    }
  }
}