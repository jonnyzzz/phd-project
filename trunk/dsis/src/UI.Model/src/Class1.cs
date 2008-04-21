using System.Collections.Generic;

namespace DSIS.UI.Model
{  
  /// <summary>
  /// Represents any result that is possible to be shown in the tree
  /// </summary>
  public interface IResult
  {
    string ShortName { get; }    
  }

  /// <summary>
  /// Collection of results, that is contained in some tree node
  /// </summary>
  public interface IResultSet
  {
    List<IResult> Results { get;}    
  }

  /// <summary>
  /// Represents action that is possible to be applied to IResultSet
  /// </summary>
  public interface IAction
  {
    string ShortName { get; }

    IEnumerable<ActionIncompatibilityInfo> IsCompatible(IResultSet set);

    IResultSet Do(IResultSet input, IActionParameters parameters);
  }

  /// <summary>
  /// All necessary action parameters
  /// </summary>
  public interface IActionParameters
  {    
  }
  
  public class ActionIncompatibilityInfo
  {
    
  }
}