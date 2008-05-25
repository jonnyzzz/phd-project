using System;
using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring;

namespace DSIS.Function.Predefined.VanDerPol
{
  public class VanDerPolSystemInfo : DoubleSystemInfoBase
  {
    private readonly double myA;

    public VanDerPolSystemInfo(double a)
      : base(2)
    {
      myA = a;
    }

    public override string PresentableName
    {
      get { return "Van-der-Pol"; }
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new VanDerPolFunction(myA);
    }

    protected override IFunction<double> GetFunctionDerivateInternal()
    {
      throw new NotImplementedException();
    }
  }

  [UsedBySpring]
  public class VanDerPolFactory : DoubleParametersSystemInfoFactoryBase
  {
    //todo: Provide continious system converter
    public VanDerPolFactory(DoubleArrayParser parser, SystemInfoFactory factory)
      : base(2, SystemType.Continious, "Van-der-Pol TODO:", 1, paramz => new VanDerPolSystemInfo(paramz[0]), parser,factory)
    {
    }
  }
}
