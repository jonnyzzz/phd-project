using System;
using System.Drawing;
using System.Windows.Forms;
using DSIS.UI.UI;
using log4net;
using DSIS.Utils;

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
      int height = 0;
      int row = 0;
      foreach (var action in myActionManager.GetActions().Sort((x,y)=>x.Caption.CompareTo(y.Caption)))
      {
        Button btn = CreateButton(action);
        height += btn.Height;
        panel.Controls.Add(btn, 0, row++);
      }
      panel.Size = new Size(100, height + 5);
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
                    Dock = DockStyle.Top
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