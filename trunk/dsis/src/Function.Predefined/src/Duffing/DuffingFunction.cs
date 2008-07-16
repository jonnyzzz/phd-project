using DSIS.Core.System;

namespace DSIS.Function.Predefined.Duffing
{
  public class DuffingFunction : Function<double>, IFunctionWithTime<double>, IFunction<double>
  {
    private readonly double myK;
    private readonly double myAlpha;
    private readonly double myBeta;

    public DuffingFunction(double alpha, double beta, double k) : base(2)
    {
      myBeta = beta;
      myK = k;
      myAlpha = alpha;
    }

    public void Evaluate(double time)
    {
      Evaluate();
    }

    public void Evaluate()
    {
      var y = Input[1];
      var x = Input[0]; 
      Output[0] = y;
      Output[1] = myAlpha * x - myBeta * x * x * x  - myK * y;
    }
  }
}
