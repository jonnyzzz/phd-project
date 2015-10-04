using System;
using System.Drawing;
using System.Windows.Forms;
using EugenePetrenko.Core.FormGenerator.Layout;

namespace EugenePetrenko.Core.FormGenerator.Dialog
{
  public partial class DialogForm : Form
  {
    private readonly IDialogModel myModel;

    public DialogForm()
    {
      InitializeComponent();
    }

    public DialogForm(IDialogModel model, IScrollableLayout scroll) : this()
    {
      myModel = model;
      myContent.MinimumSize = new Size(0,0);
      Width = 400;

      using(this.UpdateCookie())
      {
        var control = scroll.MakeScrollableOnY(myModel.Control);
        myContent.Width += Math.Max(0, control.Width - myContent.Width);

        control.Dock = DockStyle.Fill;
        myContent.Controls.Add(control);
      }

      Update();
    }

    private void myOk_Click(object sender, EventArgs e)
    {
      if (myModel.Ok())
      {
        DialogResult = DialogResult.OK;
      }
    }

    private void myCancel_Click(object sender, EventArgs e)
    {
      if (myModel.Cancel())
      {
        DialogResult = DialogResult.Cancel;
      }
    }
  }
}