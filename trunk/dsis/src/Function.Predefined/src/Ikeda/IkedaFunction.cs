using System;
using DSIS.Core.System;

namespace DSIS.Function.Predefined.Ikeda
{
  public class IkedaFunction : Function<double>, IFunction<double>
  {
    public IkedaFunction() : base(2)
    {
    }

    public void Evaluate()
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
    private readonly string myName;

    public IkedaFunctionSystemInfoDecorator(ISystemSpace systemSpace) : base(systemSpace)
    {
      myName = "Ikeda";
    }

    public IkedaFunctionSystemInfoDecorator(ISystemSpace systemSpace, string name) : base(systemSpace)
    {
      myName = name;
    }

    public override string PresentableName
    {
      get { return myName; }
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
