using System;
using System.Collections.Generic;
using DSIS.Core.System;

namespace DSIS.Function.Solvers
{
  public abstract class SolvedFunctionBase<Context> : ISystemInfo
  {
    private readonly int myDimension;
    protected readonly int mySteps;
    protected readonly double myDt;
    protected readonly ISystemInfo myFunction;

    protected abstract Context CreateContext(double[] precision);
    protected abstract IFunction<double> GetDoubleFunctionOne(Context ctx, double[] precision);    
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

    private IFunction<double> GetDoubleFunction(double[] precision)
    {
      Context ctx = CreateContext(precision);

      if (mySteps == 1)
        return GetDoubleFunctionOne(ctx, precision);

      var myFuncs = new List<IFunction<double>>();
      for(int i = 0; i< mySteps; i++)
      {
        myFuncs.Add(GetDoubleFunctionOne(ctx, precision));
      }
      return new ComposedFunction(myFuncs.ToArray());
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

    protected class FunctionBase
    {
      protected readonly int myDimension;
      private readonly ISystemInfo myFunction;

      protected FunctionBase(int dimension, ISystemInfo function)
      {
        myDimension = dimension;
        myFunction = function;
      }

      public IFunctionIO<double>[] Derivates
      {
        get { return null; }
      }

      protected IFunction<double> Create(double[] size, out double[] input, out double[] output)
      {
        IFunction<double> func = myFunction.GetFunction<double>(size);
        input = func.Input = new double[myDimension];
        output = func.Output = new double[myDimension];
        return func;
      }

      public int Dimension
      {
        get { return myDimension; }
      }
    }

  }
}