using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DSIS.Core.Coordinates;
using DSIS.UI.ComputationDialogs.Constraints;
using DSIS.UI.Controls;
using DSIS.Utils;

namespace DSIS.UI.ComputationDialogs
{
  public partial class SubdivisionEditorControl : UserControl
  {
    private readonly List<SubdivisionEditableFieldControl> myControls;
    private readonly List<ISIComputationConstraintUI> myConstrains;

    public SubdivisionEditorControl()
    {
      InitializeComponent();
    }

    private void SetError(Control control, string message)
    {
      myErrorProvider.SetError(control, message);
    }

    public SubdivisionEditorControl(ICellCoordinateSystem system, IDockLayout layout, IEnumerable<ISIComputationConstraintUI> constrains)
      : this()
    {
      myControls = new List<SubdivisionEditableFieldControl>();
      myTotal.ActualValue = system.Subdivision.FoldLeft(1L, (x, v) => x*v);

      foreach (var i in system.Dimension.Each())
      {
        var item = new SubdivisionEditableFieldControl((1+i).ToString(), system.Subdivision[i], 2);
        item.Error += SetError;
        item.Changed += SubdivisionChanged;
        myControls.Add(item);
      }

      layout.Layout(myHost, DockStyle.Top, myControls);

      myConstrains = constrains.Sort((x, y) => x.SortName.CompareTo(y.SortName)).ToList();
      myConstrains.ForEach(x=>x.Error += SetError);

      layout.Layout(myRepeatPluginsHost, DockStyle.Top, myConstrains.Map(x => x.Control));

      SubdivisionChanged(this, EventArgs.Empty);
      RepeatCheckedChanged(this, EventArgs.Empty);
    }

    private void SubdivisionChanged(object sender, EventArgs e)
    {
      myTotal.SubdivisionValue = myControls.FoldLeft((long?)1L, (x, v) => (x.SubdivisionValue == null ? null : v == null ? null : x.SubdivisionValue*v));
    }

    public SubdivisionResult GetResult()
    {
      return new SubdivisionResult(Subdivision, myUseUnsimmetricCheckbox.Checked, 
        myRepeatCheckbox.Checked 
        ? from c in myConstrains where c.Enabled select c.CreateConstraint()
        : new[]{new OneStepConstraint()}
        );
    }

    public long[] Subdivision
    {
      get
      {
        if (HasErrors)
          return null;
        return myControls.Map(x => x.SubdivisionValue ?? 0L).ToArray();
      }
    }

    private bool HasErrors
    {
      get { return !myControls.FoldLeft(true, (x, v) => !x.HasError && v); }
    }

    private void RepeatCheckedChanged(object sender, EventArgs e)
    {
      myRepeatPluginsHost.Enabled = myRepeatCheckbox.Checked;
    }
  }
}