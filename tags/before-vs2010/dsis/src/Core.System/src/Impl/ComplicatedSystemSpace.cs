using System.Collections.Generic;
using System.Linq;

namespace DSIS.Core.System.Impl
{
  public class ComplicatedSystemSpace : DefaultSystemSpace
  {
    private readonly List<ISystemSpace> myMinuses = new List<ISystemSpace>();

    public ComplicatedSystemSpace(IEnumerable<ISystemSpace> spaces)
      : base(
      spaces.Sum(x=>x.Dimension), 
      spaces.SelectMany(x=>x.AreaLeftPoint).ToArray(),
      spaces.SelectMany(x => x.AreaRightPoint).ToArray(),
      spaces.SelectMany(x => x.InitialSubdivision).ToArray())
    {
    }

    public override bool Contains(double[] point)
    {
      if (!base.Contains(point))
        return false;

      return myMinuses.All(space => !space.Contains(point));
    }

    public override bool ContainsRect(double[] left, double[] right)
    {
      if (!base.ContainsRect(left, right))
        return false;
      return myMinuses.All(space => !space.ContainedRect(left, right));
    }
  }
}