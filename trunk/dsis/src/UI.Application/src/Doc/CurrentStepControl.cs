using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
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
    public CurrentStepControl(IApplicationDocument document, IEnumerable<ICurrentStepCustomParameter> _custom)
    {
      var html = new HtmlControl {Dock = DockStyle.Fill};
      var ctx = document.Content;
      var custom = new List<ICurrentStepCustomParameter>(_custom.Filter(x=>x.IsAvailable(ctx)));
      custom.Sort((o1, o2) => o1.Name.CompareTo(o2.Name));

      if (ctx.ContainsKey(Keys.IntegerCoordinateSystemInfo))
      {
        var pair = (Func<XmlNode, string, string, XmlNode>) html.Pair;

        var cs = Keys.IntegerCoordinateSystemInfo.Get(ctx);
        html.SetContext(x=> x.CreateChildElement("dl").
                              With(xx=>pair(xx, "Subdivision", cs.Subdivision.JoinString("x"))).
                              With(xx=>pair(xx, "CellSize", cs.CellSize.JoinString(d=>d.ToString("E"),", "))).
                              With(xx=>pair(xx, "Number of cells", ctx.CellEnumeratorCount().ToString())).
                              With(xx=>custom.ForEach(c=>pair(xx, c.Name,c.GetValue(ctx))))
                              );
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