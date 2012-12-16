using System;
using System.Drawing;
using System.Linq.Expressions;
using DSIS.Utils;

namespace DSIS.Graph.Images
{
  public abstract class GraphFromImageBuilderParameters : ICloneable<GraphFromImageBuilderParameters>, ILoggable
  {
    public Expression<Func<Color, double>> Hash { get; set; }
    public int NumberOfNeighboursPerAxis { get; set; }

    public GraphFromImageBuilderParameters Clone()
    {
      var v = CloneImpl();
      v.Hash = Hash;
      v.NumberOfNeighboursPerAxis = NumberOfNeighboursPerAxis;
      return v;
    }

    protected abstract GraphFromImageBuilderParameters CloneImpl();

    public virtual void Log(ILogger log)
    {
      log.Write("Hash: {0}", Hash);
      log.Write("NumberOfNeighboursPerAxis: {0}", NumberOfNeighboursPerAxis);
    }
  }

  public class ComplexGraphFromImageBuilderParameters : GraphFromImageBuilderParameters
  {
    public int NumberOfEdgesPerPixel { get; set; }
    public double Threasold { get; set; }

    protected override GraphFromImageBuilderParameters CloneImpl()
    {
      return new ComplexGraphFromImageBuilderParameters()
        {
          NumberOfEdgesPerPixel = NumberOfEdgesPerPixel,
          Threasold = Threasold,
        };
    }

    public override void Log(ILogger log)
    {
      base.Log(log);
      log.Write("Threahold: {0}", Threasold);
      log.Write("NumberOfEdgesPerPixel: {0}", NumberOfEdgesPerPixel);
    }
  }

  public class FullGraphFromImageBuilderParameters : GraphFromImageBuilderParameters
  {
    protected override GraphFromImageBuilderParameters CloneImpl()
    {
      return new FullGraphFromImageBuilderParameters();
    }
  }
}
