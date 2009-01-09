using System;
using System.Collections.Generic;
using DSIS.Core.System;

namespace DSIS.Function.Solvers
{
  public abstract class SolvedFunctionBase : ISystemInfo
  {
    private readonly int myDimension;
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
      myDimension = function.Dimension;
    }    

    public IFunction<T> GetFunction<T>(T[] precision)
    {
      if (typeof(T) == typeof(double))
      {
        return (IFunction<T>) GetDoubleFunction((double[])(object)precision);
      }
      throw new ArgumentException("T");
    }

    public IFunction<T> GetFunction<T>(T precision)
    {
      var ts = new T[myDimension];
      for (int i = 0; i < myDimension; i++)
      {
        ts[i] = precision;
      }
      return GetFunction<T>(ts);
    }


    private IFunction<double> GetDoubleFunction(double[] precision)
    {
      if (mySteps == 1)
        return GetDoubleFunctionOne(precision);

      var myFuncs = new List<IFunction<double>>();
      for(int i=0; i<mySteps; i++)
      {
        myFuncs.Add(GetDoubleFunctionOne(precision));
      }
      return new ComposedFunction(myFuncs.ToArray());
    }

    public IFunction<T> GetDerivateFunction<T>(T[] precision, int derivatePower)
    {    
      throw new NotImplementedException();
    }

    public IFunction<T> GetDerivateFunction<T>(T[] precision, int[] unsimmetricDerivate)
    {
      throw new NotImplementedException();
    }

    public SystemType Type
    {
      get { return SystemType.Discrete; }
    }

    public Type[] SupportedFunctionTypes
    {
      get { return new[] {typeof (double)}; }
    }

    public string PresentableName
    {
      get { return string.Format("{1}@{0}", PresentableMethodName, myFunction.PresentableName); }
    }

    public int Dimension
    {
      get { return myDimension; }
    }
  }
}