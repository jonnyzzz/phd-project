using System;
using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring;

namespace DSIS.Function.Predefined.Julia
{
  public class JuliaFunction : Function<double>, IFunction<double>
  {
    public JuliaFunction() : base(2)
    {
    }

    public void Evaluate()
    {
      Output[0] = Input[0]*Input[0] - Input[1]*Input[1] - 0.12;
      Output[1] = 2 * Input[0]*Input[1] + 0.74;
    }
  }

  public class JuliaFuctionSystemInfoDecorator : DoubleSystemInfoBase
  {
    public JuliaFuctionSystemInfoDecorator()
      : base(2)
    {
    }

    public override string PresentableName
    {
      get { return "Julia"; }
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new JuliaFunction();
    }

    protected override IFunction<double> GetFunctionDerivateInternal()
    {
      throw new NotImplementedException();
    }
  }  

  [UsedBySpring]
  public class JuliaFactory : NoParameterSystemInfoFactoryBase
  {
    public JuliaFactory(SystemInfoFactory factory)
      : base(factory, "Julia", delegate { return new JuliaFuctionSystemInfoDecorator(); })
    {
    }
  }
}
