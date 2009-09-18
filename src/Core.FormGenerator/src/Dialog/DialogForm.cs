using System.Windows.Forms;

namespace EugenePetrenko.Core.FormGenerator.Dialog
{
  public partial class DialogForm : Form
  {
    private readonly IDialogModel myModel;

    public DialogForm()
    {
      InitializeComponent();
    }

    public DialogForm(IDialogModel model) : this()
    {
      myModel = model;
      var value = myModel.Control;
      value.Dock = DockStyle.Fill;
      myContent.Controls.Add(value);
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