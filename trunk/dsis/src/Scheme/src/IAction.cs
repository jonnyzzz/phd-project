using System.Collections.Generic;
using System.Diagnostics;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;

namespace DSIS.Scheme
{
  public interface IAction
  {
    
  }

  public interface ICompositeAction
  {
    
  }

  public interface ISimpleAction : IAction
  {
    ICollection<ContextMissmatch> Compatible(Context ctx);
    Context Apply(Context ctx);
  }  

  public interface IAgregateAction : IAction
  {
    void BuildInto(IActionGraphBuilder builer);
  }

  public interface IActionDebug
  {
    StackTrace Creation { get; }
  }
}