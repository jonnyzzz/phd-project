using System;
using DSIS.Core.System;
using DSIS.Function.Predefined.Ikeda;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.Osipenko2011
{
  public class Osipenko2011_1_Function : Function<double>, IFunction<double>
  {
    private readonly Osipenko2011_1_Parameters myParameters;
    public Osipenko2011_1_Function(Osipenko2011_1_Parameters parameters)
      : base(3)
    {
      myParameters = parameters;
    }

    public void Evaluate()
    {
      double x = Input[0];
      double y = Input[1];
      double z = Input[2];

      var a = myParameters.A;
      var b = myParameters.B;
      var c = myParameters.C;
      var d = myParameters.D;
      
      var fx = x+d*(z+(y-a)*x);
      var fy = y+d*(1-b*y-x*x);
      var fz = z + d*(-x - c*z);

      Output[0] = fx;
      Output[1] = fy;
      Output[2] = fz;
    }
  }

  [Serializable]
  public class Osipenko2011_1_Parameters : ISystemInfoParameters
  {
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }
    public double D { get; set; }

    public Osipenko2011_1_Parameters()
    {
      A = 0.00001;
      B = 0.37;
      C = 0.85;
      D = 0.21; // 0.2<d<0.3
    }
  }

  [SystemInfoComponent]
  public class Osipenko2011_1_Predefined : PredefinedSystemFactory<Osipenko2011_1_Factory>
  {
    public override ISystemSpace Space
    {
      get { return InfoFactory.CreateSpace(3, new[] { -3.5, -3.5, -2.5}, new[] { 3.5, 3.5, 2.5}, new[] { 3L, 3, 3 }); }
    }

    protected override ISystemInfoParameters Parameters
    {
      get { return new Osipenko2011_1_Parameters(); }
    }
  }


  [SystemInfoComponent]
  public class Osipenko2011_1_Factory : DoubleParametersSystemInfoFactoryBase<Osipenko2011_1_Parameters>
  {
    public Osipenko2011_1_Factory()
      : base(3,
      SystemType.Discrete,
      "Osipenko's 2011 1")
    {

    }

    protected override ISystemInfo CreateInfo(Osipenko2011_1_Parameters paramz)
    {
      return new Osipenko2011_1_FunctionSystemInfo(paramz);
    }
  }


  public class Osipenko2011_1_FunctionSystemInfo : DoubleDescreteSystemInfoBase
  {
    private readonly Osipenko2011_1_Parameters myParameters;
    public Osipenko2011_1_FunctionSystemInfo(Osipenko2011_1_Parameters parameters)
      : base(3)
    {
      myParameters = parameters;
    }

    public override string PresentableName
    {
      get { return string.Format("Osipenko's 2011 1"); }
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new Osipenko2011_1_Function(myParameters);
    }
  }

}