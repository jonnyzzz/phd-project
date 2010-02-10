using System.Windows.Forms;
using DSIS.Scheme.Ctx;
using DSIS.Spring.Service;
using DSIS.UI.FunctionDialog;
using DSIS.UI.UI;
using DSIS.UI.Wizard;

namespace DSIS.UI.Application.Actions.Impl
{
  [ActionHandler]
  public class CreateNewSystemActionHandler : ActionHandlerBase
  {
    private readonly IApplicationClass myApp;
    private readonly IServiceProvider myProvider;
    private readonly IApplicationDocumentFactory myFactory;

    public CreateNewSystemActionHandler(IApplicationClass app, IServiceProvider provider, IApplicationDocumentFactory factory) : base("File.Create", "System.Create")
    {
      myApp = app;
      myFactory = factory;
      myProvider = provider;
    }

    public override bool Do(Context ctx)
    {
      var model = new SystemFunctionSelectionWizard(myProvider);
      var wizardForm = new WizardForm(model);
      DialogResult result = myApp.ShowDialog(form => wizardForm.ShowDialog(form));

      if (result == DialogResult.OK)
      {
        myApp.Document = myFactory.CreateNewDocument(model.Title, model.CreateInfo(), model.CreateSpace());
      }

      return true;
    }
  }
}