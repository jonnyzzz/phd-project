using DSIS.Graph.Entropy.Impl.Loop.Strange;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class ParametrizedStrangeEntropyAction : StrangeEntropyActionBase
  {
    private readonly StrangeEntropyEvaluatorParams myParams;

    public ParametrizedStrangeEntropyAction(StrangeEntropyEvaluatorParams @params)
    {
      myParams = @params;
    }

    protected override StrangeEntropyEvaluatorParams GetParams(Context input)
    {
      return myParams;
    }
  }
}