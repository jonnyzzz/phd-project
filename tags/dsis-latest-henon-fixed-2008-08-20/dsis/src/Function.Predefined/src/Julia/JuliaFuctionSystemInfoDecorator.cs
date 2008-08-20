using System;
using DSIS.Core.System;

namespace DSIS.Function.Predefined.Julia
{
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
}