using DSIS.Utils;

namespace DSIS.Scheme.Exec
{
  public interface IActionEdgesBuilder
  {

    /// <returns>Action builder from newly added action</returns>
    IActionEdgesBuilder Edge(IAction action);
    
    /// <returns>this</returns>
    IActionEdgesBuilder Edge(IActionEdgesBuilder id);

    IActionEdgesBuilder With(DAction<IActionEdgesBuilder> closure);    
  }
}