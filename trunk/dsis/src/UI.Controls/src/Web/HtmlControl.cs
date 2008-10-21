using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;

namespace DSIS.UI.Controls.Web
{
  public class HtmlControl : Control
  {
    private readonly WebBrowser myBrowser;

    public HtmlControl()
    {
      myBrowser = new WebBrowser { Dock = DockStyle.Fill };
      Controls.Add(myBrowser);
    }

    [Obsolete("Use SetContext")]
    public void SetHTML(string code)
    {
      myBrowser.DocumentText = code;
    }

    public void SetContext(Action<XmlElement> root)
    {
      var doc = new XmlDocument();
      doc.LoadXml("<html><head><title></title></head><body/></html>");
      root((XmlElement) doc.SelectSingleNode("html/body"));

      SetHTML(doc.OuterXml);
    }
  }
}