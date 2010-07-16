using DSIS.Graph.Morse;
using DSIS.Graph.Morse.Howard;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class HowardMorseAction : MorseActionBase<HowardEvaluatorOptions>
  {
    public HowardMorseAction(HowardEvaluatorOptions options)
      : base(options)
    {
    }

    protected override IMorseEvaluator<Q> CreateEvaluator<Q>(IMorseEvaluatorGraph<Q> graph, IMorseEvaluatorCost<Q> cost)
    {
      return new HowardEvaluator<Q>(myOptions, graph, cost);
    }
  }
}