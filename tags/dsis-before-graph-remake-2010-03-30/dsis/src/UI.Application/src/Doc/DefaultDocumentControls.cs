using System.Collections.Generic;
using DSIS.UI.UI;

namespace DSIS.UI.Application.Doc
{
  [DocumentComponent]
  public class DefaultDocumentControls : IDocumentControlFactory
  {
    private readonly IDocumentControl[] myControls;

    public DefaultDocumentControls(IDocumentControl[] controls)
    {
      myControls = controls;
    }

    public IEnumerable<IDocumentControl> CreateDocumentControls()
    {
      return myControls;
    }
  }
}