using System;
using DSIS.Graph.Entropy.Impl.Loop.Strange;
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

    public IAction CreateComputeAction(object options)
    {
      return new ParametrizedStrangeEntropyAction((StrangeEntropyEvaluatorParams) options);
    }
  }
}