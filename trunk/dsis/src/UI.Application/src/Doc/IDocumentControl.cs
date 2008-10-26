using System.Collections.Generic;
using DSIS.UI.Controls;

namespace DSIS.UI.Application.Doc
{
  public interface IDocumentControl : IControlWithLayout2
  {
    
  }

  /// <summary>
  /// In case it is impossible to provide context-free control using <see cref="IDocumentControl"/>
  /// one may register implementation of that interface.
  /// </summary>
  public interface IDocumentControlFactory
  {
    IEnumerable<IDocumentControl> CreateDocumentControls();
  }
    
}