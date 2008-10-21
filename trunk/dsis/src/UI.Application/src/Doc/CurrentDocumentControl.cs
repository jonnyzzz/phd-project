using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using DSIS.Core.System;
using DSIS.UI.Controls;
using DSIS.UI.Controls.Web;
using DSIS.UI.UI;
using DSIS.Utils;

namespace DSIS.UI.Application.Doc
{
  [DocumentComponent]
  public class CurrentDocumentControl : HtmlControl, IDocumentControl
  {
    public CurrentDocumentControl(IApplicationDocument doc)
    {
      SetContext(x=> x.CreateChildElement("h1").CreateText(doc.Title).ParentNode
                       .CreateChildElement("dl")
                       .CreateChildElement("dt").CreateText("Function").ParentNode
                       .CreateChildElement("dd").CreateText(doc.System.PresentableName).ParentNode
                       .CreateChildElement("dt").CreateText("Initial Space").ParentNode
                       .CreateChildElement("dd").CreateText(PresentSystemSpace(doc.Space)));
      Size = MinimumSize = new Size(200,170);
    }

    private static IEnumerable<string> PresentSystemSpace(ISystemSpace space)
    {
      for (int i = 0; i < space.Dimension; i++)
      {
        yield return string.Format("[{0}, {1}]x{2}", space.AreaLeftPoint[i], space.AreaRightPoint[i],
                              space.InitialSubdivision[i]);
      }
    }

    public Layout[] Float
    {
      get { return new[]{DSIS.UI.Controls.Layout.LEFT,DSIS.UI.Controls.Layout.TOP };} 
    }

    public string Ancor
    {
      get { return "001"; }
    }

    public Control Control
    {
      get { return this; }
    }
  }
}
