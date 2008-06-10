using DSIS.Scheme.Ctx;
using DSIS.Spring.Attributes;
using DSIS.Spring.Service;
using DSIS.UI.FunctionDialog;
using DSIS.UI.UI;
using DSIS.UI.Wizard;

namespace DSIS.UI.Application.Actions.Impl
{
  [SpringBean]
  public class CreateNewSystemActionHandler : ActionHandlerBase
  {
    private readonly IApplicationClass myApp;
    private readonly IServiceProvider myProvider;

    public CreateNewSystemActionHandler(IApplicationClass app, IServiceProvider provider) : base("File.Create")
    {
      myApp = app;
      myProvider = provider;
    }

    public override bool Do(Context ctx)
    {
      myApp.ShowDialog(form => new WizardForm(new SystemFunctionSelectionWizard(myProvider))
                                 {
                                   Parent = form
                                 }.ShowDialog(form));

      return true;
    }
  }
}