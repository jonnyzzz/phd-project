using DSIS.Core.System;
using DSIS.Function.Predefined.Delayed;

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
      Output[0] = Input[1];
      Output[1] = -myK * Input[1] - myAlpha * Input[0] - myBeta * Input[0] * Input[0] * Input[0];
    }
  }
}
