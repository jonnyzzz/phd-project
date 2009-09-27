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
      var value = myModel.Control;
      value.Dock = DockStyle.Fill;

      var sz = Size - myContent.Size + value.Size;
      using(this.UpdateCookie())
      {
        value = scroll.MakeScrollableOnY(value);
        myContent.Controls.Add(value);

        Size += sz;
      }
    }

    private void myOk_Click(object sender, System.EventArgs e)
    {
      if (myModel.Ok())
      {
        DialogResult = DialogResult.OK;
      }
    }

    private void myCancel_Click(object sender, System.EventArgs e)
    {
      if (myModel.Cancel())
      {
        DialogResult = DialogResult.Cancel;
      }
    }
  }
}