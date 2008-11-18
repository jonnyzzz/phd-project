using System.Collections.Generic;
using DSIS.UI.Controls;
using DSIS.UI.UI;

namespace DSIS.UI.Application.Doc
{
  public interface IDocumentComponent
  {
    void BeforeDocumentContainerDisposed();
  }

  public interface IDocumentControl : IControlWithLayout2
  {
    
  }

  public interface IDocumentCenterControl : IControlWithTitle
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

  /// <summary>
  /// In case it is impossible to provide context-free control using <see cref="IDocumentControl"/>
  /// one may register implementation of that interface.
  /// </summary>
  public interface IDocumentCenterControlFactory
  {
    IEnumerable<IDocumentCenterControl> CreateDocumentCenterControls();    
  }
    
}