using System.Windows.Forms;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl;
using DSIS.UI.Application.Progress;
using DSIS.UI.ComputationDialogs.Measure;
using DSIS.UI.UI;
using EugenePetrenko.Shared.Core.Ioc.Api;
using log4net;

namespace DSIS.UI.Application.Doc.Actions
{
  [DocumentAction(Caption = "Compute &Invariant measure", Description = "")]
  public class ComputeInvariantMeasureAction : IDocumentAction
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (ComputeInvariantMeasureAction));

    [Autowire]
    private IApplicationDocument Document { get; set; }

    [Autowire]
    private IContextOperationExecution Exec { get; set; }

    [Autowire]
    private IComputeInvariantMeasureMethodSelector MethodSelector { get; set; }

    [Autowire]
    private IDocumentManager DocumentManager { get; set; }

    public bool Compatible
    {
      get
      {
        return MethodSelector.IsApplicable(Document.Content);
      }
    }

    public void Apply()
    {
      var ctx = Document.Content;
      if (ctx.ContainsGraphMeasure())
      {
        var result = MessageBox.Show("There is invariant measure computation result. Do you want to re-compute it?",
                                     "DSIS", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        if (result != DialogResult.Yes)
          return;
      }

      var action = MethodSelector.ShowWizard();

      Exec.ExecuteAsync("Compute Invariant Measure",
                          (hook, pi) =>
                            {
                                var apply = action.Apply(ctx);
                                LOG.Info(apply);
                                var c = new Context();
                                c.AddAll(apply);
                                c.AddAllNew(ctx);
                                hook.ChangeDocument(c);
                            });
    }
  }
}