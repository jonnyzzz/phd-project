using DSIS.Core.System;

namespace DSIS.Function.Solvers
{
  public class ComposedFunction : IFunction<double>
  {
    private readonly IFunction<double>[] myFunctions;
    private readonly int myDimension;

    public ComposedFunction(params IFunction<double>[] functions)
    {
      myDimension = functions[0].Dimension;
      myFunctions = functions;
      for (int i = 1; i < functions.Length; i++)
      {
        functions[i - 1].Output = new double[myDimension];
        functions[i].Input = functions[i - 1].Output;        
      }
    }

    public void Evaluate()
    {
      foreach (IFunction<double> function in myFunctions)
      {
        function.Evaluate();
      }
    }

    public int Dimension
    {
      get { return myDimension; }
    }

    public double[] Input
    {
      get { return myFunctions[0].Input; }
      set { myFunctions[0].Input = value; }
    }

    public double[] Output
    {
      get { return myFunctions[myFunctions.Length - 1].Output; }
      set { myFunctions[myFunctions.Length - 1].Output = value; }
    }

    public IFunctionIO<double>[] Derivates
    {
      get { return null; }
    }
  }
}