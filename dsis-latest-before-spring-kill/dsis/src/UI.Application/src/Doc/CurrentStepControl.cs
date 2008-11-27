using System.Windows.Forms;
using DSIS.UI.Controls;
using DSIS.UI.Controls.Web;
using DSIS.UI.UI;
using Keys=DSIS.Scheme.Impl.Keys;
using DSIS.Utils;
using DSIS.Scheme.Impl;

namespace DSIS.UI.Application.Doc
{
  [DocumentComponent]
  public class CurrentStepControl : UserControl, IDocumentControl
  {
    public CurrentStepControl(IApplicationDocument document)
    {
      var html = new HtmlControl {Dock = DockStyle.Fill};
      var ctx = document.Content;

      if (ctx.ContainsKey(Keys.IntegerCoordinateSystemInfo))
      {
        var cs = Keys.IntegerCoordinateSystemInfo.Get(ctx);
        html.SetContext(x=> x.CreateChildElement("dl").
                              CreateChildElement("dt").CreateText("Subdivision").ParentNode.
                              CreateChildElement("dd").CreateText(cs.Subdivision.JoinString("x")).ParentNode.
                              CreateChildElement("dt").CreateText("CellSize").ParentNode.
                              CreateChildElement("dd").CreateText(cs.CellSize.JoinString(", ")).ParentNode.
                              CreateChildElement("dt").CreateText("Number of cells").ParentNode.
                              CreateChildElement("dd").CreateText(ctx.CellEnumeratorCount().ToString()));
      } else
      {
        html.SetContext(x=>x.CreateChildElement("p").CreateText("No coordinate system defined"));
      }
      Controls.Add(html);
    }

    public Layout[] Float
    {
      get { return new [] {DSIS.UI.Controls.Layout.LEFT, DSIS.UI.Controls.Layout.TOP, }; }
    }

    public string Ancor
    {
      get { return "010"; }
    }

    public Control Control
    {
      get { return this; }
    }
  }
}