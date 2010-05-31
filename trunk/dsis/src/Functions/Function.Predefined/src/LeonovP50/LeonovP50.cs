using System;
using DSIS.Core.System;
using DSIS.Function.Predefined.Ikeda;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Utils;

namespace DSIS.Function.Predefined.LeonovP50
{
  [Serializable]
  public class LeonovP50Parameters : ISystemInfoParameters
  {
  }

  public class LeonovP50System : DoubleContiniousSystemInfoBase
  {
    public LeonovP50System() : base(2)
    {      
    }

    public override string PresentableName
    {
      get { return "Leonov p50"; }
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new LeonovP50Function();
    }
  }

  public class LeonovP50Function : Function<double>, IFunction<double>
  {
    public LeonovP50Function() : base(2)
    {      
    }

    public void Evaluate()
    {
      var x1 = Input[0];
      var x2 = Input[1];
      
      
      Output[0] = 0.99*x1*x1 + x1*x2 + x2;
      Output[1] = -0.58*x1*x1 + 0.17*x1*x2 + 0.6*x2*x2 - 2*x1 - x2;      
    }
  }

  [SystemInfoComponent]
  public class LeonovP50FunctionFactory : DoubleParametersSystemInfoFactoryBase<LeonovP50Parameters>
  {
    public LeonovP50FunctionFactory() : base(2, SystemType.Continious, "Leonov p50")
    {
    }

    protected override ISystemInfo CreateInfo(LeonovP50Parameters paramz)
    {
      return new LeonovP50System();
    }
  }

  [SystemInfoComponent]
  public class LeonovP50Predefined : PredefinedSystemFactory<LeonovP50FunctionFactory>
  {
    protected override ISystemInfoParameters Parameters
    {
      get { return new LeonovP50Parameters(); }
    }

    public override ISystemSpace Space
    {
      get { return InfoFactory.CreateSpace(2, new[] {-10.0, -10.0}, new[] {10.0, 10.0}, 2L.Fill(2)); }
    }
  }

}