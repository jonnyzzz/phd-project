using System.Collections.Generic;

namespace DSIS.UI.Application.Doc
{
  /// <summary>
  /// In case it is impossible to provide context-free control using <see cref="IDocumentControl"/>
  /// one may register implementation of that interface.
  /// </summary>
  public interface IDocumentControlFactory
  {
    IEnumerable<IDocumentControl> CreateDocumentControls();    
  }
}