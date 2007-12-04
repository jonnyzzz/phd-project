using System.Collections.Generic;
using DSIS.Graph;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Entropy
{

  public class StrangeEntropyAction : IntegerCoordinateSystemActionBase2
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      return Col(base.Check<T, Q>(system, ctx),
                 Create(Keys.GraphComponents<Q>())
//        Create(Keys.StrangeEntropyParamsKey));
        );
    }

    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      IGraphStrongComponents<Q> comps = Keys.GraphComponents<Q>().Get(input);
      /*LoopBasedEntropyParams ps = Keys.StrangeEntropyParamsKey.Get(input);
      

      StrangeEntropyEvaluator<Q> eval = new StrangeEntropyEvaluator<Q>(ps.LoopWeight, ps.EntropyType, ps.Strategy);
      eval.ComputeEntropy();*/
    }    
  }
}
