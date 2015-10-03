using System;
using DSIS.Graph.Morse;
using DSIS.Graph.Morse.JVR;

namespace DSIS.Scheme.Impl.Actions.Entropy
{


  public class JVRMorseAction : MorseActionBase<JVREvaluatorOptions>
  {
    public JVRMorseAction(JVREvaluatorOptions options) : base(options)
    {
    }

    protected override IMorseEvaluator<Q> CreateEvaluator<Q>(IMorseEvaluatorGraph<Q> graph, IMorseEvaluatorCost<Q> cost)
    {
      return new JVREvaluator<Q>(myOptions, graph, cost);
    }
  }
}