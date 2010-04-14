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

    private string myMainTitleCache;
    private string mySecondaryTitleCache;

    public string MainTitle
    {
      get { return myMainTitleCache; }
      set
      {
        if (myMainTitleCache != value)
        {
          myMainTitleCache = myMainTitle.Text = value;
        }
      }
    }

    public string SecondaryTitle
    {
      get { return mySecondaryTitleCache; }
      set
      {
        if (mySecondaryTitleCache != value)
        {
          mySecondaryTitleCache = mySecondaryTitle.Text = value;
        }
      }
    }
  }
}