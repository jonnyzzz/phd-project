using DSIS.Scheme.Ctx;
using DSIS.UI.Application.Progress;
using DSIS.UI.ComputationDialogs.Measure;
using DSIS.UI.UI;
using log4net;
using DSIS.Scheme.Impl;

namespace DSIS.UI.Application.Doc.Actions
{
  [DocumentAction(Caption = "Compute Invariant measure", Description = "")]
  public class ComputeInvariantMeasureAction : IDocumentAction
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (ComputeInvariantMeasureAction));

    private readonly IApplicationDocument myDocument;
    private readonly IActionExecution myExec;
    private readonly IComputeInvariantMeasureMethodSelector myMethodSelector;

    public ComputeInvariantMeasureAction(IApplicationDocument document, IActionExecution exec, IComputeInvariantMeasureMethodSelector methodSelector)
    {
      myDocument = document;
      myExec = exec;
      myMethodSelector = methodSelector;
    }

    public bool Compatible
    {
      get
      {
        var ctx = myDocument.Content;

        if (ctx.ContainsGraphMeasure())
          return false;
        
        return myMethodSelector.IsApplicable(ctx);
      }
    }

    public void Apply()
    {
      var action = myMethodSelector.ShowWizard();

      myExec.ExecuteAsync("Compute Invariant Measure",
        pi =>
          {
            var ctx = myDocument.Content;
            var apply = action.Apply(ctx);
            LOG.Info(apply);
            var c = new Context();
            c.AddAll(apply);
            c.AddAll(ctx);
            myDocument.ChangeDocument(c);
          });
    }
  }
}