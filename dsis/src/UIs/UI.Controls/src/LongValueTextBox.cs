using System;
using System.Globalization;
using System.Windows.Forms;
using DSIS.UI.UI;

namespace DSIS.UI.Controls
{
  public class LongValueTextBox : TextBox, IErrorProvider<bool>
  {
    public event Action<Control, string> Error;
    private bool myUpdating;

    public bool Validate()
    {
      return !HasError;
    }

    public bool HasError { get; private set; }

    private void SetError(string message)
    {
      HasError = message != null;
      if (Error != null)
        Error(this, message);
    }

    public long? Value { get; private set; }

    protected override void OnTextChanged(EventArgs e)
    {
      base.OnTextChanged(e);
    
      if (!myUpdating)
      {
        myUpdating = true;
        try
        {
          long v;
          var s = Text;
          if ((long.TryParse(s, out v)
               || long.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out v)
               || long.TryParse(s, NumberStyles.Any, CultureInfo.CurrentCulture, out v)
              ) && v > 0)
          {
            SetError(null);

            Value = v;
          }
          else
          {
            Value = null;
            SetError("Failed to parse positive integer value");
          }
        }
        finally
        {
          myUpdating = false;
        }
      }
    }
  }
}