using System.Collections.Generic;
using System.Diagnostics;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme
{
  public interface IAction 
  {
    ICollection<ContextMissmatch> Compatible(Context ctx);
    Context Apply(Context ctx);

    IAction Clone();
  }

  public interface IActionDebug
  {
    StackTrace Creation { get; }
  }
}