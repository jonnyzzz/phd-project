using System;
using DSIS.Core.System;

namespace DSIS.Function.Predefined.Ikeda
{
  public class IkedaFunction : FunctionBase<double>
  {
    public IkedaFunction() : base(2)
    {
    }

    public override void Evaluate()
    {
      double t = 0.4 - 6/(1 + Input[0]*Input[0] + Input[1]*Input[1]);
      double cost = Math.Cos(t);
      double sint = Math.Sin(t);
      Output[0] = 2 - 0.9*(Input[0]*cost - Input[1]*sint);
      Output[1] =     0.9*(Input[0]*sint + Input[1]*cost);      
    }
  }

  public class IkedaFunctionSystemInfoDecorator : DoubleSystemInfoBase
  {
    public IkedaFunctionSystemInfoDecorator(ISystemSpace systemSpace) : base(systemSpace)
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

    protected override IFunction<double> GetFunctionDerivateInternal()
    {
      throw new NotImplementedException();
    }
  }
}
