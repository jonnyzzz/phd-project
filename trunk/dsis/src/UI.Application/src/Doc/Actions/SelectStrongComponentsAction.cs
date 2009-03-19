using DSIS.Core.Ioc;
using DSIS.Graph;
using DSIS.Scheme.Impl;
using DSIS.UI.Application.Progress;
using DSIS.UI.ComputationDialogs.Components;
using DSIS.UI.UI;
using DSIS.UI.Wizard;

namespace DSIS.UI.Application.Doc.Actions
{
  [DocumentAction(Caption = "Select Symbolic Image components", Description = "")]
  public class SelectStrongComponentsAction : IDocumentAction
  {
    [Autowire]
    private IApplicationDocument Document { get; set; }

    [Autowire]
    private IComponentsSelectorWizardPackFactory Wizard { get; set; }

    [Autowire]
    private IWizardFormPresenter Presenter { get; set; }

    [Autowire]
    private IDocumentManager DocumentManager { get; set; }

    [Autowire]
    private IGraphStrongComponentSubsetFactory Factory { get; set; }

    [Autowire]
    private IContextOperationExecution Exec { get; set; }

    public bool Compatible
    {
      get
      {
        var context = Document.Content;
        return context.ContainsKey(Keys.GraphComponents) && Keys.GraphComponents.Get(context).ComponentCount > 1;
      }
    }

    public void Apply()
    {
      var context = Document.Content;
      var components = context.Get(Keys.GraphComponents);

      var result = Presenter.ShowWizardOrNull(Wizard.CreateWizard(components));
      if (result == null)
        return;

      Exec.ExecuteAsync("Select component action",
                        (hook, pi) =>
                          {
                            components = Factory.SubComponents(components, result);

                            context.ReplaceTypedGraphComponents(components);

                            hook.ChangeDocument(context);
                          });
    }
  }
}