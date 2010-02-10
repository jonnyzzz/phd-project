using DSIS.Core.Ioc;
using DSIS.Scheme.Impl;
using DSIS.Scheme.Impl.Actions.Line;
using DSIS.UI.Application.Progress;
using DSIS.UI.UI;
using DSIS.UI.Wizard;

namespace DSIS.UI.Application.Doc.Actions.Segments
{
  [DocumentAction(Caption = "Create Segment")]
  public class CreateLineAction : IDocumentAction
  {
    [Autowire]
    private IApplicationDocument myDocument { get; set; }

    [Autowire]
    private ITypeInstantiator myFactory { get; set; }

    [Autowire]
    private IWizardFormPresenter myPresenter { get; set; }

    [Autowire]
    private IContextOperationExecution myExec { get; set; }

    public bool Compatible
    {
      get { return !myDocument.Content.ContainsKey(Keys.LineKey); }
    }

    public void Apply()
    {
      myExec.ExecuteAsync("Create Line", (op, pi) =>
                                           {
                                             var space = myDocument.Space;
                                             var action = new LineInitialAction(1e-3, space.AreaLeftPoint, space.AreaRightPoint);

                                             op.ChangeDocument(action.Apply(myDocument.Content));
                                           });
    }
  }
}