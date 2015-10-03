using DSIS.Utils;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.Core.System.Impl
{
  [ComponentImplementation]
  public class SystemSpaceFactory : ISystemSpaceFactory
  {
    public ISystemSpace CreateSymmetricalSpace(int dim, double size, long grid)
    {
      var grids = grid.Fill(dim);
      var left = (-size).Fill(dim);
      var right = size.Fill(dim);
      return new DefaultSystemSpace(dim, left, right, grids);
    }

    public ISystemSpace CreateSameSpace(int dim, double left, double right, long grid)
    {
      return new DefaultSystemSpace(dim, left.Fill(dim), right.Fill(dim), grid.Fill(dim));
    }

    public ISystemSpace CreateSpace(int dim, double[] left, double[] right, long[] grid)
    {
      return new DefaultSystemSpace(dim, left, right, grid);
    }
  }
}