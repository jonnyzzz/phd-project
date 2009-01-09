using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DSIS.UI.Application.Doc.CurrentStep;
using DSIS.UI.Controls;
using DSIS.UI.Controls.Web;
using DSIS.UI.UI;
using DSIS.Utils;

namespace DSIS.UI.Application.Doc
{
  [DocumentComponent]
  public class CurrentDocumentControl : HtmlControl, IDocumentControl
  {
    public CurrentDocumentControl(IApplicationDocument doc, IEnumerable<ICurrentStepCustomParameter> _custom)
    {
      var ctx = doc.Content; 
      var custom = new List<ICurrentStepCustomParameter>(_custom.Where(x => x.IsAvailable(ctx)));
      custom.Sort((o1, o2) => o1.Order.CompareTo(o2.Order));

      SetContext(x=> x.CreateChildElement("h1").CreateText(doc.Title).ParentNode
                       .CreateChildElement("dl")
                       .With(xx=>custom.ForEach(c=>Pair(xx, c.Name,c.GetValue(ctx).Split(new[]{Environment.NewLine}, StringSplitOptions.None)))));
    }

    public Layout[] Float
    {
      get { return new[]{DSIS.UI.Controls.Layout.LEFT,DSIS.UI.Controls.Layout.CENTER };} 
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
