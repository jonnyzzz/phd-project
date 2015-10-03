using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.UI.Controls;
using DSIS.UI.Wizard;

namespace DSIS.UI.ComputationDialogs
{
  [SIConstructionComponent]
  public class SubdivisionWizardPage : WizardPageBase<SubdivisionEditorControl>
  {
    public SubdivisionWizardPage(ICellCoordinateSystem system, IDockLayout layout, IEnumerable<ISIComputationConstraintUI> ui)
    {
      Title = "Select Subdivision";
      ControlInternal = new SubdivisionEditorControl(system, layout, ui);
    }

    public SubdivisionResult GetResult()
    {
      return ControlInternal.GetResult();
    }
  }
}