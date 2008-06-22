using System.Collections.Generic;
using System.IO;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Scheme.Actions;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Files;

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

      MeasureSlot<Q>.Get(myKey, slot).RegisterResult(idx.Index, prj.Index, measure);

      output.AddAll(input);
    }
  }

  public class WriteSequenceSlotAction : IntegerCoordinateSystemActionBase2
  {
    private readonly string myKey;

    public WriteSequenceSlotAction(string key)
    {
      myKey = key;
    }

    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      return ColBase(base.Check<T,Q>(system, ctx), Create(FileKeys.WorkingFolderKey));
    }

    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      var info = FileKeys.WorkingFolderKey.Get(input);

      string file = info.CreateFileNameFromTemplate("entropy-log-{0}");
      var slot = MeasureSlot<Q>.Get(myKey, SlotStore.Get(input));

      MeasureInfo<Q> mi = null;
      using (TextWriter tw = File.CreateText(file))
      {
        for (int i = 0;; i++)
        {
          var col = slot.ForStep(i);

          bool hasData = false;
          foreach (var measureInfo in col)
          {
            hasData = true;
            if (mi != null)
            {
              tw.WriteLine("Step {0} - Step{1} = {2}", mi, measureInfo, MeasureInfo<Q>.Rho(mi, measureInfo));
            }
            mi = measureInfo;
          }

          if (!hasData)
            break;
        }
      }      
    }
  }

}