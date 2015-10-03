using DSIS.Scheme.Ctx;
using DSIS.Spring.Attributes;

namespace DSIS.UI.Application.Actions.Impl
{
  [SpringBean, ActionHandler]
  public class DisabledActionHandler : ActionHandlerBase
  {
    public DisabledActionHandler()
      : base("File.Save", "File.Close", "File.Open", "System.Show")
    {
    }

    public override bool Enabled(Context ctx)
    {
      return false;
    }
  }
}