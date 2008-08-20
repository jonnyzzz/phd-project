using EugenePetrenko.Gui2.Kernell2.Document;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.AdaptiveBox
{
  /// <summary>
  /// Summary description for AdaptiveBoxParametersImpl.
  /// </summary>
  public class AdaptiveBoxParametersImpl : IAdaptiveBoxParameters
  {
    private Function function;
    private int[] factor;
    private double[] prec;

    public AdaptiveBoxParametersImpl(Function function, int[] factor, double[] prec)
    {
      this.function = function;
      this.factor = factor;
      this.prec = prec;
    }

    public IFunction GetFunction()
    {
      return function.IFunction;
    }

    public int GetFactor(int id)
    {
      return factor[id];
    }

    public double GetPrecision(int id)
    {
      return prec[id];
    }
  }
}