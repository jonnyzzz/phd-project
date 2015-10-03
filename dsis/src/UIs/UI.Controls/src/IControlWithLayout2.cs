using System.Windows.Forms;

namespace DSIS.UI.Controls
{
  public interface IControlWithLayout2
  {
    string Ancor { get; }
    Layout[] Float { get; }
    Control Control { get; }
  }
}