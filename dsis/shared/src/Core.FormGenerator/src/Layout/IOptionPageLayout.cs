using System.Collections.Generic;
using System.Windows.Forms;
using EugenePetrenko.Core.FormGenerator.Layout;

namespace EugenePetrenko.Core.FormGenerator.Layout
{
  public interface IOptionPageLayout
  {
    Panel Layout<Q>(IEnumerable<Q> controls)
      where Q : IOptionPageControl;

    void Layout<Q>(ScrollableControl host, IEnumerable<Q> controls)
      where Q : IOptionPageControl;
  }
}