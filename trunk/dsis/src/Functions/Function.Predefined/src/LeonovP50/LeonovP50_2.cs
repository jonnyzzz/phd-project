using System;
using DSIS.Core.System;
using DSIS.Function.Predefined.Ikeda;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Utils;
using DSIS.Utils.Bean;

namespace DSIS.Function.Predefined.LeonovP50
{
  [Serializable]
  public class LeonovP50_2Parameters : ISystemInfoParameters
  {
    public LeonovP50_2Parameters()
    {
      A1 = 0.99; 
      A2 = -0.58; 
      B2 = 0.17;
    }

    [IncludeGenerate(Title = "A1")] public double A1 {get; set;}
    [IncludeGenerate(Title = "A2")] public double A2 {get; set;}
    [IncludeGenerate(Title = "B2")] public  double B2 {get; set;}

    public override string ToString()
    {
      return string.Format("[{0},{1},{2}]", A1, A2, B2);
    }
  }

  public class LeonovP50_2System : DoubleContiniousSystemInfoBase
  {
    private readonly LeonovP50_2Parameters myParams;

    public LeonovP50_2System(LeonovP50_2Parameters ps) : base(2)
    {
      myParams = ps;
    }

    public override string PresentableName
    {
      get { return "Lp" + myParams; }
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new LeonovP50_2Function(myParams);
    }
  }

  public class LeonovP50_2Function : Function<double>, IFunction<double>
  {
    private readonly LeonovP50_2Parameters myParams;
    public LeonovP50_2Function(LeonovP50_2Parameters ps) : base(2)
    {
      myParams = ps;
    }

    public void Evaluate()
    {
      var x1 = Input[0];
      var x2 = Input[1];

      var x1px1 = x1 * x1;
      var x1px2 = x1 * x2;

      Output[0] = myParams.A1 * x1px1 + x1px2 + x2 + x1;
      Output[1] = myParams.A2 * x1px1 + myParams.B2 * x1px2 + 0.6 * x2 * x2 - 2 * x1 - x2;
    }
  }

  [SystemInfoComponent]
  public class LeonovP50_2FunctionFactory : DoubleParametersSystemInfoFactoryBase<LeonovP50_2Parameters>
  {
    public LeonovP50_2FunctionFactory() : base(2, SystemType.Continious, "Leonov p50 [a1,a2,b2]")
    {
    }

    protected override ISystemInfo CreateInfo(LeonovP50_2Parameters paramz)
    {
      return new LeonovP50_2System(paramz);
    }
  }

  [SystemInfoComponent]
  public class LeonovP50_2Predefined : PredefinedSystemFactory<LeonovP50_2FunctionFactory>
  {
    protected override ISystemInfoParameters Parameters
    {
      get { return new LeonovP50_2Parameters(); }
    }

    public override ISystemSpace Space
    {
      get { return InfoFactory.CreateSpace(2, new[] {-10.0, -10.0}, new[] {10.0, 10.0}, 2L.Fill(2)); }
    }
  }

}