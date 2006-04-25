using System;
using System.Text;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Kernell2.Document
{
  [Serializable]
  public class Function
  {
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

      function =
        createFunction(equation);
    }

    private IFunction createFunction(string equations)
    {
      CFunctionImplClass functionClass = new CFunctionImplClass();
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

    private string[] equations;
    private IFunction function;
    private string equation;

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
      StringBuilder builder = new StringBuilder();
      builder.Append("Function Object\n[");
      foreach (string equation in equations)
      {
        builder.Append("\t");
        builder.Append(equation);
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
      return new Function(new string[]
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