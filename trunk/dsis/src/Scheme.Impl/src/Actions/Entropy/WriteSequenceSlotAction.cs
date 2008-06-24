using System.Collections.Generic;
using System.IO;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Files;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class WriteSequenceSlotAction : IntegerCoordinateSystemActionBase2
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      return ColBase(base.Check<T,Q>(system, ctx), Create(FileKeys.WorkingFolderKey));
    }

    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      var info = FileKeys.WorkingFolderKey.Get(input);

      var slotStore = SlotStore.Get(input);
      foreach (Key<MeasureSlot<Q>> key in slotStore.AllKeys<MeasureSlot<Q>>())
      {
        string file = info.CreateFileNameFromTemplate("entropy-log-{0}-" + key.ShortName);
        var slot = key.Get(slotStore);

        
        using (TextWriter tw = File.CreateText(file))
        {
          
          for (int i = 0; ; i++)
          {
            MeasureInfo<Q> mi = null;
            bool hasData = false;
            foreach (var measureInfo in slot.ForStep(i))
            {
              hasData = true;
              if (mi != null)
              {
                tw.WriteLine("s{0}p{1} - s{2}p{3} = {4}", mi.Step, mi.Proj, measureInfo.Step, measureInfo.Proj, MeasureInfo<Q>.Rho(mi, measureInfo));
              }
              mi = measureInfo;
            }

            if (!hasData)
              break;

            tw.WriteLine("-----");
          }
        }        
      }      
    }
  }
}