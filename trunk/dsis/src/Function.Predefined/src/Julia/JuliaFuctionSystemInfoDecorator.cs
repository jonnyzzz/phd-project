using DSIS.Core.System;

namespace DSIS.Function.Predefined.Julia
{
  public class JuliaFuctionSystemInfoDecorator : DoubleDescreteSystemInfoBase
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
  }
}