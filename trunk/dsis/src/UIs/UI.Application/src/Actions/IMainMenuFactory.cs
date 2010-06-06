using System;
using System.Windows.Forms;
using DSIS.Scheme.Ctx;

namespace DSIS.UI.Application.Actions
{
  public interface IMainMenuFactory
  {
    IMenuItem<ToolStripItem> BuildMenu(IActionDescriptor action, Func<Context> context);

    void SetMenu(IActionDescriptor descr, MenuStrip strip, Func<Context> ctx);
  }
}