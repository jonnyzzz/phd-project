using System.Windows.Forms;
using DSIS.UI.Controls;
using DSIS.UI.UI;

namespace DSIS.UI.Application.Doc.Actions
{
  [DocumentComponent]
  public class ActionsContainer : IDocumentControl
  {
    private readonly Control myControl;
    public ActionsContainer(IDocumentActionPresentation presentation)
    {
      myControl = presentation.CreateDocumentActionsControl();
    }

    public string Ancor
    {
      get { return "ZZZ"; }
    }

    public Layout[] Float
    {
      get { return new[] { Layout.LEFT, Layout.TOP, }; }
    }

    public Control Control
    {
      get { return myControl; }
    }
  }
}