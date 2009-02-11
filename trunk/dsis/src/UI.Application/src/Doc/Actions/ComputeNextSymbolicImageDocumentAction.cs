using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Ioc;
using DSIS.Scheme;
using DSIS.Scheme.Actions;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;
using DSIS.Scheme.Impl;
using DSIS.Scheme.Impl.Actions;
using DSIS.UI.Application.Progress;
using DSIS.UI.ComputationDialogs;
using DSIS.UI.UI;

namespace DSIS.UI.Application.Doc.Actions
{
  [DocumentAction(Caption = "Build Next Symbolic Image", Description = "")]
  public class ComputeNextSymbolicImageDocumentAction : IDocumentAction
  {
    [Autowire]
    private IApplicationDocument myDocument { get; set; }

    [Autowire]
    private ISIConstructionWizard myWizard { get; set; }

    [Autowire]
    private IActionExecution myExec { get; set; }

    [Autowire]
    private IDocumentManager DocumentManager { get; set; }

    public bool Compatible
    {
      get { return myDocument.Content.ContainsCellCollection() || myDocument.Content.ContainsGraph(); }
    }

    public void Apply()
    {
      var settings = myWizard.ShowWizard(myDocument.System.Dimension);
      if (settings != null)
        myExec.ExecuteAsync(
          "Next SI",
          pi =>
            {
              var ctx = myDocument.Content;
              for (var set = settings; set != null; set = set.Next(ctx))
              {
                ctx = ((IAction) CreateCompleteAction(ctx, settings)).Apply(ctx);
              }
              DocumentManager.ChangeDocument(ctx);
            }
          );
    }

    private static AgregateAction CreateCompleteAction(IReadOnlyContext ctx, ICellImageBuilderWizardResult settings)
    {
      var ag = new AgregateAction(
        b1 =>
          {
            var bl1 = new ActionBuilder2Adaptor(b1);

            bl1.Start
              .Edge(new BuildSymbolicImageAction2(settings.Subdivision,
                                                  (ICellImageBuilderIntegerCoordinatesSettings) settings.Setting)).With(
              x1 => x1.Edge(bl1.Finish))
              .Edge(new ChainRecurrenctSimbolicImageAction())
              .Edge(bl1.Finish);
          });

      if (!ctx.ContainsCellCollection())
      {
        var ago = ag;
        ag = new AgregateAction(b =>
                                  {
                                    var bl = new ActionBuilder2Adaptor(b);

                                    bl.Start.Edge(new MergeComponetsAction()).Edge(ago).
                                      With(x => x.Back(bl.Start)).Edge(bl.Finish);
                                  });
      }
      return ag;
    }
  }
}