using System.Windows.Forms;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl;
using DSIS.UI.Application.Progress;
using DSIS.UI.ComputationDialogs.Measure;
using DSIS.UI.UI;
using log4net;

namespace DSIS.UI.Application.Doc.Actions
{
  [DocumentAction(Caption = "Compute Invariant measure", Description = "")]
  public class ComputeInvariantMeasureAction : IDocumentAction
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (ComputeInvariantMeasureAction));

    private readonly IApplicationDocument myDocument;
    private readonly IActionExecution myExec;
    private readonly IComputeInvariantMeasureMethodSelector myMethodSelector;

    public ComputeInvariantMeasureAction(IApplicationDocument document, IActionExecution exec,
                                         IComputeInvariantMeasureMethodSelector methodSelector)
    {
      myDocument = document;
      myExec = exec;
      myMethodSelector = methodSelector;
    }

    public bool Compatible
    {
      get
      {
        return myMethodSelector.IsApplicable(myDocument.Content);
      }
    }

    public void Apply()
    {
      var ctx = myDocument.Content;
      if (ctx.ContainsGraphMeasure())
      {
        var result = MessageBox.Show("There is invariant measure computation result. Do you want to re-compute it?",
                                     "DSIS", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        if (result != DialogResult.Yes)
          return;
      }

      var action = myMethodSelector.ShowWizard();

      myExec.ExecuteAsync("Compute Invariant Measure",
                          pi =>
                            {
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