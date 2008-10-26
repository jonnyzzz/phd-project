using System.Collections.Generic;
using DSIS.Core.Ioc;
using DSIS.UI.Controls;
using DSIS.UI.UI;
using DSIS.Utils;

namespace DSIS.UI.Application.Doc
{
  [DocumentComponent]
  public class DocumentControl : IDocumentMainControl, IStartableComponent
  {
    private readonly List<IDocumentControl> myControls = new List<IDocumentControl>();
    private readonly IApplicationDocument myDocument;

    [Used]
    public DocumentControl(IApplicationDocument doc, IDocumentControl[] controls, IDocumentControlFactory[] factories)
    {
      myDocument = doc;
      myControls.AddRange(controls);
      foreach (var f in factories)
      {
        myControls.AddRange(f.CreateDocumentControls());
      }
    }

    public IControlWithTitle Control { get; private set;}

    public void AddControl(IDocumentControl control)
    {
      myControls.Add(control);
    }

    public void Start()
    {
      var m = new SmartLayoutManager();
      Control = new ControlWithTitle(m.LayoutControls(myControls), "DSIS :: " + myDocument.Title);
    }
  }
}