using System.Collections.Generic;
using DSIS.Graph.Entropy.Impl.Loop.Strange;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class StrangeEntropyAction : StrangeEntropyActionBase
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(Context ctx)
    {
      return ColBase(base.Check<T, Q>(ctx), Create(Keys.StrangeEntropyEvaluatorParams));
    }

    protected override StrangeEntropyEvaluatorParams GetParams(Context input)
    {
      return Keys.StrangeEntropyEvaluatorParams.Get(input);
    }
  }
}
