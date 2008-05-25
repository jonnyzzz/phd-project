using DSIS.Scheme.Ctx;
using DSIS.Spring.Attributes;
using DSIS.UI.FunctionDialog;
using DSIS.UI.Wizard;

namespace DSIS.UI.Application.Actions.Impl
{
  [SpringBean]
  public class CreateNewSystemActionHandler : ActionHandlerBase
  {
    private readonly ApplicationClass myApp;

    public CreateNewSystemActionHandler(ApplicationClass app) : base("File.Create")
    {
      myApp = app;
    }

    public override bool Do(Context ctx)
    {
      myApp.ShowDialog(form => new WizardForm(new SystemFunctionSelectionWizard()).ShowDialog());

      return true;
    }
  }
}