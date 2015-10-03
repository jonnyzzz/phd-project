using DSIS.Utils;

namespace DSIS.Scheme.Exec
{
  public interface IActionEdgesBuilder
  {
    /// <returns>Action builder from newly added action</returns>
    IActionEdgesBuilder Edge(IAction action);
    
    /// <returns>this</returns>
    IActionEdgesBuilder Edge(IActionEdgesBuilder id);

    /// <returns>id</returns>
    IActionEdgesBuilder Back(IActionEdgesBuilder id);

    /// <returns>IActionBuilder for id</returns>
    IActionEdgesBuilder Back(IAction id);

    IActionEdgesBuilder With(DAction<IActionEdgesBuilder> closure);    
  }
}