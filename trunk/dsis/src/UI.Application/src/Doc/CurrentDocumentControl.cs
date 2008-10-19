using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using DSIS.Core.Ioc;
using DSIS.Core.System;
using DSIS.UI.Controls;
using DSIS.UI.Controls.Web;
using DSIS.UI.UI;

namespace DSIS.UI.Application.Doc
{
  [ComponentImplementation]
  public class CenterControl : UserControl, IDocumentControl
  {
    public CenterControl()
    {
      BackColor = Color.Red;
    }

    public Layout Float
    {
      get { return DSIS.UI.Controls.Layout.CENTER; }
    }

    public string Ancor
    {
      get { return "!"; }
    }

    public Control Control
    {
      get { return this; }
    }
  }

  [DocumentComponent]
  public class CurrentDocumentControl : HtmlControl, IDocumentControl
  {
    public CurrentDocumentControl(IApplicationDocument doc)
    {
      SetHTML(@"
         <html>
           <body>
             <h1>" + doc.Title + @"</h1>
             <dl>
               <dt>Function</dt>
               <dd>" + doc.System.PresentableName + @"</dd>
               
               <dt>Space</dt>
               <dd>" + PresentSystemSpace(doc.Space) + @"</dd>
             </dl>
           </body>
         </html>");
    }

    private static string PresentSystemSpace(ISystemSpace space)
    {
      var doc = new XmlDocument();
      var node = doc.CreateElement("dd");

      var text = "";
      for (int i = 0; i < space.Dimension; i++)
      {
        text += string.Format("[{0}, {1}]x{2}", space.AreaLeftPoint[i], space.AreaRightPoint[i],
                              space.InitialSubdivision[i]);
        text += "<br />";
      }

      node.InnerXml = text;

      return node.InnerXml;
    }

    public Layout Float
    {
      get { return DSIS.UI.Controls.Layout.WEST; }
    }

    public string Ancor
    {
      get { return "Z"; }
    }

    public Control Control
    {
      get { return this; }
    }
  }
}
