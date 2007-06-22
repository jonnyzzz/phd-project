using System;
using DSIS.Core.System;

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

  public class JuliaFuctionSystemInfoDecorator : DoubleDescreteSystemInfoBase
  {
    public JuliaFuctionSystemInfoDecorator(ISystemSpace systemSpace)
      : base(systemSpace)
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
}
