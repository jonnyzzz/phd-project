namespace DSIS.Core.System.Impl
{
  public interface ISystemSpaceFactory
  {
    ISystemSpace CreateSymmetricalSpace(int dim, double size, long grid);
    ISystemSpace CreateSameSpace(int dim, double left, double right, long grid);
    ISystemSpace CreateSpace(int dim, double[] left, double[] right, long[] grid);
  }
}