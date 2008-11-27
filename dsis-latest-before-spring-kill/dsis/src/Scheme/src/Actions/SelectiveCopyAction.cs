using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Actions
{
  public class SelectiveCopyAction : ActionBase
  {
    private readonly List<IKey> myKeysToFilter = new List<IKey>();

    public SelectiveCopyAction(params IKey[] keysToFilter)
    {
      myKeysToFilter = new List<IKey>(keysToFilter);
    }

    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return EmptyArray<ContextMissmatch>.Instance;
    }

    protected override void Apply(Context ctx, Context result)
    {
      foreach (IKey key in myKeysToFilter)
      {
        key.Copy(ctx, result);
      }
    }    
  }
}