using System;
using System.Collections.Generic;
using DSIS.Core.System;

namespace DSIS.Function.Solvers.SimpleSolver
{
  public abstract class SolvedFunctionBase : ISystemInfo
  {
    protected readonly int mySteps;
    protected readonly double myDt;
    protected readonly ISystemInfo myFunction;    

    protected abstract IFunction<double> GetDoubleFunctionOne(double[] precision);    
    protected abstract string PresentableMethodName { get; }
    
    protected SolvedFunctionBase(ISystemInfo function, int steps, double dt)
    {
      myFunction = function;
      mySteps = steps;
      myDt = dt;
    }    

    public IFunction<T> GetFunction<T>(T[] precision)
    {
      if (typeof(T) == typeof(double))
      {
        return (IFunction<T>) GetDoubleFunction((double[])(object)precision);
      } else throw new ArgumentException("T");
    }

    public IFunction<T> GetFunction<T>(T precision)
    {
      T[] ts = new T[SystemSpace.Dimension];
      for (int i = 0; i < SystemSpace.Dimension; i++)
      {
        ts[i] = precision;
      }
      return GetFunction<T>(ts);
    }


    private IFunction<double> GetDoubleFunction(double[] precision)
    {
      if (mySteps == 1)
      {
        return GetDoubleFunctionOne(precision);
      } else
      {
        List<IFunction<double>> myFuncs = new List<IFunction<double>>();
        for(int i=0; i<mySteps; i++)
        {
          myFuncs.Add(GetDoubleFunctionOne(precision));
        }
        return new ComposedFunction(myFuncs.ToArray());
      }
    }

    public IFunction<T> GetDerivateFunction<T>(T[] precision, int derivatePower)
    {    
      throw new NotImplementedException();
    }

    public IFunction<T> GetDerivateFunction<T>(T[] precision, int[] unsimmetricDerivate)
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