namespace DSIS.UI.FunctionDialog
{
  public class FixedDimensionSpaceModel : SpaceModel
  {
    public FixedDimensionSpaceModel(int dimension) : base(dimension)
    {
    }

    public override int Dimension
    {
      get { return base.Dimension; }
      set { }
    }

    public override bool CanChangeDimension
    {
      get { return false; }
    }
  }
}