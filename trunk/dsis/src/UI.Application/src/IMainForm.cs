using System;
using System.Windows.Forms;
using DSIS.Core.Ioc;
using DSIS.UI.UI;

namespace DSIS.UI.Application
{
  [ComponentInterface]
  public interface IMainForm
  {
    event EventHandler BeforeFormCreated;
    event EventHandler AfterFormCreated;

    Form GetForm();
    void SetContent(IControlWithTitle control);
  }
}