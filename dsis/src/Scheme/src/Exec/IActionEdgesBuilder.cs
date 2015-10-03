using System;
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

    IActionEdgesBuilder With(Action<IActionEdgesBuilder> closure);    
  }

  public static class ActionEdgesBuilderExt
  {
    public static IActionEdgesBuilder WithBack(this IActionEdgesBuilder bld, params IActionEdgesBuilder[] data)
    {
      foreach (var b in data)
      {
        bld.Back(b);
      }
      return bld;
    }

    public static IActionEdgesBuilder WithBack(this IActionEdgesBuilder bld, params IAction[] data)
    {
      foreach (var b in data)
      {
        bld.Back(b);
      }
      return bld;
    }
  }
}