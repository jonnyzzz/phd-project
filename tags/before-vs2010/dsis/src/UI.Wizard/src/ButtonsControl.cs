using System.Windows.Forms;

namespace DSIS.UI.Wizard
{
  public partial class ButtonsControl : UserControl
  {
    private bool myNextEnabled = true;
    private bool myBackEnabled = true;
    private bool myFinishEnabled = true;
    private bool myCancelEnabled = true;
    

    public ButtonsControl()
    {
      InitializeComponent();
    }

    public bool NextEnabled
    {
      get { return myNextEnabled; }
      set { if (myNextEnabled != value) ButtonNext.Enabled = myNextEnabled = value; }
    }

    public bool BackEnabled
    {
      get { return myBackEnabled; }
      set { if (myBackEnabled != value) ButtonBack.Enabled = myBackEnabled = value; }
    }

    public bool FinishEnabled
    {
      get { return myFinishEnabled; }
      set { if (myFinishEnabled != value) ButtonFinish.Enabled = myFinishEnabled = value; }
    }

    public bool CancelEnabled
    {
      get { return myCancelEnabled; }
      set { if (myCancelEnabled != value) ButtonCancel.Enabled = myCancelEnabled = value; }
    }
  }
}