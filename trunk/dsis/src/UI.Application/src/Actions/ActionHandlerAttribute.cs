using DSIS.Core.Ioc;

namespace DSIS.UI.Application.Actions
{
  public class ActionHandlerAttribute : ComponentImplemetationAttributeBase
  {
    public ActionHandlerAttribute()
    {
      Startable = true;
    }
  }
}