using DSIS.Scheme.Ctx;

namespace DSIS.UI.Application.Actions.Impl
{
  [ActionHandler]
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