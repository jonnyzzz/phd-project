using System;
using System.Globalization;
using System.Windows.Forms;
using DSIS.UI.UI;

namespace DSIS.UI.ComputationDialogs.Constraints
{
  public partial class RepeatCountToolControl : UserControl, IErrorProvider<bool>
  {
    private bool myUpdating;

    public RepeatCountToolControl()
    {
      InitializeComponent();
    }

    public event Action<Control, string> Error;

    public bool ControlEnabled
    {
      get { return myEnabled.Checked; }
    }

    public long? Times { get; private set;}

    public bool HasError { get; private set; }

    private void SetError(string message)
    {
      HasError = message != null;
      if (Error != null)
        Error(myTimes, message);
    }

    bool IErrorProvider<bool>.Validate()
    {
      return !Enabled || !HasError;
    }

    private void myTimes_TextChanged(object sender, EventArgs e)
    {
      myEnabled.Checked = true;
      if (!myUpdating)
      {
        myUpdating = true;
        try
        {
          long v;
          var s = myTimes.Text;
          if ((long.TryParse(s, out v)
               || long.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out v)
               || long.TryParse(s, NumberStyles.Any, CultureInfo.CurrentCulture, out v)
              ) && v > 0)
          {
            SetError(null);

            Times = v;            
          }
          else
          {
            Times = null;
            SetError("Failed to parse positive integer value");
          }
        }
        finally
        {
          myUpdating = false;
        }
      }
    }

    private void myEnabled_CheckedChanged(object sender, EventArgs e)
    {
      myTimes.Enabled = ControlEnabled;
    }
  }
}