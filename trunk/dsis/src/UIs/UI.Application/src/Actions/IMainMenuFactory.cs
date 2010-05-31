using System;
using System.Windows.Forms;
using DSIS.Core.Ioc;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.UI.Application.Actions
{
  [ComponentInterface]
  public interface IMainMenuFactory
  {
    IMenuItem<ToolStripItem> BuildMenu(IActionDescriptor action, Func<Context> context);

    void SetMenu(IActionDescriptor descr, MenuStrip strip, Func<Context> ctx);
  }
}