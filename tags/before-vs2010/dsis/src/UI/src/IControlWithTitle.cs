using System.Windows.Forms;

namespace DSIS.UI.UI
{
  public interface IControlWithTitle
  {
    Control Control { get; }
    string Title { get; }
  }
}