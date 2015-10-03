using DSIS.Core.System;

namespace DSIS.Function.Solvers
{
  public abstract class SolvedFunctionBase : SolvedFunctionBase<object>
  {
    protected SolvedFunctionBase(ISystemInfo function, int steps, double dt) : base(function, steps, dt)
    {
    }

    protected override object CreateContext(double[] precision)
    {
      return new object(); 
    }

    protected override IFunction<double> GetDoubleFunctionOne(object ctx, double[] precision)
    {
      return GetDoubleFunctionOne(precision);
    }

    protected abstract IFunction<double> GetDoubleFunctionOne(double[] precision);
  }
}