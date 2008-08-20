using DSIS.Scheme.Ctx;
using DSIS.Spring.Attributes;

namespace DSIS.UI.Application.Actions.Impl
{
  [SpringBean]
  public class ExitProgramActionHandler : ActionHandlerBase
  {
    private readonly ApplicationClass myApp;

    public ExitProgramActionHandler(ApplicationClass app)
      : base("File.Exit")
    {
      myApp = app;
    }

    public override bool Do(Context ctx)
    {
      myApp.OnMenuExit();
      return true;
    }
  }
}
