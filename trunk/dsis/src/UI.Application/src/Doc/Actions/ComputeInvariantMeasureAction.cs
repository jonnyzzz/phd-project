using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Entropy;
using DSIS.UI.Application.Progress;
using DSIS.UI.UI;
using log4net;
using DSIS.Scheme.Impl;

namespace DSIS.UI.Application.Doc.Actions
{
  [DocumentAction(Caption = "Compute Invariant measure", Description = "")]
  public class ComputeInvariantMeasureAction : IDocumentAction
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (ComputeInvariantMeasureAction));

    private readonly JVRMeasureAction myJVR;
    private readonly IApplicationDocument myDocument;
    private readonly IActionExecution myExec;

    public ComputeInvariantMeasureAction(IApplicationDocument document, IActionExecution exec)
    {
      myJVR = new JVRMeasureAction(new JVRMeasureOptions());
      myDocument = document;
      myExec = exec;
    }

    public bool Compatible
    {
      get
      {
        var ctx = myDocument.Content;

        if (ctx.ContainsGraphMeasure())
          return false;

        var r = myJVR.Compatible(ctx);
        return r.Count == 0;
      }
    }

    public void Apply()
    { 
      myExec.ExecuteAsync("Compute Invariant Measure",
        pi =>
          {
            var ctx = myDocument.Content;
            var apply = myJVR.Apply(ctx);
            LOG.Info(apply);
            var c = new Context();
            c.AddAll(apply);
            c.AddAll(ctx);
            myDocument.ChangeDocument(c);
          });
    }
  }
}