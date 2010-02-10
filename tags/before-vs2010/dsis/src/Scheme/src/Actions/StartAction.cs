using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Actions
{
  public class StartAction : DebugableAction, IAction
  {
    public ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return EmptyArray<ContextMissmatch>.Instance;
    }

    public Context Apply(Context ctx)
    {
      return new Context();
    }

    public IAction Clone()
    {
      throw new System.NotImplementedException();
    }
  }
}