using EugenePetrenko.Gui2.Kernell2.Document;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.AdaptiveMethod
{
  /// <summary>
  /// Summary description for AdaptiveMethodParameretsImpl.
  /// </summary>
  public class AdaptiveMethodParameretsImpl : IAdaptiveMethodParameters
  {
    private int[] factor;
    private double[] precision;
    private Function function;
    private int upperLimit;

    public AdaptiveMethodParameretsImpl(int[] factor, double[] precision, int upperLimit, Function function)
    {
      this.factor = factor;
      this.precision = precision;
      this.upperLimit = upperLimit;
      this.function = function;
    }

    public int GetFactor(int index)
    {
      return factor[index];
    }

    public double GetPrecision(int index)
    {
      return precision[index];
    }

    public int GetUpperLimit()
    {
      return upperLimit;
    }

    public IFunction GetFunction()
    {
      return function.IFunction;
    }
  }
}