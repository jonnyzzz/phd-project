using System.Windows.Forms;

namespace DSIS.UI.Wizard
{
  public interface IHeaderControl
  {
    string MainTitle { get; set; }
    string SecondaryTitle { get; set; }
  }

  public partial class HeaderControl : UserControl, IHeaderControl
  {
    public HeaderControl()
    {
      InitializeComponent();
    }

    public string MainTitle
    {
      get { return myMainTitle.Text;}
      set { myMainTitle.Text = value;}
    }

    public string SecondaryTitle
    {
      get { return mySecondaryTitle.Text;}
      set { mySecondaryTitle.Text = value;}
    }
  }
}