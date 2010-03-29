using DSIS.Core.Ioc;
using DSIS.Scheme.Impl;
using DSIS.Scheme.Impl.Actions.Line;
using DSIS.UI.Application.Progress;
using DSIS.UI.UI;
using DSIS.UI.Wizard;
using DSIS.Utils;
using log4net;

namespace DSIS.UI.Application.Doc.Actions.Segments
{
  [DocumentAction(Caption = "Iterate Segment")]
  public class IterateLineAction : IDocumentAction
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (IterateLineAction));

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
      get { return myDocument.Content.ContainsKey(Keys.LineKey); }
    }

    public void Apply()
    {
      var pack = myFactory.Instanciate<WizardPack<IterateLineOptions>>();
      var result = myPresenter.ShowWizardOrNull(pack);
      if (result == null)
        return;

      myExec.ExecuteAsync(
        "Iterate segment",
        (op, pi) =>
          {
            var ctx = myDocument.Content;
            var act = new LineAction();            
            pi.Maximum = result.Steps;
            for(int i = 0; i < result.Steps; i++)
            {
              var r = act.Apply(ctx);
              ctx = op.UpdateContext(ctx, r);
              pi.Tick(1);
              GCHelper.Collect();
            }
            op.ChangeDocument(ctx);
          });
    }
  }
}