using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Actions
{
  public class FilterProxyAction : ActionBase
  {
    private readonly List<IKey> myKeysToFilter = new List<IKey>();

    public FilterProxyAction(params IKey[] keysToFilter)
    {
      myKeysToFilter = new List<IKey>(keysToFilter);
    }

    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return EmptyArray<ContextMissmatch>.Instance;
    }

    protected override void Apply(Context ctx, Context result)
    {      
      result.AddAllBut(ctx, myKeysToFilter);
    }
  }
}