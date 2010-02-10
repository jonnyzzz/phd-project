using System.Collections.Generic;

namespace DSIS.UI.Model
{
  /// <summary>
  /// Represents action that is possible to be applied to IResultSet
  /// </summary>
  public interface IAction
  {
    string ShortName { get; }

    IEnumerable<ActionIncompatibilityInfo> IsCompatible(IResultSet set);

    IResultSet Do(IResultSet input, IActionParameters parameters);
  }  
}