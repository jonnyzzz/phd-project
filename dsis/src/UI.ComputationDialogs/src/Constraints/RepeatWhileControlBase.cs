using System;
using System.Windows.Forms;

namespace DSIS.UI.ComputationDialogs.Constraints
{
  public abstract partial class RepeatWhileControlBase : UserControl, ISIComputationConstraintUI
  {
    protected RepeatWhileControlBase(string captionBefore, string captionAfter)
    {
      InitializeComponent();
      myValue.TextChanged += delegate { myEnabled.Checked = true; };

      var sz = myEnabled.Width;
      var sz2 = myLabel.Width;

      myEnabled.Text = captionBefore;

      var dw = myEnabled.Width - sz;
      myValue.Left += dw;
      myLabel.Left += dw;
      myLabel.Text = captionAfter;

      Width += dw + (myLabel.Width - sz2);
    }

    protected void SetEditFieldWidth(int newWidth)
    {
      var sz = newWidth - myValue.Width;
      myLabel.Left += sz;
      myValue.Width += sz;
    }

    public abstract string SortName { get;}

    bool ISIComputationConstraintUI.Enabled
    {
      get { return myEnabled.Checked; }
    }

    public ISIComputationConstraint CreateConstraint() 
    {
      return CreateConstraint(myValue.Value.Value);
    }

    protected abstract ISIComputationConstraint CreateConstraint(long count);

    public Control Control
    {
      get { return this; }
    }

    public event Action<Control, string> Error
    {
      add { myValue.Error += value;}
      remove { myValue.Error -= value;}
    }
  }
}