using System.Windows.Forms;

namespace DSIS.UI.Controls
{
  public interface IControlWithLayout
  {
    Layout Float { get; }
    string Ancor { get; }

    Control Control { get;}
  }
}