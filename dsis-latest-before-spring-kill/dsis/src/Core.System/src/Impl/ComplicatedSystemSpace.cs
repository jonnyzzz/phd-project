using System.Collections.Generic;

namespace DSIS.Core.System.Impl
{
  public class ComplicatedSystemSpace : DefaultSystemSpace
  {
    private readonly List<ISystemSpace> myMinuses = new List<ISystemSpace>();

    public ComplicatedSystemSpace(int dimension, double[] areaLeftPoint, double[] areaRightPoint, long[] initialSubdivision) : base(dimension, areaLeftPoint, areaRightPoint, initialSubdivision)
    {
    }

    public override bool Contains(double[] point)
    {
      if (!base.Contains(point))
        return false;

      foreach (var space in myMinuses)
      {
        if (space.Contains(point))
          return false;
      }
      return true;
    }

    public override bool ContainsRect(double[] left, double[] right)
    {
      if (!base.ContainsRect(left, right))
        return false;
      foreach (var space in myMinuses)
      {
        if (space.ContainedRect(left, right))
          return false;
      }
      return true;
    }
  }
}