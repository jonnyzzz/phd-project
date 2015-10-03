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
    private readonly List<IDocumentCenterControl> myCenterControls = new List<IDocumentCenterControl>();
    private readonly IApplicationDocument myDocument;
    private readonly SmartLayoutManager mySmartLayout;

    [Used]
    public DocumentControl(IApplicationDocument doc,
                           IEnumerable<IDocumentControlFactory> factories,
                           IEnumerable<IDocumentCenterControlFactory> centerFactories,
                           SmartLayoutManager smartLayout)
    {
      myDocument = doc;
      mySmartLayout = smartLayout;
      myControls.AddRange(factories.Maps(x => x.CreateDocumentControls()));
      myCenterControls.AddRange(centerFactories.Maps(x => x.CreateDocumentCenterControls()));

      myCenterControls.Sort((x, y) => x.SortOrder.CompareTo(y.SortOrder));
    }

    public IControlWithTitle Control { get; private set; }

    public void Start()
    {
      var ex = new TabbedLayout().Layout(myCenterControls);
      var controls = myControls.Cast<IControlWithLayout2>().Join(new ControlWithLayout2(ex, "center", Layout.CENTER));
      Control = new ControlWithTitle(
        mySmartLayout.LayoutControls(controls), "DSIS :: " + myDocument.Title);
    }
  }
}