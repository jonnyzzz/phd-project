using System;
using DSIS.Core.System;
using DSIS.Function.Predefined.Ikeda;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.OsipenkoBio
{
  public class OsipenkoBioFunction : Function<double>, IFunction<double>
  {
    public OsipenkoBioFunction()
      : base(2)
    {
    }

    public void Evaluate()
    {
      double x = Input[0];
      double y = Input[1];

      var a = 3.5;
      var b = 1.75;
      var d = 0.1;

      var t = y*(a - b*(x + y))/(1 + d*(x + y));

      var xx = t;
      x = y;
      y = t;
      var yy = y * (a - b * (x + y)) / (1 + d * (x + y)); 

      Output[1] = yy;
      Output[0] = xx;
    }
  }

  [Serializable]
  public class OsipenkoBio : ISystemInfoParameters
  {
  }

  [SystemInfoComponent]
  public class OsipenkoBioPredefined : PredefinedSystemFactory<OsipenkoBioFactory>
  {
    public override ISystemSpace Space
    {
      get { return InfoFactory.CreateSpace(2, new[] { .05, 0 }, new[] { 2.0, 2 }, new[] { 3L, 3 }); }
    }

    protected override ISystemInfoParameters Parameters
    {
      get { return new OsipenkoBio(); }
    }
  }


  [SystemInfoComponent]
  public class OsipenkoBioFactory : DoubleParametersSystemInfoFactoryBase<OsipenkoBio>
  {
    public OsipenkoBioFactory()
      : base(2,
      SystemType.Discrete,
      "Osipenko's Bio")
    {

    }

    protected override ISystemInfo CreateInfo(OsipenkoBio paramz)
    {
      return new OsipenkoBioFunctionSystemInfo();
    }
  }


  public class OsipenkoBioFunctionSystemInfo : DoubleDescreteSystemInfoBase
  {
    public OsipenkoBioFunctionSystemInfo()
      : base(2)
    {
    }

    public override string PresentableName
    {
      get { return string.Format("Osipenko's Bio"); }
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new OsipenkoBioFunction();
    }
  }

}