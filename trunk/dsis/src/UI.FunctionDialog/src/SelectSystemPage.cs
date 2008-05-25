using System.Windows.Forms;
using DSIS.UI.UI;

namespace DSIS.UI.FunctionDialog
{
  public enum SystemSpaceSelection
  {
    USER,
    PREDEFINED,
    
    UNKNOWN
  }

  public partial class SelectSystemPage : UserControl, IErrorProvider<bool>
  {
    public SelectSystemPage()
    {
      InitializeComponent();
    }

    bool IErrorProvider<bool>.Validate()
    {
      return Value != SystemSpaceSelection.UNKNOWN;
    }

    public SystemSpaceSelection Value
    {
      get
      {
        if (myRadioDefineSystem.Checked)
          return SystemSpaceSelection.USER;

        if (myRadioPredefined.Checked)
          return SystemSpaceSelection.PREDEFINED;

        return SystemSpaceSelection.UNKNOWN;
      }
    }
  }
}