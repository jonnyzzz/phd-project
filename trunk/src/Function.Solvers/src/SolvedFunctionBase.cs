using System;
using DSIS.Core.System;

namespace DSIS.Function.Solvers.SimpleSolver
{
  public abstract class SolvedFunctionBase : IDiscreteSystemInfo
  {
    protected readonly IContiniousSystemInfo myFunction;
    protected readonly double myDt;

    protected abstract IFunction<double> GetDoubleFunction();
    protected abstract string PresentableMethodName { get; }

    protected SolvedFunctionBase(IContiniousSystemInfo function, double dt)
    {
      myFunction = function;
      myDt = dt;
    }

    public IFunction<T> GetFunction<T>()
    {
      if (typeof(T) == typeof(double))
      {
        return (IFunction<T>) GetDoubleFunction();
      } else throw new ArgumentException("T");
    }    

    public IFunction<T> GetDerivateFunction<T>(int derivatePower)
    {
      if (derivatePower == 0)
        return GetFunction<T>();

      throw new NotImplementedException();
    }

    public IFunction<T> GetDerivateFunction<T>(int[] unsimmetricDerivate)
    {
      throw new NotImplementedException();
    }

    public Type[] SupportedFunctionTypes
    {
      get { return new Type[] {typeof (double)}; }
    }

    public ISystemSpace SystemSpace
    {
      get { return myFunction.SystemSpace; }
    }

    public string PresentableName
    {
      get { return string.Format("{0} {1}", PresentableMethodName, myFunction.PresentableName); }
    }
  }
}