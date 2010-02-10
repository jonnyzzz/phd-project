using System;
using DSIS.Core.System;

namespace DSIS.Function.Predefined.Ikeda
{
  public class IkedaFunctionSystemInfoDecorator : DoubleDescreteSystemInfoBase
  {
    public IkedaFunctionSystemInfoDecorator() : base(2)
    {
    }

    public override string PresentableName
    {
      get { return "Ikeda"; }
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new IkedaFunction();
    }
  }
}