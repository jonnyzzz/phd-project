using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DSIS.Graph;
using DSIS.UI.Controls;
using DSIS.UI.UI;
using DSIS.UI.Wizard.FormsGenerator;
using DSIS.Utils;

namespace DSIS.UI.ComputationDialogs.Components
{
  [ComponentsComponentImplementation]
  public class ComponentsCheckBoxesControl : UserControl, IErrorProvider<bool>
  {
    private readonly HashSet<IStrongComponentInfo> mySelection = new HashSet<IStrongComponentInfo>();

    public event EventHandler SelectionChanged;

    public ComponentsCheckBoxesControl(IGraphStrongComponents components, IDockLayout layout, IScrollableLayout scroller)
    {
      BuildCheckboxes(components.Components, layout);
      scroller.MakeScrollableOnY(this);
    }

    private void BuildCheckboxes(IEnumerable<IStrongComponentInfo> info, IDockLayout layout)
    {
      Padding = new Padding(7,7,0,0);

      var lbl = new Label {Text = "Select components: "};

      var checkboxes = ((Control) lbl).Enum().Join(
        info.OrderBy(x => -x.NodesCount).Take(1000).Select(x => CreateCheckBox(x))
        );

      layout.Layout(this, DockStyle.Top, checkboxes);
    }

    bool IErrorProvider<bool>.Validate()
    {
      return mySelection.Count > 0;
    }

    public ICollection<IStrongComponentInfo> GetSelectedComponents()
    {
      return new List<IStrongComponentInfo>(mySelection);
    }

    private CheckBox CreateCheckBox(IStrongComponentInfo info)
    {
      var cb = new CheckBox
                 {
                   Text = info.NodesCount + " nodes",
                   Checked = mySelection.Contains(info),
                   Padding = new Padding(10, 0, 0, 0)
                 };
      cb.CheckedChanged += delegate
                             {
                               if (cb.Checked)
                               {
                                 mySelection.Add(info);
                               }
                               else
                               {
                                 mySelection.Remove(info);
                               }

                               if (SelectionChanged != null)
                               {
                                 SelectionChanged(this, EventArgs.Empty);
                               }
                             };
      return cb;
    }
  }
}