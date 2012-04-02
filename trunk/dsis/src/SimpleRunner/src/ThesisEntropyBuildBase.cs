using System;
using System.Collections.Generic;
using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.Graph.Entropy.Impl.Loop.Strange;
using DSIS.Graph.Entropy.Impl.Loop.Weight;
using DSIS.Scheme;
using DSIS.Scheme.Impl.Actions.Entropy;
using DSIS.Utils;
using System.Linq;

namespace DSIS.SimpleRunner
{
  public abstract class ThesisEntropyBuildBase<T> : ThesisEntropyBuildBase<T, EntropyComputationMode>
    where T : EntropyComputationData, ICloneable<T>
  {

    protected override IEnumerable<EntropyComputationMode> GetEntropComputationMode(AfterSIParams<T> afterSIParams)
    {
      return afterSIParams.ComputationData.EntropyMode;
    }

    protected override void RemoveActionFrom(List<T> actions, T computationData, EntropyComputationMode mode)
    {
      computationData.EntropyMode = computationData.EntropyMode.Where(x => x != mode).ToArray();
      if (computationData.EntropyMode.Count() == 0)
      {
        actions.RemoveAll(x => ReferenceEquals(x, computationData));
      }
    }

    protected override Func<Pair<IAction, string>> GetEntropyAction(EntropyComputationMode mode)
    {
      switch(mode)
      {
        case EntropyComputationMode.Eigen:
          return CreateEigenAction;

        case EntropyComputationMode.JVR:
          return () => CreateJVRMeasureAction(1e-5);

        case EntropyComputationMode.SmartLoopsConst:
          return () => CreateStrangeEntropySmart(EntropyLoopWeights.CONST);

        case EntropyComputationMode.SmartLoopsLinear:
          return () => CreateStrangeEntropySmart(EntropyLoopWeights.ONE);

        case EntropyComputationMode.SmartLoopsSquare:
          return () => CreateStrangeEntropySmart(EntropyLoopWeights.TWO);

        case EntropyComputationMode.LoopsConst:
          return CreateLoopCountAction;
        default:
          throw new NotImplementedException("Entropy mode " + mode + " is not supported");
      }
    }

    private static Pair<IAction, string> CreateEigenAction()
    {
      var options = new EigenEntropyOptions();
      return Pair.Of<IAction, string>(new EigenEntropyAction(options), options.Present);
    }

    private static Pair<IAction, string> CreateLoopCountAction()
    {
      var opts = new StrangeEntropyEvaluatorParams
                   {
                     EntropyType = StrangeEvaluatorType.WeightSearch_1,
                     LoopWeight = EntropyLoopWeights.CONST,
                     Strategy = StrangeEvaluatorStrategy.FIRST
                   };
      return Pair.Of<IAction, string>(new ParametrizedStrangeEntropyAction(opts), opts.Present);
    }

    private static Pair<IAction, string> CreateStrangeEntropySmart(IEntropyLoopWeightCallback @const)
    {
      var opts = new StrangeEntropyEvaluatorParams
                   {
                     EntropyType = StrangeEvaluatorType.WeightSearch_Limited,
                     LoopWeight = @const,
                     Strategy = StrangeEvaluatorStrategy.SMART
                   };
      return Pair.Of<IAction, string>(new ParametrizedStrangeEntropyAction(opts), opts.Present);
    }


    private static Pair<IAction, string> CreateJVRMeasureAction(double eps)
    {
      var opts = new JVRMeasureOptions
                   {
                     IncludeSelfEdge = false, 
                     InitialWeight = EntropyEdgeWeights.CONST, 
                     EPS = eps, 
                     ExitCondition = JVRExitCondition.AvgSummError
                   };
      return Pair.Of((IAction) new JVRMeasureAction(opts), opts.Present);
    }
 }
}