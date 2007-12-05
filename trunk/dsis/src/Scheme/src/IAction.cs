using System.Collections.Generic;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme
{
  public interface IAction
  {
    ICollection<ContextMissmatch> Compatible(Context ctx);
    Context Apply(Context ctx);
  }
}