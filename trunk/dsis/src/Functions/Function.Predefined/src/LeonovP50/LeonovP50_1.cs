using System;
using DSIS.Core.System;
using DSIS.Function.Predefined.Ikeda;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Utils;

namespace DSIS.Function.Predefined.LeonovP50
{
  [Serializable]
  public class LeonovP50_1Parameters : ISystemInfoParameters
  {
  }

  public class LeonovP50_1System : DoubleContiniousSystemInfoBase
  {
    public LeonovP50_1System() : base(2)
    {      
    }

    public override string PresentableName
    {
      get { return "Leonov p50 fixed"; }
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new LeonovP50_1Function();
    }
  }

  public class LeonovP50_1Function : Function<double>, IFunction<double>
  {
    public LeonovP50_1Function() : base(2)
    {      
    }

    public void Evaluate()
    {
      var x1 = Input[0];
      var x2 = Input[1];

      var x1px1 = x1*x1;
      var x1px2 = x1 * x2;

      Output[0] = 0.99 * x1px1 + x1px2 + x2 + x1;
      Output[1] = -0.58 * x1px1 + 0.17 * x1px2 + 0.6 * x2 * x2 - 2 * x1 - x2;      
    }
  }

  [SystemInfoComponent]
  public class LeonovP50_1FunctionFactory : DoubleParametersSystemInfoFactoryBase<LeonovP50_1Parameters>
  {
    public LeonovP50_1FunctionFactory() : base(2, SystemType.Continious, "Leonov p50 fixed")
    {
    }

    protected override ISystemInfo CreateInfo(LeonovP50_1Parameters paramz)
    {
      return new LeonovP50_1System();
    }
  }

  [SystemInfoComponent]
  public class LeonovP50_1Predefined : PredefinedSystemFactory<LeonovP50_1FunctionFactory>
  {
    protected override ISystemInfoParameters Parameters
    {
      get { return new LeonovP50_1Parameters(); }
    }

    public override ISystemSpace Space
    {
      get { return InfoFactory.CreateSpace(2, new[] {-10.0, -10.0}, new[] {10.0, 10.0}, 2L.Fill(2)); }
    }
  }

}