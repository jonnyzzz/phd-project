using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DSIS.Core.Coordinates;
using DSIS.UI.Controls;
using DSIS.UI.UI;
using DSIS.Utils;

namespace DSIS.UI.ComputationDialogs
{
  public partial class SubdivisionEditorControl : UserControl, IErrorProvider<bool>
  {
    private readonly List<SubdivisionEditableFieldControl> myControls;

    public SubdivisionEditorControl()
    {
      InitializeComponent();
    }

    private void SetError(Control control, string message)
    {
      myErrorProvider.SetError(control, message);
    }

    public SubdivisionEditorControl(ICellCoordinateSystem system, IDockLayout layout)
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

      SubdivisionChanged(this, EventArgs.Empty);
    }

    private void SubdivisionChanged(object sender, EventArgs e)
    {
      myTotal.SubdivisionValue = myControls.FoldLeft((long?)1L, (x, v) => (x.SubdivisionValue == null ? null : v == null ? null : x.SubdivisionValue*v));
    }

    bool IErrorProvider<bool>.Validate()
    {
      return !HasErrors;
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
  }
}