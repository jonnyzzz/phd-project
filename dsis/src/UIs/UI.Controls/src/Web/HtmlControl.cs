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
      TabStop = false;
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
      
      var style = doc.CreateElement("style");
      style.SetAttribute("type", "text/css");
      style.InnerText = @"
         html {
           overflow-y: scroll;
         }

         body {
            font-family: havletica, tahoma, verdana, arial, sans-serif;
            font-size: 12pt;
            margin: 0;
            padding: 0;
            color: #3f3f3f;
            background: #fff;
            width:100%;
            padding-top: 0.2em;
          }

        h1, h2, h3, h4, h5 {          
        }

        img {
          border: none
        }

        a {
          color: #ED2C10;
        }

        a:visited {
          color: #ED2C10;
        }

        a:hover {
          text-decoration: none;
          color: white;
          background-color: #ED2C10;
        }
      ";
      var head = doc.SelectSingleNode("html/head");
      head.AppendChild(style);
      
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