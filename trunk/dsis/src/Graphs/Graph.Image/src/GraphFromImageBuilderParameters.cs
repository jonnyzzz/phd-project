using System;
using System.Drawing;
using System.Linq.Expressions;

namespace DSIS.Graph.Images
{
  public class GraphFromImageBuilderParameters
  {
    public Expression<Func<Color, double>> Hash { get; set; }
    public int NumberOfNeighboursPerAxis { get; set; }
  }


  public class ComplexGraphFromImageBuilderParameters : GraphFromImageBuilderParameters
  {
    public int NumberOfEdgesPerPixel { get; set; }
    public double Threasold { get; set; }
  }

  public class FullGraphFromImageBuilderParameters : GraphFromImageBuilderParameters
  {
  }

}