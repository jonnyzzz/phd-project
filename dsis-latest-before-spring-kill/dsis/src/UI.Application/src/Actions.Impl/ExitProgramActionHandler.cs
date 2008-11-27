using DSIS.Scheme.Ctx;
using DSIS.Spring.Attributes;
using DSIS.Spring.Service;
using DSIS.UI.UI;

namespace DSIS.UI.Application.Actions.Impl
{
  [SpringBean, ActionHandler]
  public class ExitProgramActionHandler : ActionHandlerBase
  {
    private readonly IServiceProvider myApp;
    
    public ExitProgramActionHandler(IServiceProvider app)
      : base("File.Exit")
    {
      myApp = app;
    }

    public override bool Do(Context ctx)
    {
      myApp.GetService<IApplicationClass>().OnMenuExit();
      return true;
    }
  }
}
