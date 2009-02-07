using System;
using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.OsipenkoBio
{
  public class OsipenkoBio2Function : Function<double>, IFunction<double>
  {
    public OsipenkoBio2Function()
      : base(2)
    {
    }

    public void Evaluate()
    {
      double x = Input[0];
      double y = Input[1];

      var t = 1.1*y*(2 - (y*x)/(1 + 0.09*(x + y)));

      var xx = t;
      x = y;
      y = t;
      var yy = 1.1 * y * (2 - (y * x) / (1 + 0.09 * (x + y)));

      Output[1] = yy;
      Output[0] = xx;
    }
  }

  [Serializable]
  public class OsipenkoBio2 : ISystemInfoParameters
  {
  }

  [SystemInfoComponent]
  public class OsipenkoBio2Factory : DoubleParametersSystemInfoFactoryBase<OsipenkoBio2>
  {
    public OsipenkoBio2Factory()
      : base(2,
      SystemType.Discrete,
      "Osipenko's Bio2")
    {

    }

    protected override ISystemInfo CreateInfo(OsipenkoBio2 paramz)
    {
      return new OsipenkoBio2FunctionSystemInfo();
    }
  }


  public class OsipenkoBio2FunctionSystemInfo : DoubleDescreteSystemInfoBase
  {
    public OsipenkoBio2FunctionSystemInfo()
      : base(2)
    {
    }

    public override string PresentableName
    {
      get { return string.Format("Osipenko's Bio2"); }
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new OsipenkoBio2Function();
    }
  }

}