using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl
{
  public class BoxMethodParametersImpl : IBoxMethodParameters
  {
    private bool useDerivate;
    private readonly IFunction function;
    private int[] factor;

    public IFunction GetFunction()
    {
      return function;
    }

    public int GetFactor(int index)
    {
      return factor[index];
    }

    public bool UseDerivate()
    {
      return useDerivate;
    }

    public BoxMethodParametersImpl(bool useDerivate, IFunction function, int[] factor)
    {
      this.useDerivate = useDerivate;
      this.function = function;
      this.factor = factor;
    }
  }
}