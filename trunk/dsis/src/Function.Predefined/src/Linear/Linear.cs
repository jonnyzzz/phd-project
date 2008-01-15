using System;
using DSIS.Core.System;

namespace DSIS.Function.Predefined.Linear
{
  internal class LinearFunction2D : Function<double>, IFunction<double>
  {
    private readonly double myA;
    private readonly double myB;
    private readonly double myC;
    private readonly double myD;

    public LinearFunction2D(double a, double b, double c, double d)
      : base(2)
    {
      myA = a;
      myB = b;
      myC = c;
      myD = d;
    }

    public void Evaluate()
    {
      Output[0] = myA*Input[0] + myB*Input[1];
      Output[1] = myC*Input[0] + myD*Input[1];
    }
  }

  public class Linear2DSystemInfo : DoubleSystemInfoBase
  {
    private readonly double myA;
    private readonly double myB;
    private readonly double myC;
    private readonly double myD;

    public Linear2DSystemInfo(ISystemSpace systemSpace, double a, double b, double c, double d)
      : base(systemSpace)
    {
      myA = a;
      myB = b;
      myC = c;
      myD = d;
    }

    public override string PresentableName
    {
      get { return string.Format("Linear ({0}*x + {1}*y), ({2}*x + {3}*y)", myA, myB, myC, myD); }
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new LinearFunction2D(myA, myB, myC, myD);
    }

    protected override IFunction<double> GetFunctionDerivateInternal()
    {
      throw new NotImplementedException();
    }
  }
}
