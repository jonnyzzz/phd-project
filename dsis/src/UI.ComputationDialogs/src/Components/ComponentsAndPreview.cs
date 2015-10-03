using System.Collections.Generic;
using System.Windows.Forms;
using DSIS.Graph;
using DSIS.UI.UI;

namespace DSIS.UI.ComputationDialogs.Components
{
  [ComponentsComponentImplementation]
  public class ComponentsAndPreview : UserControl
  {
    private readonly ComponentsCheckBoxesControl myControl;

    public ComponentsAndPreview(IGraphStrongComponents components, ComponentsCheckBoxesControl control, ISymbolicImageDrawControlFactory factory)
    {
      myControl = control;

      var view = factory.Create(components, components.Components);

      var viewControl = view.Control;
      viewControl.Dock = DockStyle.Fill;
      Controls.Add(viewControl);

      control.SelectionChanged += delegate
                                    {
                                      view.Components = control.GetSelectedComponents();
                                    };

      control.Width = 150;
      control.Dock = DockStyle.Left;
      Controls.Add(control);
    }

    public ICollection<IStrongComponentInfo> GetSelectedComponents()
    {
      return myControl.GetSelectedComponents();
    }
  }
}