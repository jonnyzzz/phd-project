using System;
using DSIS.Core.System;
using DSIS.Function.Predefined.Ikeda;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Utils;

namespace DSIS.Function.Predefined.Ampilova
{
  [Serializable]
  public class Ref9Parameters : ISystemInfoParameters
  {
  }

  public class Ref9 : DoubleDescreteSystemInfoBase
  {
    public Ref9() : base(3)
    {
    }

    public override string PresentableName
    {
      get { return "Ampi Ref9"; }
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new Ref9Function();
    }
  }

  public class Ref9Function : Function<double>, IFunction<double>
  {
    public Ref9Function() : base(3)
    {
    }

    public void Evaluate()
    {
      var x1 = Input[0];
      var x2 = Input[1];
      var x3 = Input[2];

      const double mu = 0.5;
      const double gamma = 0.1;
      const double lambda = 2.35;

      Output[0] = x2 - mu*x1;
      Output[1] = lambda*x2*(1 - x1);
      Output[2] = x1 - gamma*x3;
    }
  }

  [SystemInfoComponent]
  public class RefFunction9Factory : DoubleParametersSystemInfoFactoryBase<Ref9Parameters>
  {
    public RefFunction9Factory() : base(3, SystemType.Discrete, "Ampi Ref9")
    {
    }

    protected override ISystemInfo CreateInfo(Ref9Parameters paramz)
    {
      return new Ref9();
    }
  }

  [SystemInfoComponent]
  public class Ref9Predefined : PredefinedSystemFactory<RefFunction9Factory>
  {
    protected override ISystemInfoParameters Parameters
    {
      get { return new Ref9Parameters(); }
    }

    public override ISystemSpace Space
    {
      get { return InfoFactory.CreateSpace(3, new[] {-0.38, 0.05, -0.38}, new[] {0.98, 1.45, 0.98}, 2L.Fill(3)); }
    }
  }

}