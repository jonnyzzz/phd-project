using System.Windows.Forms;

namespace DSIS.UI.Application.Actions
{
  public interface IMainMenuFactory
  {
    ToolStripMenuItem BuildMenu(ActionDescriptor action);
  }
}