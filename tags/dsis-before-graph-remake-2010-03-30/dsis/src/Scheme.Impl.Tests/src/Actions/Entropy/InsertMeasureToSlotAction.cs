using System.Collections.Generic;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Scheme.Actions;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class InsertMeasureToSlotAction : IntegerCoordinateSystemActionBase2
  {
    private readonly ILoopAction myLoopAction;
    private readonly ILoopAction myProjAction;
    private readonly string myKey;

    public InsertMeasureToSlotAction(string key, ILoopAction loopAction, ILoopAction projAction)
    {
      myLoopAction = loopAction;
      myProjAction = projAction;
      myKey = key;
    }

    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      return ColBase(base.Check<T, Q>(system, ctx),
                     Create(Keys.GraphMeasure<Q>()),
                     Create(myLoopAction.Key),
                     Create(myProjAction.Key)
                     );
    }


    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      IGraphMeasure<Q> measure = Keys.GraphMeasure<Q>().Get(input);
      SlotStore slot = SlotStore.Get(input);
      var idx = myLoopAction.Key.Get(input);
      var prj = myProjAction.Key.Get(input);

      MeasureSlotHelper.Get(myKey, slot).RegisterResult(idx.Index, prj.Index, measure);

      output.AddAll(input);
    }
  }
}