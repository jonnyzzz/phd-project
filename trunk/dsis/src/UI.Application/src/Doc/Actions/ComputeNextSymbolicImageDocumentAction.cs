using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Ioc;
using DSIS.Scheme;
using DSIS.Scheme.Actions;
using DSIS.Scheme.Exec;
using DSIS.Scheme.Impl;
using DSIS.Scheme.Impl.Actions;
using DSIS.UI.Application.Progress;
using DSIS.UI.ComputationDialogs;
using DSIS.UI.UI;
using DSIS.Utils;

namespace DSIS.UI.Application.Doc.Actions
{
  [DocumentAction(Caption = "Build Next Symbolic Image", Description = "")]
  public class ComputeNextSymbolicImageDocumentAction : IDocumentAction
  {
    [Autowire]
    private IApplicationDocument myDocument{ get; set;}
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
      var settings = myWizard.ShowWizard();
      if (settings != null)
        myExec.ExecuteAsync(
          "Next SI",
          pi => BuildNext(
            myDocument, 
            CreateCompleteAction(myDocument, 
            (ICellImageBuilderIntegerCoordinatesSettings)settings))
          );
    }

    private static AgregateAction CreateCompleteAction(IApplicationDocument doc, ICellImageBuilderIntegerCoordinatesSettings settings)
    {
      var ag = new AgregateAction(
        b1 =>
          {
            var bl1 = new ActionBuilder2Adaptor(b1);

            bl1.Start
              .Edge(new BuildSymbolicImageAction2(2L.Fill(doc.System.Dimension), settings)).With(x1=>x1.Edge(bl1.Finish))
              .Edge(new ChainRecurrenctSimbolicImageAction())
              .Edge(bl1.Finish);
          });

      if (!doc.Content.ContainsCellCollection())
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

    private void BuildNext(IApplicationDocument doc, IAction action)
    {
      var ctx = action.Apply(doc.Content);
      DocumentManager.ChangeDocument(ctx);
    }
  }
}