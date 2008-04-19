using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Actions
{
  public class StartAction : DebugableAction, ISimpleAction
  {
    public ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return EmptyArray<ContextMissmatch>.Instance;
    }

    public Context Apply(Context ctx)
    {
      return new Context();
    }
  }
}