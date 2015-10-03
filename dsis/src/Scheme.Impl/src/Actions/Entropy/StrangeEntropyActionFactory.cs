using System;
using DSIS.Graph.Entropy.Impl.Loop.Strange;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  [ComputeInveriantMeasureComponent]
  public class StrangeEntropyActionFactory : IComputeInveriantMeasureFactory
  {
    public Type OptionsObjectType
    {
      get { return typeof (StrangeEntropyEvaluatorParams); }
    }

    public bool Compatible(Context ctx)
    {
      return new ParametrizedStrangeEntropyAction(new StrangeEntropyEvaluatorParams()).Compatible(ctx).Count == 0;
    }

    public IAction CreateComputeAction(object options)
    {
      return new ParametrizedStrangeEntropyAction((StrangeEntropyEvaluatorParams) options);
    }

    public string FactoryName
    {
      get { return "Loop-based entropy"; }
    }
  }
}