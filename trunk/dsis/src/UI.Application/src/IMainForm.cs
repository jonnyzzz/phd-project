using System.Windows.Forms;
using DSIS.Core.Ioc;

namespace DSIS.UI.Application
{
  [ComponentInterface]
  public interface IMainForm
  {
    Form GetFrom();
    void SetContent(IControlWithTitle control);
  }
}