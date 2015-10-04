using System;
using System.Drawing;
using System.Windows.Forms;

namespace EugenePetrenko.Core.FormGenerator.Layout.Impl
{
  public static class ControlSizeCalculator
  {
    public static Func<Size, Size, Size> ComputeSize(Layout expectedLayout)
    {
      switch (expectedLayout)
      {
        case Layout.BOTTON:
        case Layout.TOP:
          return (a, b) => new Size(
                             Math.Max(a.Width, b.Width),
                             a.Height + b.Height
                             );
        case Layout.LEFT:
        case Layout.RIGHT:
          return (a, b) => new Size(
                             a.Width + b.Width,
                             Math.Max(a.Height, b.Height)
                             );
        default:
          return (a, b) => { throw new ArgumentException("layout " + expectedLayout + " not supported"); };
      }
    }

    public static Func<Size, Size, Size> ComputeSize(DockStyle expectedLayout)
    {
      switch (expectedLayout)
      {
        case DockStyle.Bottom:
        case DockStyle.Top:
          return (a, b) => new Size(
                             Math.Max(a.Width, b.Width),
                             a.Height + b.Height
                             );
        case DockStyle.Left:
        case DockStyle.Right:
          return (a, b) => new Size(
                             a.Width + b.Width,
                             Math.Max(a.Height, b.Height)
                             );
        default:
          return (a, b) => { throw new ArgumentException("layout " + expectedLayout + " not supported"); };
      }
    }
  }
}