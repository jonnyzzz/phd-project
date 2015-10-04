using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DSIS.Utils;

namespace EugenePetrenko.Core.FormGenerator
{
  public static class ControlUtils
  {
    public static IEnumerable<Control> ControlsEnumerable(this Control control)
    {
      foreach (var con in control.Controls)
      {
        yield return (Control) con;
      }
    }

    public static IDisposable UpdateCookie(this Control control)
    {
      control.SuspendLayout();
      return new DisposableWrapper(() => control.ResumeLayout());
    }
  }
}