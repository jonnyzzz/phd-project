using System.Collections.Generic;
using System.IO;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Files;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class WriteSequenceSlotAction : ActionBase
  {
    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return CheckContext(ctx, Create(FileKeys.WorkingFolderKey));
    }

    protected override void Apply(Context ctx, Context result)
    {
      var info = FileKeys.WorkingFolderKey.Get(ctx);

      var slotStore = SlotStore.Get(ctx);
      foreach (var key in new List<Key<MeasureSlot>>(slotStore.AllKeys<MeasureSlot>()))
      {
        string file = info.CreateFileNameFromTemplate("entropy-log-{0}-" + key.ShortName);
        var slot = key.Get(slotStore);

        
        using (TextWriter tw = File.CreateText(file))
        {
          
          for (int i = 0; ; i++)
          {
            IMeasureInfo mi = null;
            bool hasData = false;
            foreach (IMeasureInfo measureInfo in slot.ForStep(i))
            {
              hasData = true;
              if (mi != null)
              {
                tw.WriteLine("s{0}p{1} - s{2}p{3} = {4}", mi.Step, mi.Proj, measureInfo.Step, measureInfo.Proj, mi.Dist(measureInfo));
              }
              mi = measureInfo;
            }

            if (!hasData)
              break;

            tw.WriteLine("-----");
          }
        }        
        slotStore.Remove(key);
      }      
    }
  }
}