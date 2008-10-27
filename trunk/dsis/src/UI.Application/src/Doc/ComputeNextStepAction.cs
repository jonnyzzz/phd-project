using System.Drawing;
using System.Windows.Forms;
using DSIS.CellImageBuilder.BoxMethod;
using DSIS.Scheme;
using DSIS.Scheme.Actions;
using DSIS.Scheme.Exec;
using DSIS.Scheme.Impl.Actions;
using DSIS.UI.Application.Progress;
using DSIS.UI.Controls;
using DSIS.UI.UI;
using DSIS.Utils;
using DSIS.Scheme.Impl;

namespace DSIS.UI.Application.Doc
{
  [DocumentComponent]
  public class ComputeNextStepAction : UserControl, IDocumentControl
  {
    public ComputeNextStepAction(IApplicationDocument doc, IActionExecution exec)
    {
      var ag = new AgregateAction(
        b =>
          {
            var bl = new ActionBuilder2Adaptor(b);

            bl.Start
              .Edge(new BuildSymbolicImageAction2(2L.Fill(doc.System.Dimension), BoxMethodSettings.Default)).With(x=>x.Edge(bl.Finish))
              .Edge(new ChainRecurrenctSimbolicImageAction())
              .Edge(bl.Finish);
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

      var bt = new Button{Text = "Build with BoxMethod"};
      bt.Click += delegate { exec.ExecuteAsync("Next SI", pi=>BuildNext(doc, ag)); };
      bt.Enabled = ag.Compatible(doc.Content).Empty();

      Controls.Add(bt);
      Size = new Size(100, 32);
      BackColor = Color.Brown;
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