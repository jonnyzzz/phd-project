using System;
using System.Linq;
using System.Windows.Forms;
using DSIS.Core.Ioc;
using DSIS.UI.Controls;
using DSIS.UI.UI;
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

    [Autowire]
    private IDockLayout DockLayout { get; set; }

    public Control CreateDocumentActionsControl()
    {
      var actions = from a in myActionManager.GetActions() orderby a.Caption select CreateButton(a);
      return DockLayout.Layout(DockStyle.Top, actions);
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