namespace DSIS.UI.ComputationDialogs
{
  public class TotalSubdivisionFieldControl : SubdivisionEditableFieldControl
  {
    public TotalSubdivisionFieldControl() : this("Total: ")
    {
    }

    public TotalSubdivisionFieldControl(string axis) : base(axis, 0, 0)
    {
      mySubdivisionText.ReadOnly = true;
    }
  }
}