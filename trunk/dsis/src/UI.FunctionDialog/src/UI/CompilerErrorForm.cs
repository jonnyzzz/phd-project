using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DSIS.Function.UserDefined;
using DSIS.Utils;

namespace DSIS.UI.FunctionDialog.UI
{
  public partial class CompilerErrorForm : Form
  {
    public CompilerErrorForm()
      : this(Pair.Create<string, ICollection<CodeError>>("Text", EmptyArray<CodeError>.Instance))
    {
    }

    public CompilerErrorForm(Pair<string, ICollection<CodeError>> error)
    {
      InitializeComponent();
      myText.Lines = CollectionUtil.ToArray(error.First.Split('\n').Convert(x => x.Trim()));
    }

    private void myCancel_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }

    private void myRetry_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Retry;
    }
  }
}