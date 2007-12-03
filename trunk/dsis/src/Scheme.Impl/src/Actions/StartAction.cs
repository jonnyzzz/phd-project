using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl
{
  public class StartAction : IAction
  {
    public ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return new ContextMissmatch[] {};
    }

    public Context Apply(Context ctx)
    {
      return new Context();
    }
  }
}