using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring;

namespace DSIS.Function.Predefined.Logistics
{
  public class LogisticFunction2d : Function<double>, IFunction<double>
  {
    public LogisticFunction2d() : base(2)
    {
    }

    public void Evaluate()
    {
      Output[0] = Input[1]*Input[0]*(1 - Input[0]);
      Output[1] = Input[1];
    }
  }

  public class Logistic2dSystemInfo : DoubleSystemInfoBase
  {
    public Logistic2dSystemInfo()
      : base(2)
    {
    }

    public override string PresentableName
    {
      get { return string.Format("Logistic 2d"); }
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new LogisticFunction2d();
    }
  }

  [UsedBySpring]
  public class Logistics2dFactory : NoParameterSystemInfoFactoryBase
  {
    public Logistics2dFactory(SystemInfoFactory systemFactory)
      : base(
        systemFactory,
        "Logistics2d",
        delegate
          {
            return new Logistic2dSystemInfo();
          })
    {
    }
  }
}