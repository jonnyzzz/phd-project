using System;
using DSIS.Core.System;

namespace DSIS.InvatriantSetMethod.src
{
  public class IteratingFunction2
  {
    private readonly IFunction<double> myFunction1;
    private readonly IFunction<double> myFunction2;
    private readonly double[] myInput;
    private readonly double[] myOutput;

    public IteratingFunction2(Func<IFunction<double>> factory)
    {
      myFunction1 = factory();
      myFunction2 = factory();

      myInput = new double[myFunction1.Dimension];
      myOutput = new double[myFunction1.Dimension];

      myFunction1.Input = myFunction2.Output = myInput;
      myFunction1.Output = myFunction2.Input = myOutput;
    }

    public double[] Value
    {
      get { return myInput; }
    } 

    public void EvaluatePair()
    {
      myFunction1.Evaluate();
      myFunction2.Evaluate();
    }
  }
}