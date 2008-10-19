using System.Windows.Forms;

namespace DSIS.UI.Application
{
  public interface IControlWithTitle
  {
    Control Control { get; }
    string Title { get; }
  }
}