using System;
using System.Windows.Forms;

namespace DSIS.UI.ComputationDialogs.Constraints
{
  [SIConstructionComponent]
  public class RepeatCountTool : ISIComputationConstraintUI
  {
    private readonly RepeatCountToolControl myControl;

    public RepeatCountTool()
    {
      myControl = new RepeatCountToolControl();
    }

    public bool Enabled
    {
      get { return myControl.Enabled; }
    }

    public string SortName
    {
      get { return "1000"; }
    }

    public ISIComputationConstraint CreateConstraint()
    {
      return Enabled ? new RepeatCountToolConstraint(myControl.Times.Value) : null;
    }

    public Control Control
    {
      get { return myControl; }
    }

    public event Action<Control, string> Error
    {
      add { myControl.Error += value; }
      remove { myControl.Error -= value; }
    }
  }
}