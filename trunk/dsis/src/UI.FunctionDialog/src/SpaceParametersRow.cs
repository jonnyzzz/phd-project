using System;
using System.Windows.Forms;

namespace DSIS.UI.FunctionDialog
{
  public partial class SpaceParametersRow : UserControl
  {
    private SpaceParametersRowModel myModel;


    public SpaceParametersRowModel Model
    {
      get { return myModel; }
      set { myModel = value; Synch();}
    }

    public SpaceParametersRow(SpaceParametersRowModel model)
    {
      InitializeComponent();
      Model = model;
    }

    private void Synch()
    {
      myLeft.Text = ToString(myModel.Left);
      myRight.Text = ToString(myModel.Right);
      myGrid.Text = ToString(myModel.Grid);
    }

    private static string ToString(double d)
    {
      return d.ToString();
    }
    
    private static string ToString(long d)
    {
      return d.ToString();
    }

    private static bool Parse(string text, out double d, out string error)
    {
      if (!double.TryParse(text, out d))
      {
        error = "Failed to parse double value";
        return false;
      }
      else
      {
        error = string.Empty;
        return true;
      }
    }
    
    private static bool Parse(string text, out long d, out string error)
    {
      if (!long.TryParse(text, out d))
      {
        error = "Failed to parse integer value";
        return false;
      }
      else
      {
        error = string.Empty;
        return true;
      }
    }

    private delegate void SetValue<T>(T d);
    private delegate bool ParseValue<T>(string text, out T d, out string error);
    private void TrySetValue<T>(TextBox box, SetValue<T> set, ParseValue<T> parse)
    {
      T v;
      string error;
      if (!(parse(box.Text, out v, out error)))
      {
        myErrorProvider.SetError(box, error);
      }
      else
      {
        myErrorProvider.SetError(box, null);
        set(v);
      }
    }

    private void myLeft_TextChanged(object sender, EventArgs e)
    {
      TrySetValue(myLeft, delegate(double x) { myModel.Left = x; }, Parse);      
    }

    private void myRight_TextChanged(object sender, EventArgs e)
    {
      TrySetValue(myRight, delegate(double x) { myModel.Right = x; }, Parse);      
    }

    private void myGrid_TextChanged(object sender, EventArgs e)
    {
      TrySetValue(myGrid, delegate(long x) { myModel.Grid = x; }, Parse);
    }
  }
}
