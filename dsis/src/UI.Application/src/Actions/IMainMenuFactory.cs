using System.Windows.Forms;

namespace DSIS.UI.Application.Actions
{
  public interface IMainMenuFactory
  {
    ToolStripItem BuildMenu(IActionDescriptor action);
  }
}