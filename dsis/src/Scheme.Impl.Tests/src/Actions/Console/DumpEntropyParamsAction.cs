using System.Collections.Generic;
using DSIS.Graph.Entropy.Impl.Loop.Strange;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Files;

namespace DSIS.Scheme.Impl.Actions.Console
{
  public class DumpEntropyParamsAction : IntegerCoordinateSystemActionBase2
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      return ColBase(base.Check<T, Q>(system, ctx), Create(Keys.StrangeEntropyEvaluatorParams));
    }

    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      StrangeEntropyEvaluatorParams ps = Keys.StrangeEntropyEvaluatorParams.Get(input);      
      Logger.Instance(input).Write("Compute entropy of type {0}", ps.PresentableName);
    }
  }
}