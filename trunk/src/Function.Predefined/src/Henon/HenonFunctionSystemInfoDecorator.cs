using DSIS.Core.System;

namespace DSIS.Function.Predefined.Henon
{
  public class HenonFunctionSystemInfoDecorator : DoubleSystemInfoBase
  {
    private readonly double myA;

    public HenonFunctionSystemInfoDecorator(ISystemSpace systemSpace, double a) : base(systemSpace)
    {
      myA = a;
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new HenonFunction(myA);
    }

    protected override IFunction<double> GetFunctionDerivateInternal()
    {
      return new HenonFunctionDerivate(myA);
    }
  }
}