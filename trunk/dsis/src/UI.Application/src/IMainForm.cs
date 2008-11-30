using System.Windows.Forms;
using DSIS.Core.Ioc;
using DSIS.UI.UI;

namespace DSIS.UI.Application
{
  [ComponentInterface]
  public interface IMainForm
  {
    Form GetForm();
    void SetContent(IControlWithTitle control);
  }
}