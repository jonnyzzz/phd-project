using DSIS.Spring.Attributes;
using DSIS.Spring.Util;

namespace DSIS.UI.Application.Actions
{
  [SpringBean]
  public class ActionHandlerBeanProcessor
  {
    public ActionHandlerBeanProcessor(IBeanManager proc, ActionPresentationManager man)
    {
      proc.RegisterBeanProcessor<IActionHandler>(x => man.RegisterHandler(x));
    }
  }
}