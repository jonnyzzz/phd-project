using System;
using System.Windows.Forms;

namespace DSIS.UI.ComputationDialogs
{
  public interface ISIComputationConstraintUI
  {
    bool Enabled { get; }
    string SortName { get; }
    ISIComputationConstraint CreateConstraint();
    Control Control { get; }

    event Action<Control, string> Error;
  }
}