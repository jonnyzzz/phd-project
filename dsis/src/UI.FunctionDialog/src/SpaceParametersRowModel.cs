namespace DSIS.UI.FunctionDialog
{
  public class SpaceParametersRowModel
  {    
    public double Left { get; set; }

    public double Right { get; set; }

    public long Grid { get; set; }

    public SpaceParametersRowModel()
    {
      Right = 10;
      Grid = 3;
    }

    public SpaceParametersRowModel(SpaceParametersRowModel model)
    {
      Left = model.Left;
      Right = model.Right;
      Grid = model.Grid;
      Right = 10;
      Grid = 3;
    }
  }
}