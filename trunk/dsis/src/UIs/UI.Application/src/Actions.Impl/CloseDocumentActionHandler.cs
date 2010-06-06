using DSIS.Scheme.Ctx;
using DSIS.UI.UI;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.UI.Application.Actions.Impl
{
  [ActionHandler]
  public class CloseDocumentActionHandler : ActionHandlerBase
  {
    [Autowire]
    private IApplicationClass App { get; set; }

    public CloseDocumentActionHandler()
      : base("File.Close")
    {
    }

    public override bool Enabled(Context ctx)
    {
      return App.Document != null;
    }

    public override bool Do(Context ctx)
    {
      App.Document = null;
      return true;
    }
  }
}