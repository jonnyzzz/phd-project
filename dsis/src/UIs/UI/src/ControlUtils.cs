using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DSIS.Utils;

namespace DSIS.UI.UI
{
  public static class ControlUtils
  {
    public static IEnumerable<Control> ControlsEnumerable(this Control control)
    {
      return control.Controls.Cast<Control>();
    }

    public static IDisposable UpdateCookie(this Control control)
    {
      control.SuspendLayout();
      return new DisposableWrapper(control.ResumeLayout);
    }
  }
}