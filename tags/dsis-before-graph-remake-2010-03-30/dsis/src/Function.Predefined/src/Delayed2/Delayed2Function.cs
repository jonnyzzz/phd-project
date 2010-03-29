using System;
using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.Delayed2
{
  public class Delayed2Function : Function<double>, IFunction<double>
  {
    public Delayed2Function() : base(2)
    {
    }

    public void Evaluate()
    {
      double x = Input[0];
      double y = Input[1];
      
      var xx = 1.6*y*(2 - y - x);
      var yy = 1.6*xx*(2 - xx - y);
      
      Output[1] = yy;
      Output[0] = xx;
/*
      var xp = 1.6*xz*(2 - xz - xm);
      var xpp = 1.6*xp*(2 - xp - xz);

      Output[0] = xp;
      Output[1] = xpp;*/
    }
  }

  [Serializable]
  public class Delayed2Options : ISystemInfoParameters
  {
  }

  [SystemInfoComponent]
  public class Delayed2Factory : DoubleParametersSystemInfoFactoryBase<Delayed2Options>
  {
    public Delayed2Factory()
      : base(2,
      SystemType.Discrete,
      "Delayed2")
    {

    }

    protected override ISystemInfo CreateInfo(Delayed2Options paramz)
    {
      return new Delayed2FunctionSystemInfo();
    }
  }


  public class Delayed2FunctionSystemInfo : DoubleDescreteSystemInfoBase
  {
    public Delayed2FunctionSystemInfo()
      : base(2)
    {
    }

    public override string PresentableName
    {
      get { return string.Format("Delayed2"); }
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new Delayed2Function();
    }
  }

}