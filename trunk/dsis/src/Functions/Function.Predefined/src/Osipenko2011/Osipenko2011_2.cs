using System;
using DSIS.Core.System;
using DSIS.Function.Predefined.Ikeda;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.Osipenko2011
{
  public class Osipenko2011_2_Function : Function<double>, IFunction<double>
  {
    private readonly Osipenko2011_2_Parameters myParameters;
    public Osipenko2011_2_Function(Osipenko2011_2_Parameters parameters)
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
      var r = myParameters.R;
      
      var fx = y;
      var fy = z;
      var fz = a*z*(1-b*x-c*y-r*z)/(1+d*(x+y+z));


      Output[0] = fx;
      Output[1] = fy;
      Output[2] = fz;
    }
  }

  [Serializable]
  public class Osipenko2011_2_Parameters : ISystemInfoParameters
  {
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }
    public double D { get; set; }
    public double R { get; set; }

    public static readonly Osipenko2011_2_Parameters SET_1 = new Osipenko2011_2_Parameters{
      A = 157,
      B = 0.25,
      C = 0.36,
      R = 1,
      D = 25.7,
    };

    public static readonly Osipenko2011_2_Parameters SET_2 = new Osipenko2011_2_Parameters {
      A = 157,
      B = 0.24,
      C = 0.36,
      R = 1,
      D = 30, //26 < d < 30
    };

    public Osipenko2011_2_Parameters()
    {
      A = 157;
      B = 0.25;
      C = 0.36;
      R = 1;
      D = 25.7;
    }
  }

  [SystemInfoComponent]
  public class Osipenko2011_2_Predefined : PredefinedSystemFactory<Osipenko2011_2_Factory>
  {
    public override ISystemSpace Space
    {
      get { return InfoFactory.CreateSpace(3, new[] { 0.0, 0, 0}, new[] { 1.0, 1, 1}, new[] { 3L, 3, 3 }); }
    }

    protected override ISystemInfoParameters Parameters
    {
      get { return new Osipenko2011_2_Parameters(); }
    }
  }


  [SystemInfoComponent]
  public class Osipenko2011_2_Factory : DoubleParametersSystemInfoFactoryBase<Osipenko2011_2_Parameters>
  {
    public Osipenko2011_2_Factory()
      : base(3,
      SystemType.Discrete,
      "Osipenko's 2011 2")
    {

    }

    protected override ISystemInfo CreateInfo(Osipenko2011_2_Parameters paramz)
    {
      return new Osipenko2011_2_FunctionSystemInfo(paramz);
    }
  }


  public class Osipenko2011_2_FunctionSystemInfo : DoubleDescreteSystemInfoBase
  {
    private readonly Osipenko2011_2_Parameters myParameters;
    public Osipenko2011_2_FunctionSystemInfo(Osipenko2011_2_Parameters parameters)
      : base(3)
    {
      myParameters = parameters;
    }

    public override string PresentableName
    {
      get { return string.Format("Osipenko's 2011 2"); }
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new Osipenko2011_2_Function(myParameters);
    }
  }

}