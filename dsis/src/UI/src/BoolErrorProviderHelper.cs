using System.Windows.Forms;

namespace DSIS.UI.UI
{
  public class BoolErrorProviderHelper : ErrorProviderHelper<bool>
  {
    public BoolErrorProviderHelper(Control control) : base(control, true, (x, y) => x & y)
    {
    }
  }
}