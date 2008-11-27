using DSIS.Core.Ioc;
using DSIS.Utils;

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
  }
}