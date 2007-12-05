using System.Collections.Generic;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Actions
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