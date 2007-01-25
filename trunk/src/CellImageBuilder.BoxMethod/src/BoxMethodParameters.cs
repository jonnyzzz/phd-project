using DSIS.Core.Coordinates;

namespace DSIS.CellImageBuilder
{
  public sealed class BoxMethodParameters : ICellImageBuilderSettings
  {
    private readonly double myEps;

    /// <summary>
    /// Relative epsilone to be added as border to the build rectangle.
    /// Eps = 1 means 1 cell size on the corresponding coordinate
    /// </summary>
    public double Eps { get { return myEps;} }

    public BoxMethodParameters(double eps)
    {
      myEps = eps;
    }

    public static readonly BoxMethodParameters DefaultBoxMethodParameters = new BoxMethodParameters(0.1);
  }
}