using System;
using DSIS.Core.System;
using DSIS.Function.Predefined.Ikeda;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.Osipenko2015
{
  public class Osipenko2015Function : Function<double>, IFunction<double>
  {
    public Osipenko2015Function()
      : base(2)
    {
    }

    public void Evaluate()
    {
      double x = Input[0];
      double y = Input[1];

      const double a = 1.511717565;
      const double b = 0.93;

      double t = y + a*x*(1 - x);

      double xx = b*x + t;
      double yy = t;

      Output[1] = yy;
      Output[0] = xx;
    }
  }

  [Serializable]
  public class Osipenko2015 : ISystemInfoParameters
  {
  }

  [SystemInfoComponent]
  public class Osipenko2015Predefined : PredefinedSystemFactory<Osipenko2015Factory>
  {
    public override ISystemSpace Space => InfoFactory.CreateSpace(2, new[] { -2.0, -2.0 }, new[] { 2.0, 2.0 }, new[] { 3L, 3 });

    protected override ISystemInfoParameters Parameters => new Osipenko2015();
  }


  [SystemInfoComponent]
  public class Osipenko2015Factory : DoubleParametersSystemInfoFactoryBase<Osipenko2015>
  {
    public Osipenko2015Factory()
      : base(2,
      SystemType.Discrete,
      "Osipenko's 2015")
    {

    }

    protected override ISystemInfo CreateInfo(Osipenko2015 paramz)
    {
      return new Osipenko2015FunctionSystemInfo();
    }
  }


  public class Osipenko2015FunctionSystemInfo : DoubleDescreteSystemInfoBase
  {
    public Osipenko2015FunctionSystemInfo()
      : base(2)
    {
    }

    public override string PresentableName => "Osipenko\'s 2015";

    protected override IFunction<double> GetFunctionInternal()
    {
      return new Osipenko2015Function();
    }
  }

}