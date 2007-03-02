using System;
using DSIS.Core.System;

namespace DSIS.Function.Predefined.Julia
{
  public class JuliaFunction : FunctionBase<double>
  {
    public JuliaFunction() : base(2)
    {
    }

    public override void Evaluate()
    {
      Output[0] = Input[0]*Input[0] - Input[1]*Input[1] - 0.12;
      Output[1] = 2 * Input[0]*Input[1] + 0.74;
    }
  }

  public class JuliaFuctionSystemInfoDecorator : DoubleSystemInfoBase
  {
    public JuliaFuctionSystemInfoDecorator(ISystemSpace systemSpace) : base(systemSpace)
    {
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
