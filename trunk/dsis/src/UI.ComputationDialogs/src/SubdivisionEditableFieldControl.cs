using System;
using System.Globalization;
using System.Windows.Forms;

namespace DSIS.UI.ComputationDialogs
{
  public class SubdivisionEditableFieldControl : SubdivisionFieldControl
  {
    private long? mySubdivisionValue;
    private long myActualValue;
    private bool myUpdating;

    public event Action<Control, string> Error;
    public event EventHandler<EventArgs> Changed;

    public bool HasError { get; private set; }

    public long? SubdivisionValue
    {
      get { return mySubdivisionValue; }
      set { mySubdivisionValue = value; UpdateFields(); }
    }
    
    public SubdivisionEditableFieldControl(string axis, long actualValue, long def) : base(axis)
    {
      HasError = false;
      myActualValue = actualValue;
      mySubdivisionValue = def;

      UpdateFields();

      mySubdivisionText.TextChanged += mySubdivision_TextChanged;
    }

    public long ActualValue
    {
      set
      {
        myActualValue = value;
        UpdateFields();
      }
    }

    private void UpdateFields()
    {
      if (!myUpdating)
      {
        myUpdating = true;
        try
        {
          myActualValueText.Text = ToString(myActualValue);
          if (mySubdivisionValue != null)
          {
            mySubdivisionText.Text = ToString(mySubdivisionValue.Value);
            myEstimateText.Text = ToString(myActualValue*mySubdivisionValue.Value);
          } else
          {
            mySubdivisionText.Text = "???";
            myEstimateText.Text = "???";
          }
        } finally
        {
          myUpdating = false;
        }
      }
    }

    private static string ToString(long v)
    {
      return v.ToString("N0");
    }

    private void SetError(string message)
    {
      HasError = message != null;
      if (Error != null)
        Error(mySubdivisionText, message);
    }

    private void mySubdivision_TextChanged(object sender, EventArgs e)
    {
      if (!myUpdating)
      {
        myUpdating = true;
        try
        {
          long v;
          var s = mySubdivisionText.Text;
          if ((long.TryParse(s, out v)
               || long.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out v)
               || long.TryParse(s, NumberStyles.Any, CultureInfo.CurrentCulture, out v)
              ) && v > 0)
          {
            SetError(null);

            mySubdivisionValue = v;
            UpdateFields();
          }
          else
          {
            mySubdivisionValue = null;
            SetError("Failed to parse positive integer value");
          }

          if (Changed != null)
            Changed(this, EventArgs.Empty);
        } finally
        {
          myUpdating = false;
        }
      }
    } 
  }
}