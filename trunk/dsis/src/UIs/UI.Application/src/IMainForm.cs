using System;
using System.Windows.Forms;
using DSIS.UI.UI;

namespace DSIS.UI.Application
{
  public interface IMainForm
  {
    event EventHandler BeforeFormCreated;
    event EventHandler AfterFormCreated;

    Form GetForm();
    void SetContent(IControlWithTitle control);

    void AddStatusBarControl(ToolStripItem control);
  }
}