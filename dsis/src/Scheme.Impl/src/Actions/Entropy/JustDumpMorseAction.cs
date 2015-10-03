using DSIS.Graph.Morse;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class JustDumpMorseAction : MorseActionBase<JustDumpMorseAction.JustDumpMorseOptions>
  {
    public JustDumpMorseAction(JustDumpMorseOptions options) : base(options)
    {
    }

    protected override IMorseEvaluator<Q> CreateEvaluator<Q>(IMorseEvaluatorGraph<Q> graph, IMorseEvaluatorCost<Q> cost)
    {
      return new FakeEvaluator<Q>(graph, cost);
    }

    public class JustDumpMorseOptions : IMorseOptions
    {
      public string MethodName
      {
        get { return "JustDumpGraph"; }
      }

      public double Eps
      {
        get { return 0; }
      }
    }

    private class FakeEvaluator<Q> : MorseEvaluatorBase<Q, object>, IMorseEvaluator<Q>
    {
      public FakeEvaluator(IMorseEvaluatorGraph<Q> graphComponent, 
        IMorseEvaluatorCost<Q> cost) : base(graphComponent, cost, (x,v)=>x)
      {
      }

      protected override ComputationResult<Q> MinimizeInternal()
      {
        return new ComputationResult<Q>(1, EmptyArray<Q>.Instance);
      }
    }
  }
}