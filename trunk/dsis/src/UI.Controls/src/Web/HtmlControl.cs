using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using DSIS.Utils;

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

    /// <summary>
    /// thread safe method
    /// </summary>
    public void SetContext(Action<XmlElement> root)
    {
      var doc = new XmlDocument();
      doc.LoadXml("<html><head><title></title></head><body/></html>");
      root((XmlElement) doc.SelectSingleNode("html/body"));

      var code = doc.OuterXml;
      this.InvokeAction(() => SetHTML(code));
    }

    public XmlNode Pair(XmlNode node, string key, string value)
    {
      return node.CreateChildElement("dt").CreateText(key).ParentNode.
                  CreateChildElement("dd").CreateText(value).ParentNode;

    }

    public XmlNode Pair(XmlNode node, string key, IEnumerable<string> value)
    {
      return node.CreateChildElement("dt").CreateText(key).ParentNode.
                  CreateChildElement("dd").CreateText(value).ParentNode;

    }
  }
}