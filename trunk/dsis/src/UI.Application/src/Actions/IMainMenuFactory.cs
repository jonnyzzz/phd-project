using System.Windows.Forms;
using DSIS.Core.Ioc;

namespace DSIS.UI.Application.Actions
{
  [ComponentInterface]
  public interface IMainMenuFactory
  {
    ToolStripItem BuildMenu(IActionDescriptor action);
  }
}