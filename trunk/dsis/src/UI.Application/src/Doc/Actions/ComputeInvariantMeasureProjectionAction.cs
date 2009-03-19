using DSIS.Core.Ioc;
using DSIS.Scheme.Impl.Actions.Entropy;
using DSIS.UI.Application.Progress;
using DSIS.UI.UI;

namespace DSIS.UI.Application.Doc.Actions
{
  [DocumentAction(Caption = "Project Invariant measure", Description = "")]
  public class ComputeInvariantMeasureProjectionAction : IDocumentAction
  {
    private readonly ProjectEntopryAction myAction = new ProjectEntopryAction();

    [Autowire]
    private IApplicationDocument Document { get; set; }

    [Autowire]
    private IDocumentManager DocumentManager { get; set; }

    [Autowire]
    private IContextOperationExecution Exec { get; set; }

    public bool Compatible
    {
      get { return myAction.Compatible(Document.Content).Count == 0; }
    }

    public void Apply()
    {
      Exec.ExecuteAsync(
        "Project entropy",
        (hook,pi) =>
          {
            var result = myAction.Apply(Document.Content);
            hook.ChangeDocument(result);
          });
    }
  }
}