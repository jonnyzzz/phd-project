using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring;

namespace DSIS.Function.Predefined.Linear
{
  

  public class Linear2DSystemInfo : DoubleSystemInfoBase
  {
    private readonly double myA;
    private readonly double myB;
    private readonly double myC;
    private readonly double myD;

    public Linear2DSystemInfo(double a, double b, double c, double d)
      : base(2)
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
        Output[0] = myA * Input[0] + myB * Input[1];
        Output[1] = myC * Input[0] + myD * Input[1];
      }
    }
  }

  [UsedBySpring]
  public class Linear2DFactory : DoubleParametersSystemInfoFactoryBase
  {
    public Linear2DFactory(DoubleArrayParser parser, SystemInfoFactory factory)
      : base(2, SystemType.Descrete, "Linear2D", 4, paramz => new Linear2DSystemInfo(paramz[0], paramz[1], paramz[2], paramz[3]), parser, factory)
    {
    }
  }
}
