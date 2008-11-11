using System;
using System.Windows.Forms;
using log4net;

namespace DSIS.UI.Application.Doc.Actions
{
  [DocumentComponent]
  public class DocumentActionPresentation : IDocumentActionPresentation
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (DocumentActionPresentation));

    private readonly IDocumentActionManager myActionManager;

    public DocumentActionPresentation(IDocumentActionManager actionManager)
    {
      myActionManager = actionManager;
    }

    public Control CreateDocumentActionsControl()
    {
      var panel = new TableLayoutPanel {ColumnCount = 1};

      int row = 0;
      foreach (var action in myActionManager.GetActions())
      {
        Button btn = CreateButton(action);
        panel.Controls.Add(btn, 0, row++);
      }
      return panel;
    }

    private static Button CreateButton(IDocumentActionEx action)
    {
      var btn = new Button
                  {
                    Text = action.Caption + "\u2026",
                    Enabled = action.Compatible,
                    AutoSize = true,
                    AutoEllipsis = true,
                  };
      btn.Click += delegate
                     {
                       try
                       {
                         if (action.Compatible)
                         {
                           action.Apply();
                         }
                       } catch(Exception e)
                       {
                         LOG.ErrorFormat("Failed to complete action {0}. ", action.Caption);
                         LOG.Error(e);
                       }
                     };
      return btn;
    }
  }
}