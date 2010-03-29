using System.Drawing;

namespace DSIS.UI.ComputationDialogs
{
  public class HeaderSubdivisionFieldControl : SubdivisionFieldControl
  {
    public HeaderSubdivisionFieldControl() : base("")
    {
      myActualValueText.Text = "Actual";
      mySubdivisionText.Text = "Subdivide";
      myEstimateText.Text = "Estimate";

      mySubdivisionText.ReadOnly = true; 

      myActualValueText.Font = new Font(myActualValueText.Font, FontStyle.Bold);
      mySubdivisionText.Font = new Font(myActualValueText.Font, FontStyle.Bold);
      myEstimateText.Font = new Font(myActualValueText.Font, FontStyle.Bold);
    }
  }
}