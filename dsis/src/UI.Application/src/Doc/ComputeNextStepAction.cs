using System.Drawing;
using System.Windows.Forms;
using DSIS.CellImageBuilder.BoxMethod;
using DSIS.CellImageBuilder.Shared;
using DSIS.Scheme;
using DSIS.Scheme.Actions;
using DSIS.Scheme.Exec;
using DSIS.Scheme.Impl.Actions;
using DSIS.UI.Application.Progress;
using DSIS.UI.ComputationDialogs;
using DSIS.UI.Controls;
using DSIS.UI.UI;
using DSIS.Utils;
using DSIS.Scheme.Impl;

namespace DSIS.UI.Application.Doc
{
//  [DocumentComponent]
  public class ComputeNextStepAction : UserControl, IDocumentControl
  {
    public ComputeNextStepAction(IApplicationDocument doc, IActionExecution exec, ISIConstructionWizard w)
    {
      AgregateAction ag = CreateCompleteAction(doc, BoxMethodSettings.Default);

      var bt = new Button{Text = "Build with BoxMethod"};
      bt.Click += delegate { exec.ExecuteAsync("Next SI", pi=>BuildNext(doc, ag)); };
      bt.Enabled = ag.Compatible(doc.Content).Empty();
      Controls.Add(bt);


      var bt2 = new Button {Text = "Wizard", Left = bt.Left + bt.Width + 5};
      bt2.Click += delegate
                     {
                       var settings = w.ShowWizard();
                       if (settings != null)
                        exec.ExecuteAsync(
                          "Next SI", 
                          pi=>BuildNext(doc, CreateCompleteAction(doc, (ICellImageBuilderIntegerCoordinatesSettings) settings))
                          );
                     };
      Controls.Add(bt2);
      
      Size = new Size(100, 32);
      BackColor = Color.Brown;
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

    private static void BuildNext(IApplicationDocument doc, IAction action)
    {
      var ctx = action.Apply(doc.Content);
      doc.ChangeDocument(ctx);
    }

    public string Ancor
    {
      get { return "ZZZ"; }
    }

    public Layout[] Float
    {
      get { return new[] {DSIS.UI.Controls.Layout.LEFT, DSIS.UI.Controls.Layout.TOP,}; }
    }

    public Control Control
    {
      get { return this; }
    }
  }
}