using System.Windows.Forms;

namespace DSIS.UI.Controls.Web
{
  public class HtmlControl : Control
  {
    private readonly WebBrowser myBrowser;

    public HtmlControl()
    {
      myBrowser = new WebBrowser
                    {
                      Dock = DockStyle.Fill
                    };
      Controls.Add(myBrowser);
    }

    public void SetHTML(string code)
    {
      myBrowser.DocumentText = code;
    }
  }
}