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
  /// All necessary action parameters
  /// </summary>
  public interface IActionParameters
  {    
  }
  
  public class ActionIncompatibilityInfo
  {
    
  }


  public interface IDocument
  {
  
  }

  public interface IApplication
  {
    void DocumentOpened(IDocument document);
    void DocumentClosed(IDocument document);
  }
}