namespace DSIS.Core.System.Impl
{
  public interface ISystemSpaceFactory
  {
    ISystemSpace CreateSymmetricalSpace(int dim, double size, long grid);
  }
}