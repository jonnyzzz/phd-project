using System.Collections.Generic;
using System.Windows.Forms;

namespace DSIS.UI.Wizard.FormsGenerator
{
  public interface IOptionPageLayout
  {
    Panel Layout<Q>(IEnumerable<Q> controls)
      where Q : IOptionPageControl;

    void Layout<Q>(ScrollableControl host, IEnumerable<Q> controls)
      where Q : IOptionPageControl;
  }
}