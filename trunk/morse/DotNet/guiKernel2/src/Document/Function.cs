using System;
using System.Text;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Kernell2.Document
{
  [Serializable]
  public class Function
  {
    private readonly string[] equations;
    private readonly IFunction function;
    private readonly string equation;
    
    public Function(string[] equations)
    {
      this.equations = equations;

      equation = "";
      foreach (string eq in equations)
      {
        string eqe = eq.Trim();
        if (!eqe.EndsWith(";"))
        {
          eqe += ";";
        }
        equation += eqe + "\n";
      }

      function = CreateFunction(equation);
    }

    private static IFunction CreateFunction(string equations)
    {
      var functionClass = new CFunctionImplClass();
      IWritableFunction writableFunction = functionClass;
      try
      {
        writableFunction.SetEquations(equations);
      }
      catch (Exception)
      {
        throw new FunctionExceptions(writableFunction.GetLastError());
      }

      return functionClass;
    }

    public string[] Equations
    {
      get { return equations; }
    }

    public string Equation
    {
      get { return equation; }
    }

    public IFunction IFunction
    {
      get { return function; }
    }

    public override string ToString()
    {
      var builder = new StringBuilder();
      builder.Append("Function Object\n[");
      foreach (string eq in equations)
      {
        builder.Append("\t");
        builder.Append(eq);
        builder.Append("\n");
      }
      builder.Append("]\n");
      return builder.ToString();
    }

    public int Iterations
    {
      get { return function.GetIterations(); }
      set { function.SetIterations(value); }
    }

    public static Function CreateTestFunction()
    {
      return new Function(new[]
                            {
                              "_dimension=1;",
                              "y1 = x1;",
                              "y2 = x2;",
                              "space_min1 = 0;",
                              "space_min2 = 0;",
                              "space_max1 = 1;",
                              "space_max1 = 1;",
                              "iterations = 1;",
                              "grid1 = 10;",
                              "grid2 = 10;"
                            });
    }

    public IEvaluateFunction EvaluateFunction
    {
      get { return new EvaluateFunction(function); }
    }
  }
}